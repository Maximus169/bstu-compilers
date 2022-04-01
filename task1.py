import re

string = input('Input your string:\n')
#string = "This home is my home"
words = set([word.upper() for word in re.findall(r'(\w+)', string)])
#print(words)
string = re.sub(r'(\w+)', r'**\1**', string)
#print(string)
for word in words:
    string = re.sub(r'\*\*({})\*\*'.format(word), r'\1', string, count=1, flags=re.I)

print(string)
