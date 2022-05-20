from sys import hash_info


class Table:

    calc_r = 0
    calc_c = 0

    def __init__(self, s):

        self.size = s
        self.table = [[-1] for i in range(self.size)]


    def readFile(self, filename):

        with open(filename, 'r') as f:
            text = f.read()
        text = text.split()
        return text


    def hashFunc(self, text):
        hashValue = hash(text)
        hashValue %= self.size
        return hashValue


    def collision(self, hashValue, key, value):
        if len(self.table[hashValue]) <= 2:
            self.table[hashValue].append([key, value])
        else:
            self.table[hashValue][2].append(key)
            self.table[hashValue][2].append(value)


    def algInit(self, text):
        keys = []
        values = []
        keys, values = self.devide(text)
        for i in range(len(keys)):
            hashValue = self.hashFunc(keys[i]) % self.size
            if self.table[hashValue][0] == -1:
                self.calc_r += 1
                self.table[hashValue][0] = keys[i]
                self.table[hashValue].append(values[i])
            elif self.table[hashValue][0] != -1:
                self.calc_c += 1
                self.collision(hashValue, keys[i], values[i])


    def binarySearch(self, obj, word):
        low = 0
        high = len(obj) - 1
        while low <= high:
            mid = (low + high) // 2
            guess = obj[mid]
            if guess == word:
                return obj[mid]
            elif guess > word:
                high = mid - 1
            else:
                low = mid + 1
        return None
    
    def devide(self, object):   #Делим ключи и значения
        values = []
        keys = []
        for i in range(len(object)):
            if object[i].isnumeric():
                values.append(object[i])
            else:
                keys.append(object[i])
        return keys, values

    def sort(self, hash, keys, values):   #Сортировка(при коллизии поиска) исправить
        keys, values = self.devide(hash)
        for i in range(len(keys)):
            for j in range(len(keys) - i):
                if keys[j] > keys[j + 1]:
                    keys[j], keys[j + 1] = keys[j + 1], keys[j]
                    values[j], values[j + 1] = values[j + 1], values[j]

    def search(self, word):
        hashValue = self.hashFunc(word) % self.size
        if self.table[hashValue][0] != -1:
            if self.table[hashValue][0] == word:
                print(self.table[hashValue][0], hashValue)
            #elif self.table[hashValue][1][0] == word:
                #print(self.table[hashValue][1][0], hashValue)
            else:
                sort()
                if self.binarySearch(self.table[hashValue][2], word) == None:
                    print('We cant find your word')
                else:
                    print(self.binarySearch(self.table[hashValue][1], word))
        else:
            print('We cant find your word')


    def get(self, text):

        print(self.table)
        print('Non-collision - ', (self.calc_r / len(text)) * 100, '%', sep='')
        print('Collision - ', (self.calc_c / len(text)) * 100, '%', sep='')



"""
def menu():
    letter = 1
    while(letter != 0):
        print("1.Init programm.")
        print("2.Search word.")
        print("3.Open the file.")
        print("4.Statistics.")
        print("0.Quit.")
        letter = int(input(':'))
        if letter == 1:
            size = int(input('Enter the size of the table:'))
            tb1 = Table(size)
            tb1.algInit(tb1.readFile('text.txt'))
        elif letter == 2:
            word = input()
            tb1.search(word)
        elif letter == 3:
            print(tb1.readFile('text.txt'))
        elif letter == 4:
            tb1.get(tb1.readFile('text.txt'))

menu()
    """
tb1 = Table(20)
tb1.algInit(tb1.readFile('text.txt'))
tb1.get(tb1.readFile('text.txt'))