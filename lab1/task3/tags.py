import re


def edit_tags(text: str) -> str:
    text = re.sub('\n', '<br>', text)

    text = re.sub(r'###### (.+?)<br>', r'<h6>\1</h6> <br>', text)
    text = re.sub(r'##### (.+?)<br>', r'<h5>\1</h5> <br>', text)
    text = re.sub(r'#### (.+?)<br>', r'<h4>\1</h4> <br>', text)
    text = re.sub(r'### (.+?)<br>', r'<h3>\1</h3> <br>', text)
    text = re.sub(r'## (.+?)<br>', r'<h2>\1</h2> <br>', text)
    text = re.sub(r'# (.+?)<br>', r'<h1>\1</h1> <br>', text)

    text = re.sub(r'(~~)(.+?)\1', r'<strike>\2</strike>', text)

    text = re.sub(r'(```)(.+?)\1', r'<code>\2</code>', text)

    text = re.sub(r'\* (\w+?)((<br>)|\Z)', r'<li>\1</li>', text)

    text = re.sub(r'((\*\*)|(__))(.+?)\1', r'<strong>\4</strong>', text)

    text = re.sub(r'(\*|_)(.+?)\1', r'<em>\2</em>', text)

    text = re.sub(r'<br>>(.+?)<br>', r'<br> <blockquote>\1</blockquote> <br>', text)

    return text
