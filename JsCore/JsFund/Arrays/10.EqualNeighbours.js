function equalNeighbours(matrix) {

    let pairCount = 0;
    for (let row = 0; row < matrix.length; row++) {

        for (let col = 0; col < matrix[0].length; col++) {

            if (matrix[row + 1] != undefined) {
                if (matrix[row][col] == matrix[row + 1][col]) {
                    pairCount++;
                    //matrix[row+1][col+1]= undefined;
                }
            }
            if (matrix[col + 1] != undefined) {
                if (matrix[row][col] == matrix[row][col + 1]) {
                    pairCount++;
                    //matrix[row][col+1] = undefined;
                }
            }
        }
    }
    return pairCount;

}

console.log(equalNeighbours(
    [[2, 2, 5, 7, 4],
        [4, 0, 5, 3, 4],
        [2, 5, 5, 4, 2]]
));