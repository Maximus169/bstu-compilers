import re

string = input('Type string:\n')

words = set([word.lower() for word in re.findall(r'(\w+)', string)])
string = re.sub(r'(\w+)', r'**\1**', string)

for word in words:
    string = re.sub(r'\*\*({})\*\*'.format(word), r'\1', string, count=1, flags=re.IGNORECASE)

print(string)
