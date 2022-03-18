import re

from roman import fromRoman  # conversion from Roman numbers to int


class LexemesTable:
    class Lexeme:
        def __init__(self, _id, type, value):
            if not all([isinstance(_id, str), isinstance(type, str)]):
                raise TypeError
            self.id = _id
            self.type = type
            self.value = value

    def __init__(self):
        self.identifiers = list()

    def append(self, _id: str, type: str, value):
        lex = self.Lexeme(_id, type, value)

        for index in range(len(self.identifiers)):
            if self.identifiers[index].id == lex.id:
                break
            elif self.identifiers[index].id > lex.id:
                self.identifiers.insert(index, lex)
                break
        else:
            self.identifiers.append(lex)

    def __str__(self):
        return 'LexemesTable' + str([iden.id for iden in self.identifiers])

    def __getitem__(self, item):
        return self.identifiers[item]

    def search(self, _id: str):
        begin, end = 0, len(self.identifiers) - 1

        while True:
            current_index = (end + begin) // 2
            current_id_val = self.identifiers[current_index].id

            if current_id_val == _id:
                return current_index
            elif end - begin <= 0:
                return None
            elif current_id_val > _id:
                end = current_index - 1
            elif current_id_val < _id:
                begin = current_index + 1


class LexicalAnalyzer:
    def __init__(self, program_text: str):
        self.program_text = tuple(map(lambda row: row.strip(), program_text.split(';')))[:-1]

    def show_lexemes_table(self):
        table = LexemesTable()

        # insert all "key words" of language into table
        key_words = ['*', '/', '+', '-', '(', ')', '=']
        for key_id in key_words:
            table.append(key_id, 'Key word', key_id)

        # parsing rows of program text
        for row in self.program_text:
            assignment_statement = re.match(r'(\w+) = (.+)', row)
            if assignment_statement:

                _id, value = assignment_statement.groups()

                # insert new lexemes from statement into table
                for elem in value.split():
                    if table.search(elem) is None:
                        if re.match(r'[XVI]+', elem):
                            table.append(elem, 'Literal', fromRoman(elem))
                        else:
                            raise ValueError(f'Invalid value "{elem}" at row: "{row}"')

                # eval statement in integer form
                for elem in value.split():
                    real_val = str(table[table.search(elem)].value)
                    if elem in ['*', '+', ')', '(']:
                        elem = "\\" + elem
                    value = re.sub(elem, real_val, value, count=1)
                value = eval(value)

                # insert value for identifier or create and insert
                lexeme_index = table.search(_id)
                if lexeme_index is not None:
                    table[lexeme_index].value = value
                else:
                    table.append(_id, 'Identifier', value)

            else:
                # insert new lexemes from statement into table if passed
                for elem in row.split():
                    if table.search(elem) is None:
                        if re.match(r'[XVI]+', elem):
                            table.append(elem, 'Literal', fromRoman(elem))
                        else:
                            raise ValueError(f'Invalid value "{elem}" at row: "{row}"')

        self.__show_table(table)

    def __show_table(self, table: LexemesTable):
        print('Lexeme:\t\tType:\t\tValue:')
        print('-------------------------------------------')
        for lexeme in table:
            print(f'{lexeme.id}\t\t{lexeme.type}\t\t{lexeme.value}')


if __name__ == '__main__':
    with open('program.txt') as program:
        program_text = program.read()

    la = LexicalAnalyzer(program_text)
    la.show_lexemes_table()
