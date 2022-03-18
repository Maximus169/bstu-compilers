class IdentifiersTable:
    __nums_of_search_comp = list()

    def __init__(self, *identifiers: str):
        if not all(isinstance(_id, str) for _id in identifiers):
            raise TypeError

        self.identifiers = list()
        for _id in identifiers:
            if _id not in self.identifiers:
                self.identifiers.append(_id)
        self.identifiers.sort()

    def append(self, _id: str):
        if not isinstance(_id, str):
            raise TypeError

        for index in range(len(self.identifiers)):
            if self.identifiers[index] == _id:
                break
            elif self.identifiers[index] > _id:
                self.identifiers.insert(index, _id)
                break
        else:
            self.identifiers.append(_id)

    def __str__(self):
        return 'IdentifiersTable' + str(self.identifiers)

    @classmethod
    def get_avg_num_of_search_comp(cls):
        assert len(cls.__nums_of_search_comp) != 0, 'Not enough items in the table!'

        number = len(cls.__nums_of_search_comp)
        return round(sum(cls.__nums_of_search_comp) / number, 4)

    def search(self, _id: str, show_num_of_comp: bool = False):
        begin, end = 0, len(self.identifiers) - 1

        num_of_comp = 0
        while True:
            num_of_comp += 1

            current_index = (end + begin) // 2
            current_id_val = self.identifiers[current_index]

            if current_id_val == _id:
                IdentifiersTable.__nums_of_search_comp.append(num_of_comp)

                if show_num_of_comp:
                    return current_index, num_of_comp
                return current_index
            elif end - begin <= 0:
                raise ValueError
            elif current_id_val > _id:
                end = current_index - 1
            elif current_id_val < _id:
                begin = current_index + 1


if __name__ == '__main__':

    file = open('identifiers.txt')
    identifiers = tuple(map(lambda _id: _id.strip(), file.readlines()))
    file.close()

    i_t = IdentifiersTable()
    for _id in identifiers:
        i_t.append(_id)
    print(i_t, end='\n-----------------------------\n\n')

    for _id in identifiers:
        index, comp_num = i_t.search(_id, show_num_of_comp=True)
        print(f'index of "{_id}" = {index}\nnum of comparisons = {comp_num}\n')

    print('avg number of search comparisons:', IdentifiersTable.get_avg_num_of_search_comp())
