import re
import io

with io.open('file1.md', encoding='utf-8') as f1:
    rd = f1.read()

def search_for_md(r_d):

    r_d = re.sub(r'\>\b', r'<blockquote>', r_d)
    r_d = re.sub(r'\b\>\n', r'</blockquote>', r_d)
    r_d = re.sub(r'\#{6}\s*\b', r'<h6>', r_d)
    r_d = re.sub(r'\#{6}', r'</h6>', r_d)
    r_d = re.sub(r'\#{5}\s*\b', r'<h5>', r_d)
    r_d = re.sub(r'\#{5}', r'</h5>', r_d)
    r_d = re.sub(r'\#{4}\s*\b', r'<h4>', r_d)
    r_d = re.sub(r'\#{4}', r'</h4>', r_d)
    r_d = re.sub(r'\#{3}\s*\b', r'<h3>', r_d)
    r_d = re.sub(r'\#{3}', r'</h3>', r_d)
    r_d = re.sub(r'\#{2}\s*\b', r'<h2>', r_d)
    r_d = re.sub(r'\#{2}', r'</h2>', r_d)
    r_d = re.sub(r'\#\s*\b', r'<h1>', r_d)
    r_d = re.sub(r'\#', r'</h1>', r_d)
    r_d = re.sub(r'\~{2}\s*\b', r'<del>', r_d)
    r_d = re.sub(r'\~{2}', r'</del>', r_d)
    r_d = re.sub(r'\*{2}\s*\b', r'<strong>', r_d)
    r_d = re.sub(r'\*{2}', r'</strong>', r_d)

    r_d = re.sub(r'\`\s*\b', r'<code>', r_d)
    r_d = re.sub(r'\`\n', r'</code>', r_d)

    r_d = re.sub(r'\d\.\s', '<li>', r_d)
    r_d = re.sub(r'\b\n', '</li>', r_d)


    #print(r_d)
    with open('file2.html', 'w') as f:
        w_d = f.write(r_d)

search_for_md(rd)
