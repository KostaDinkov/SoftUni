import csv


class CatalogEntry:

    def __init__(self, item_id, category_name):
        self.item_id = str(item_id)
        self.category_name = str(category_name)

    def __repr__(self):
        return "{}: {}".format(self.__class__.__name__, str(self.__dict__))


def load_catalog_by_item_id(filename_catalog):
    with open(filename_catalog) as f:
        catalog = {
            r[0]: CatalogEntry(item_id=r[0], category_name=r[5])
            for r in csv.reader(f)
        }
        return catalog


if __name__ == "__main__":
    pass