import turtle

t = turtle.Turtle()
window = turtle.Screen()
window.setup(width=800, height=800)

repeat_count = 100  # int(input("Enter repeat count:\n"))

degrees = 5
distance = 2
t.fillcolor('orange')
t.begin_fill()

for counter in range(repeat_count):
    t.left(degrees)
    t.forward(distance)

window.exitonclick()
