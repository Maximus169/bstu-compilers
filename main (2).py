class IdentifiersTable:
    __nums_of_search_comp = list()

    def __init__(self):
        self.identifiers = list()

    def append(self, _id: str):
        if not isinstance(_id, str):
            raise TypeError
        _id = _id.upper()

        for index in range(len(self.identifiers)):
            if self.identifiers[index] == _id:
                break
            elif self.identifiers[index] < _id:
                self.identifiers.insert(index, _id)
                break
        else:
            self.identifiers.append(_id)

    def __str__(self):
        return 'IdentifiersTable' + str(self.identifiers)

    def search(self, _id: str, show_num_of_comp: bool = False):
        begin, end = 0, len(self.identifiers) - 1
        num_of_comp = 0
        _id = _id.upper()
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
            elif current_id_val < _id:
                end = current_index - 1
            elif current_id_val > _id:
                begin = current_index + 1


if __name__ == '__main__':

    file = open('identifico.txt')
    identifiers = tuple(map(lambda _id: _id.strip(), file.readlines()))
    file.close()

    i_t = IdentifiersTable()
    for _id in identifiers:
        i_t.append(_id)
    print(i_t, end='\n-----------------------------\n\n')

    for _id in identifiers:

        index, comp_num = i_t.search(_id, show_num_of_comp=True)
        _id = _id.upper()
        print(f'index of "{_id}" = {index}\nnum of comparisons in search = {comp_num}\n')

