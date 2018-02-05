from figures.figure import Figure


class Square(Figure):

    def __init__(self, **kwargs):
        self.side = None

        super().__init__(**kwargs)

        self.side = kwargs['side']

    def __str__(self):
        return super().__str__() + "side: {}".format(self.side)