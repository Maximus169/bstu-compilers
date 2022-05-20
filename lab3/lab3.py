import re
import pandas as pd
import seaborn as sns

class Analyzer:

    procedures = []
    parameters = []
    tokens = []
    tokenType = []
    tokenValue = []


    def readFile(self, fileName):

        with open(fileName, 'r') as f:
            textF = f.read()
        self.text = textF

    def split(self):

        result = re.split(r'[(,)]', self.text)
        for i in range(len(result)):
            for j in range(len(result[i])):
                if len(result[i]) > 1 and space(result[i][0]):
                    inputText = result[i]
                    resultText = ''
                    for k in range(len(inputText)):
                        if k != 0:
                            resultText += inputText[k]
                    result[i] = resultText
        return result

    def alg(self):

        result = self.split()
        for i in range(len(result)):
            if len(result[i]) == 0:
                result.pop(i)
        self.procedures.append(result[0])
        for i in range(len(result)):
            if i > 0 and len(result[i]) > 0 and result[i][0] != ';':
                self.parameters.append(result[i])
            elif result[i][0] == ';':
                result[i] = result[i].replace(';', '')
                self.procedures.append(result[i])
        self.token = self.procedures + self.parameters
        num = 0
        for i in range(len(self.token)):
            if i < len(self.procedures):
                self.tokenType.append('Procedure')
                self.tokenValue.append(self.token[i] + ' : ' + str(i))
            else:
                self.tokenType.append('Parameter')
                if self.token[i].isdigit():
                    self.tokenValue.append(self.token[i])
                elif 'I' in self.token[i] or 'V' in self.token[i] or 'X' in self.token[i]:
                    self.tokenValue.append(parseRoman(self.token[i]))
                else:
                    self.tokenValue.append(self.token[i] + ' : ' + str(num))
                    num += 1
        #for i in range(len(self.tokens)):
            #if

def space(text):
    if ' ' in text:
        return True
    else:
        return False

def toSameLen():
    len1 = 0
    len2 = 0
    if len(an1.procedures) > len(an1.parameters):
        len1 = len(an1.procedures)
        len2 = len(an1.parameters)
        for i in range(len1 - len2):
            an1.parameters.append(0)
    else:
        len1 = len(an1.parameters)
        len2 = len(an1.procedures)
        for i in range(len1 - len2):
            an1.procedures.append(0)
            
def parseRoman(object):
    result = 0
    for i in range(len(object)):
        if object[i] == 'I':
            result += 1
        elif object[i] == 'V':
            result += 5
        elif object[i] == 'X':
            result += 10
    return result

an1 = Analyzer()
an1.readFile('text.txt')
print(an1.alg())
print(an1.procedures, an1.parameters)


df = pd.DataFrame({
    'Token': an1.token,
    'Type of token': an1.tokenType,
    'Value of token': an1.tokenValue
    })

print(df)