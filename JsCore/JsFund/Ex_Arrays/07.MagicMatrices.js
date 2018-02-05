function magicMatrix(arr) {

    let sum = arr[0].reduce((sum, e) => sum + e, 0);
    for (let row = 1; row < arr.length; row++) {
        let row_sum = arr[row].reduce((sum, e) => sum + e, 0);

        if (row_sum != sum) {
            return false;
        }

    }
    for (let col = 0; col < arr[0].length; col++) {
        let col_sum = 0;
        for (let row = 0; row < arr.length; row++) {
            col_sum += arr[row][col];
        }
        if (col_sum != sum) {
            return false;
        }
        col_sum = 0;
    }
    return true;

}

console.log(magicMatrix([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]



));