import turtle

turtle.speed('normal')
side_length = int(input("Enter side length:\n"))
rotation = int(input("Enter rotation angle:\n"))

while True:
    turtle.forward(side_length)
    turtle.left(rotation)

input('Press any key to continue...')