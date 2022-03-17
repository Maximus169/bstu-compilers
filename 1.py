import re

str = input('Type string:\n')

nwords = set([word.lower() for word in re.findall(r'(\w+)', str)])
str = re.sub(r'(\w+)', r'**\1**', str)

for word in nwords:
    str = re.sub(r'\*\*({})\*\*'.format(word), r'\1', str, count=1, flags=re.IGNORECASE)

print(str)
