from figures.circle import Circle
from figures.figure import Figure
from figures.square import Square
from renderers.renderer import Renderer
import turtle


class TurtleRenderer(Renderer):

    def __init__(self, figure: Figure):

        self.turtle = turtle.Turtle()
        self.figure = figure

    def render(self):

        if isinstance(self.figure, Circle):

            self.render_circle()

        elif isinstance(self.figure, Square):
            self.render_square()

    def render_square(self):
        half_side = self.figure.side / 2
        left = self.figure.center_x - half_side
        top = self.figure.center_y + half_side

        self.turtle.penup()
        self.turtle.goto(left, top)
        self.turtle.pendown()
        self.turtle.color(self.figure.color)
        self.turtle.forward(1)
        self.turtle.setheading(270)  # point the turtle down
        for _ in range(4):
            self.turtle.forward(self.figure.side)
            self.turtle.left(90)

    def render_circle(self):
        self.turtle.penup()
        self.turtle.goto(self.figure.center_x, self.figure.center_y - self.figure.radius)  # From docs: The center is radius units left of the turtle;
        self.turtle.pendown()
        self.turtle.color(self.figure.color)
        self.turtle.circle(self.figure.radius)