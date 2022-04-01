import re

begin = '''<!DOCTYPE html>
            <html>
                <head>
                    <meta charset="utf-8">
                    <title>lab1</title>
                </head>
                <body>'''

end = '''</body>
         </html>'''

with open('lab13.md',encoding='utf-8') as data:
    data = data.read()
    data = re.sub('\n', '<br>', data)


def search_for_md(data):
    # заголовки
    data = re.sub(r'###### (.+?)<br>', r'<h6>\</h6> <br>', data)
    data = re.sub(r'##### (.+?)<br>', r'<h5>\</h5> <br>', data)
    data = re.sub(r'#### (.+?)<br>', r'<h4>\</h4> <br>', data)
    data = re.sub(r'### (.+?)<br>', r'<h3>\</h3> <br>', data)
    data = re.sub(r'## (.+?)<br>', r'<h2>\</h2> <br>', data)
    data = re.sub(r'# (.+?)<br>', r'<h1>\</h1> <br>', data)

    # зачеркнутый текст
    data = re.sub(r'(~~)(.+?)\1', r'<strike>\</strike>', data)

    # программный код
    data = re.sub(r'(```)(.+?)\1', r'<code>\2</code>', data)

    # списки
    data = re.sub(r'\* (\w+?)((<br>)|\Z)', r'<li>\1</li>', data)

    # жирный шрифт
    data = re.sub(r'((\*\*)|(__))(.+?)\1', r'<strong>\4</strong>', data)

    # курсив
    data = re.sub(r'(\*|_)(.+?)\1', r'<em>\2</em>', data)

    # цитаты
    data = re.sub(r'<br>>(.+?)<br>', r'<br> <blockquote>\1</blockquote> <br>', data)
    data = re.sub(r'<br>><br>', r'<blockquote></blockquote>', data)


    with open('lab13copy.html', 'w',encoding='utf-8') as new_file:
        new_file.write(begin)
        new_file.write(data)
        new_file.write(end)
search_for_md(data)