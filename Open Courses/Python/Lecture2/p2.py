
firstString = "" + input("Enter first string: \n")
secondString = "" + input("Enter second string:\n")
cutIndex = firstString.find(secondString)
resultString = firstString[cutIndex + len(secondString):]
print(resultString)


