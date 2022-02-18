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
            '>': {'function': change_single_repeat_tag, 'tags': ['<blockquote>', '</blockquote>']},
            '\*\*\*': {'function': change_double_tag, 'tags': ['<em><strong>', '</strong></em>']},
            '\*\*': {'function': change_double_tag, 'tags': ['<strong>', '</strong>']},
            '\*': {'function':change_double_tag, 'tags': ['<em>', '</em>']},
            '___': {'function':change_double_tag, 'tags': ['<em><strong>', '</strong></em>']},
            '__': {'function':change_double_tag, 'tags': ['<strong>', '</strong>']},
            '_': {'function':change_double_tag, 'tags': ['<em>', '</em>']},
            '~~': {'function':change_double_tag, 'tags': ['<strike>', '</strike>']},
            '######': {'function':change_single_tag, 'tags': ['<h6>', '</h6>']},
            '#####': {'function':change_single_tag, 'tags': ['<h5>', '</h5>']},
            '####': {'function':change_single_tag, 'tags': ['<h4>', '</h4>']},
            '###': {'function':change_single_tag, 'tags': ['<h3>', '</h3>']},
            '##': {'function':change_single_tag, 'tags': ['<h2>', '</h2>']},
            '#': {'function':change_single_tag, 'tags': ['<h1>', '</h1>']},
            '```': {'function':change_double_tag, 'tags': ['<code>', '</code>']},
            '``': {'function':change_double_tag, 'tags': ['<code>', '</code>']},
            '`': {'function':change_double_tag, 'tags': ['<code>', '</code>']},
            '\-': {'function':change_single_tag, 'tags': ['<li>', '</li>']},
            '\+': {'function':change_single_tag, 'tags': ['<li>', '</li>']},
        }

        for markdown in fp.readlines():
            if markdown == '\n':
                fres.write('<br>')
                continue

            for symbols, working_info in changing.items():
                markdown = working_info.get('function')(
                    markdown,
                    symbols,
                    working_info['tags'][0],
                    working_info['tags'][1]
                )
            fres.write(markdown)
            fres.write('<br>')

    fres.write('</body></html>')
