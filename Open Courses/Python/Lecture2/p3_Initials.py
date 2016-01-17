name = "" + input("Enter name: ")

nameSplit = name.split()
initials = ''

for part in nameSplit:
    if not(part[0].islower()):
        initials += part[0]+'.'
print(initials)

