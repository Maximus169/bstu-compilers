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
        hashValue = hash(text[0] + text[1] + text[2])
        hashValue %= self.size
        return hashValue


    def collision(self, hashValue, key):
        if len(self.table[hashValue]) == 1:
            self.table[hashValue].append([key])
        else:
            self.table[hashValue][1].append(key)


    def algInit(self, text):
        for i in range(len(text)):
            hashValue = self.hashFunc(text[i]) % self.size
            if self.table[hashValue][0] == -1:
                self.calc_r += 1
                self.table[hashValue][0] = text[i]
            elif self.table[hashValue][0] != -1:
                self.calc_c += 1
                self.collision(hashValue, text[i])


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
    
    def search(self, word):
        hashValue = self.hashFunc(word) % self.size
        if self.table[hashValue][0] != -1:
            if self.table[hashValue][0] == word:
                print(self.table[hashValue][0], hashValue)
            else:
                if self.binarySearch(self.table[hashValue][1], word) == None:
                    print('We cant find your word')
                else:
                    print(self.binarySearch(self.table[hashValue][1], word), hashValue)
        else:
            print('We cant find your word')


    def get(self, text):

        print(self.table)
        print('Non-collision - ', (self.calc_r / len(text)) * 100, '%', sep='')
        print('Collision - ', (self.calc_c / len(text)) * 100, '%', sep='')




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
    