list1 = []

i=0
n=10
#input(n)
while i<n:
    list1.append(input())
    i=i+1
    list1.sort()
  #  print(list1)
for items in list1:
    print(items)


def binary_search_iterative(array, element):
    mid = 0
    start = 0
    end = len(array)
    step = 0

    while (start <= end):
        print("Subarray in step {}: {}".format(step, str(array[start:end+1])))
        step = step+1
        mid = (start + end) // 2

        if element == array[mid]:
            return mid

        if element < array[mid]:
            end = mid - 1
        else:
            start = mid + 1

    return -1


print("Searching for {} in {}".format(list1, input()))
print("Index of {}: {}".format(input(), binary_search_iterative(list1, input())))
