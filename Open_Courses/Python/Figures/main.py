from figures.circle import Circle
from figures.square import Square
from parsers import json_parser

from renderers.turtle_renderer import TurtleRenderer

FIGURE_TYPES = {'circle': Circle,
                'square': Square}


def main():

    figures_data = json_parser.load_input_data("figures_data.json")
    figures = build_figures(figures_data)

    for figure in figures:
        renderer = TurtleRenderer(figure)
        renderer.render()

    input("Press Enter to continue...")


def build_figures(figures_data):
    figures = []
    for figure_data in figures_data:
        if figure_data["type"] in FIGURE_TYPES:
            figure_class = FIGURE_TYPES[figure_data["type"]]
            figures.append(figure_class(**figure_data))
    return figures


if __name__ == '__main__':
    main()