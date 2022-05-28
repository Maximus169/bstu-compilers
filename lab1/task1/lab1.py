with open('/home/nikita/Labs/YAPIS/Lab 1/task1/text.txt', 'r') as f:
    text = f.read()
    

def text_clear(text):
    import string
    for p in string.punctuation + '\n':
        if p in text:
            if p == '\n':
                text = text.replace(p, ' ')
            else:
                text = text.replace(p, '')
    return text

def parse(text):
    count = {}
    for i in range(len(text)):
        if count.get(text[i], None):
            text[i] = '**' + text[i] + '**'
        else:
            count[text[i]] = 1

    return text
    
textC = text_clear(text)
result = parse(textC.split())
print(result)