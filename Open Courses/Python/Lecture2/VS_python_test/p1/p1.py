score = float(input('Enter a score: '))

lower_bound = 0.0
upper_bound = 1.0

if ((score < lower_bound) or (score > upper_bound)):
    print('Exception: score is out of range')
else:
    if score>=0.9:
        print('A')
    elif score >= 0.8:
        print('B')
    elif score >= 0.7:
        print('C')
    elif score >= 0.6:
        print('D')
    else:
        print('F')