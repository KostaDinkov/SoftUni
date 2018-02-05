function diagonalSums(num_matrix) {

    let sum1 = 0;
    let sum2 = 0;
    for (let x = 0, y = 0; x < num_matrix.length; x++, y++) {

        sum1 += num_matrix[x][y];
    }
    for (let x = num_matrix.length - 1, y = 0; x >= 0; x--, y++) {
        sum2 += num_matrix[x][y];
    }
    console.log(sum1, sum2);

}

diagonalSums([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
);