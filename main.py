class InsertingError(Exception):
    """Ошибка вставки элемента в дерево."""
    pass


def hash(identify):
    return ord(identify[0])


def print_tree(head):
    if not head.left is None:
        print_tree(head.left)

    print(head.data, end=' ')

    if not head.next is None:
        print_tree(head.next)

    if not head.right is None:
        print_tree(head.right)


class Point:
    def __init__(self, data, left=None, right=None, next=None):
        self.data = data
        self.left = left
        self.right = right
        self.next = next


class Tree:
    def __init__(self):
        self.head = None

    def insert(self, point):
        print('head->', end='')
        if self.head is None:
            self.head = point
            print(point.data)
            return

        ptr = self.head
        while ptr:
            if hash(point.data) < hash(ptr.data):
                print('left->', end='')
                if ptr.left is None:
                    ptr.left = point
                    print(point.data)
                    return
                ptr = ptr.left
            elif hash(point.data) > hash(ptr.data):
                print('right->', end='')
                if ptr.right is None:
                    ptr.right = point
                    print(point.data)
                    return
                ptr = ptr.right
            elif point.data == ptr.data:
                raise InsertingError(f'Ошибка вставки элемента {point.data}')
            else:
                print('next->', end='')
                if ptr.next is None:
                    ptr.next = point
                    print(point.data)
                    return
                ptr = ptr.next

    def find(self, identify):
        ptr = self.head
        print('head->', end='')
        while ptr:
            if hash(identify) < hash(ptr.data):
                print('left->', end='')
                ptr = ptr.left
            elif hash(identify) > hash(ptr.data):
                print('right->', end='')
                ptr = ptr.right
            elif identify == ptr.data:
                print(ptr.data)
                return True, ptr
            else:
                print('next->', end='')
                ptr = ptr.next

        return False, ptr


if __name__ == '__main__':
    tree = Tree()
    with open('data.txt', 'r') as fp:
        for line in fp:
            try:
                tree.insert(Point(line.strip()))
            except InsertingError as error:
                print(error)
    print_tree(tree.head)
    print()

    print()
    print(tree.find('some')[1].data)
    print(tree.find('for')[1].data)
    print(tree.find('in')[1].data)
    print(tree.find('ffffff')[1].data)
    print(tree.find('aaaa'))
