

class HashTab:

    def __init__(self):
        self.tabl = [[''],[''],[''],[''],[''],[''],[''],[''],[''],['']]

    def add(self, id):
        text = id
        id.upper()
        numer = (ord(id[0])+ord(id[1])+ord(id[2])) % 10
        if len(self.tabl[numer])==1 and self.tabl[numer][0]=='':
            self.tabl[numer][0] = text
        else:
            self.tabl[numer].append(text)
        self.tabl[numer].sort()

    def find(self, id):
        text = id
        id.upper()
        numer = (ord(id[0]) + ord(id[1]) + ord(id[2])) % 10
        first = 0
        last = len(self.tabl[numer]) - 1
        index = -1
        while (first <= last) and (index == -1):
            mid = (first + last) // 2
            if self.tabl[numer][mid] == id:
                index = mid
            else:
                if id < self.tabl[numer][mid]:
                    last = mid - 1
                else:
                    first = mid + 1
        print('['+str(numer+1)+']['+str(index+1)+']')

if __name__ == '__main__':
    tab = HashTab()
    f = open('data.txt', 'r')
    l = [line.strip() for line in f]
    for id in l:
      tab.add(id)
    print(tab.tabl)
    tab.find('table2')
    tab.find('some')
    tab.find('text')