import tags

begin = '''<!DOCTYPE html>
            <html>
                <head>
                    <meta charset="utf-8">
                    <title>task3</title>
                </head>
                <body>'''

end = '''</body>
         </html>'''

with open('orig.md') as file:
    text = file.read()
    result = tags.edit_tags(text)

with open('output.html', 'w') as new_file:
    new_file.write(begin)
    new_file.write(result)
    new_file.write(end)
