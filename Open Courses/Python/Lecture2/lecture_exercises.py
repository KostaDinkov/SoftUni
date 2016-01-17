numbers = []


def minimum(collection):
    min_element = None
    for element in collection:
        if min_element is None:
            min_element = element
        if element < min_element:
            min_element = element
    return min_element


def maximum(collection):
    max_element = None
    for element in collection:
        if max_element is None:
            max_element = element
        if element > max_element:
            max_element = element
    return max_element


while True:
    input_string = input('Enter a number: ')
    if input_string == 'done':
        break
    try:
        number = int(input_string)
        numbers.append(number)
    except:
        print('Invalid input')

print("Maximum is ", maximum(numbers))
print("Minimum is ", minimum(numbers))

