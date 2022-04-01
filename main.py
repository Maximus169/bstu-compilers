TABLE_SIZE = 5
MASS = [[] for i in range(TABLE_SIZE)]


def hash(ident):
    ident = ident.upper()
    number = ord(ident[0])+ord(ident[1])+ord(ident[2])
    return number


def insert(ident):
    id = hash(ident) % TABLE_SIZE
    MASS[id].append(ident)


def find(ident):
    id = hash(ident) % TABLE_SIZE
    if ident in MASS[id]:
        return True
    else:
        return False


with open('text.txt', 'r') as fp:
    for word in fp:
        insert(word.strip())

for item in MASS:
    print(item)

if find(input()):
    print("vse ok")