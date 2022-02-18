import re


str = input('Entry data: ').strip()

lst = re.split(r'[ .,!]+', str)
for i in range(len(lst)):
    if lst[i] != '' and (lst[i] in lst[i + 1:]):
        str = re.sub(r'\b{}\b'.format(lst[i]), f'**{lst[i]}**', str)

for i in range(len(lst)):
    if lst[i] != '' and (lst[i] in lst[i + 1:]):
        str = re.sub(f'\*\*{lst[i]}\*\*', lst[i], str, count=1)

print(str)
