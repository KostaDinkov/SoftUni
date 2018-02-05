function moviePrices(input_arr) {

    let title = input_arr[0].toLowerCase();
    let dayOfWeek = input_arr[1].toLowerCase();

    let movies = ['the godfather', 'schindler\'s list', 'casablanca', 'the wizard of oz'];
    let days = ['monday', 'tuesday', 'wednesday', 'thursday', 'friday', 'saturday', 'sunday'];

    let priceTable = [
        [12, 10, 15, 12.50, 15, 25, 30],
        [8.50, 8.50, 8.50, 8.50, 8.50, 15, 15],
        [8, 8, 8, 8, 8, 10, 10],
        [10, 10, 10, 10, 10, 15, 15]];

    let row_index = movies.indexOf(title);
    let col_index = days.indexOf(dayOfWeek);
    if (row_index < 0 || col_index < 0) {
        console.log('error')
    }
    else {
        console.log(priceTable[row_index][col_index])
    }

}

moviePrices(['Schindler\'s list', 'MONDAY']);