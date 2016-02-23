class Figure(object):

    def __init__(self, **kwargs):

        self.center_x = None
        self.center_y = None
        self.color = None

        if self._check_data(kwargs):
            self.center_x = kwargs['center_x']
            self.center_y = kwargs['center_y']
            self.color = kwargs['color']
        else:
            raise ValueError

    def _check_data(self, data: dict):

        attr = self.__dict__
        try:
            has_attr = all(a in data.keys() for a in attr.keys())
            return has_attr
        except KeyError:

            return False

    def __str__(self):
        return "{0}: center_x = {1}, center_y= {2} "\
            .format(self.__class__,self.center_x,self.center_y)





