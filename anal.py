import re


KEY_WORDS = [
    'array',
    'of',
    'integer',
]

KEY_SYMBOLS = {
    '[': 'Знак открывающей квадратной скобки',
    ']': 'Знак закрывающей квадратной скобки',
    '..': 'Знак промежутка',
    ':': 'Знак присваивания',
}


def is_id(line):
    return {
        'result': not re.fullmatch(r'[a-zA-Z_][a-zA-Z0-9_]*', line) is None,
        'name': 'Идентификатор',
        'priority': 3,
        'data': line,
    }


def is_int_num(line):
    return {
        'result': not re.fullmatch('[0-9]+', line) is None,
        'name': 'Целочисленная константа',
        'priority': 1,
        'data': line
    }


def is_key_word(line):
    return {
        'result': line in KEY_WORDS,
        'name': 'Ключевое слово',
        'priority': 4,
        'data': line,
    }


def is_key_symbol(line):
    if line in KEY_SYMBOLS.keys():
        return {
            'result': True,
            'name': KEY_SYMBOLS.get(line),
            'priority': 2,
            'data': line,
        }
    else:
        return {
            'result': False,
            'name': 'Ключевой символ',
            'priority': 0,
            'data': line
        }


CHECK_CODE = [
    is_id,
    is_int_num,
    is_key_word,
    is_key_symbol,
]


def check_tag(tag):
    res = []
    is_true = False
    for func in CHECK_CODE:
        result = func(tag)
        res.append(result)
        is_true = is_true or result.get('result')
    return {'result': is_true, 'data': res}


with open('program.txt', 'r') as fp:
    for line in fp:
        line = line.strip()
        start = 0
        end = 1
        while True:
            tag = line[start: end]
            if tag == ';':
                if start == len(line) - 1:
                    break
                else:
                    start += 1
                    end += 1
            if tag == ' ':
                start += 1
                end += 1
                continue
            result = check_tag(tag)

            if not result.get('result'):
                result = check_tag(tag[: len(tag) - 1])
                priority = -1
                info = None
                for item in result.get('data'):
                    if item.get('result') and item.get('priority') > priority:
                        priority = item.get('priority')
                        info = item
                if info is None:
                    end += 1
                    continue
                print(info.get('name'), info.get('data'))
                start = end - 1
            else:
                end += 1

