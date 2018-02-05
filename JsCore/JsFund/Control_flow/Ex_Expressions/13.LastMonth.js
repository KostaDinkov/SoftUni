function lastMonth(date_arr){
    let year = date_arr[2];
    let month = date_arr[1];
    return new Date(year,month-1,0).getDate();
}

console.log(lastMonth([13, 12, 2004]));