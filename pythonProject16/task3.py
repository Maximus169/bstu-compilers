import re


def change_double_tag(line, changing_symbols, tag_first, tag_second):
    count = len(re.findall(changing_symbols, line))
    while count > 1:
        new_line = re.sub(changing_symbols, tag_first, line, count=1)
        line = new_line
        new_line = re.sub(changing_symbols, tag_second, line, count=1)
        line = new_line
        count -= 2
    return line


def change_single_tag(line, changing_symbols, tag_first, tag_second):
    if len(re.findall(changing_symbols, line)) > 0:
        new_line = re.sub(changing_symbols, tag_first, line, count=1)
        return new_line + tag_second
    else:
        return line


def change_single_repeat_tag(line, changing_symbols, tag_first, tag_second):
    count = len(re.findall(changing_symbols, line))
    if count > 0:
        new_line = re.sub(changing_symbols, tag_first, line)
        return new_line + count * tag_second
    else:
        return line


with open('ex.html', 'w') as fres:
    fres.write('<!DOCTYPE html><html lang="en"><head><meta charset="UTF-8"></head><body>')

    with open('example.md', 'r') as fp:
        changing = {
            '>': [change_single_repeat_tag, ['<blockquote>', '</blockquote>']],
            '\*\*\*': [change_double_tag, ['<em><strong>', '</strong></em>']],
            '\*\*': [change_double_tag, ['<strong>', '</strong>']],
            '\*': [change_double_tag, ['<em>', '</em>']],
            '___': [change_double_tag, ['<em><strong>', '</strong></em>']],
            '__': [change_double_tag, ['<strong>', '</strong>']],
            '_': [change_double_tag, ['<em>', '</em>']],
            '~~': [change_double_tag, ['<strike>', '</strike>']],
            '######': [change_single_tag, ['<h6>', '</h6>']],
            '#####': [change_single_tag, ['<h5>', '</h5>']],
            '####': [change_single_tag, ['<h4>', '</h4>']],
            '###': [change_single_tag, ['<h3>', '</h3>']],
            '##': [change_single_tag, ['<h2>', '</h2>']],
            '#': [change_single_tag, ['<h1>', '</h1>']],
            '```': [change_double_tag, ['<code>', '</code>']],
            '``': [change_double_tag, ['<code>', '</code>']],
            '`': [change_double_tag, ['<code>', '</code>']],
            '\-': [change_single_tag, ['<li>', '</li>']],
            '\+': [change_single_tag, ['<li>', '</li>']],
        }

        for markdown in fp.readlines():
            for symbols, working in changing.items():
                markdown = working[0](
                    markdown,
                    symbols,
                    working[1][0],
                    working[1][1]
                )
            fres.write(markdown)
            fres.write('<br>')

    fres.write('</body></html>')
