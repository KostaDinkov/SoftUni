import unittest

from figures.figure import Figure
from renderers import turtle_renderer


class FiguresTests(unittest.TestCase):

    def setUp(self):
        self.data = \
            {"type": "square", "center_x": 0, "center_y": 0, "side": 2, "color": "black"}
        self.new_figure = Figure(turtle_renderer, **self.data)


    def tearDown(self):
        del self.data
        del self.new_figure

    def test_figure_init(self):

        self.assertEquals(self.new_figure.center_y, 0)
        self.assertEquals(self.new_figure.center_x, 0)

    def test_figures_check_data(self):

        test1= self.new_figure._check_data(self.data)
        test2 = self.new_figure._check_data({})

        self.assertEquals(True, test1)
        self.assertEquals(False, test2)



if __name__ == '__main__':
    unittest.main()
