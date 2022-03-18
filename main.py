IDENTIFIES = []


def find(value):
    for i in range(len(IDENTIFIES)):
        if IDENTIFIES[i] == value:
            return True, i + 1
    return False, len(IDENTIFIES)


def insert(value):
    count = 0
    for i in range(len(IDENTIFIES)):
        if IDENTIFIES[i] > value:
            IDENTIFIES.insert(i, value)
            return count + 1
        count += 1
    IDENTIFIES.append(value)
    return count


with open('text.txt', 'r') as fp:
    for item in fp:
        print(insert(item.strip()), item.strip(), IDENTIFIES)

print(IDENTIFIES)
print(find(input()))
