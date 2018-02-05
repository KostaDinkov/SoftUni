import json


def load_input_data(filename):
    with open(filename) as f:
        input_data = json.load(f)
        return input_data


