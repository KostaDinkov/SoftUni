import turtle


def main():
    window = turtle.Screen()

    square_size = 30
    offset = - (square_size * 4)  # used to center the board on in the window

    draw_chessboard(square_size, offset, offset)

    window.exitonclick()


def draw_rectangle(t, size, fill_color):
    t.fillcolor(fill_color)
    t.begin_fill()

    for i in range(4):
        t.forward(size)
        t.right(90)
    t.end_fill()


def draw_chessboard(square_size, x, y):
    t = turtle.Turtle()
    t.speed('fastest')
    t.penup()
    t.setposition(x, y)

    is_black = True

    for row in range(y, y + (square_size * 8), square_size):

        is_black = not is_black  # change the color every time we start a new row

        for col in range(x, x + (square_size * 8), square_size):
            t.penup()
            t.setposition(col, row)
            t.pendown()
            fill_color = 'black' if is_black else 'white'
            draw_rectangle(t, square_size, fill_color)
            is_black = not is_black


if __name__ == '__main__':
    main()
