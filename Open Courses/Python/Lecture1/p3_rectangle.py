import turtle

turtle.speed('normal')
side_length = int(input("Enter side length:\n"))
rotation = 90

colors = ['green', 'orange', 'yellow', 'purple']
for side in range(0, 4):
    turtle.color(colors[side])
    turtle.forward(side_length)
    turtle.left(rotation)

input('Press any key to continue...')
