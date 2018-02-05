class Figure:

    def __init__(self, center, color):
        self._center = center
        self._color = color

    def __str__(self):
        return "Center: {0}\n" \
            "Color: {1}\n"\
            .format(self._center, self._color)


class Circle(Figure):

    def __init__(self, center, color, radius):
        super().__init__(center, color)
        self.radius = radius

    def __str__(self):
        return super().__str__() + \
               "Radius: {0}".format(self.radius)

f = Figure((10, 20), "red")
c = Circle((12, 34), "orange", 44)
print (f)
print (c)

