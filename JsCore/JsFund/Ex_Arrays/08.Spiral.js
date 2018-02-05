function spiralMatrix(r, c) {

    let matrix = [];
    //fill the matrix with 0
    for (let i = 0; i < r; i++) {
        matrix[i] = [];
       for (let j = 0; j < c ; j++) {

         matrix[i][j]=0;
       }
    }

    //do the spiral
    let row = 0;
    let col = 0;
    let counter = 1;
    while (counter <= r * c) {
        fill(0, 1);
        row++;
        fill(1, 0);
        col--;
        fill(0, -1);
        row--;
        fill(-1, 0);
        col++;
    }

    function fill(x, y) {
        if (counter > r * c) return;
        while (true)
            if (matrix[row][col] == 0) {
                matrix[row][col] = counter;
                col += y;
                row += x;
                counter++;
                if (counter > r * c) return;
                if (row>=r || row<0 ||col>=c || col<0) {
                    col -= y;
                    row -= x;
                    break;
                }
            }
            else {
                col -= y;
                row -= x;
                break;
            }
    }
    matrix.forEach(row=> console.log(row.join(' ')));
}

spiralMatrix(2, 3);