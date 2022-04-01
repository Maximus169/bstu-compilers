import re
import  nltk.tokenize
def is_roman_number(num):
    pattern = re.compile(r"""   
                                ^M{0,3}
                                (CM|CD|D?C{0,3})?
                                (XC|XL|L?X{0,3})?
                                (IX|IV|V?I{0,3})?$
            """, re.VERBOSE)
    if re.match(pattern, num):
        return True
    return False

num_valid = input("Напишите число")
num_valid = num_valid.split(";")
print(num_valid)


#num_invalid = 'CCCMMVIIVV'
for word1 in num_valid:
    words = word1.split()
    for word in words:
        print(f"{word} - это {'не ' if not is_roman_number(word) else ''}римское число")
        if not is_roman_number(word):
            if word == "(" or word == ")":
                print(word,"-Скобка")
            elif word == "-" or word == "+" or word == "/" or word == "*":
                print(word,"-Знак операции")
            elif word == "=":
                print(word,"-Знак равенства")
