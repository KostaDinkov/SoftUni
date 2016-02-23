from figures.figure import Figure


class Circle(Figure):

    def __init__(self, **kwargs):
        self.radius = None

        super().__init__(**kwargs)

        self.radius = kwargs['radius']

    def __str__(self):
        return super().__str__() + "radius: {}".format(self.radius)