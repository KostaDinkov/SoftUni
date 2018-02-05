function round(arr){
    let number = arr[0];
    let precision = arr[1];
    if (precision>15) precision = 15;
    precision = Math.pow(10, precision);

    console.log(Math.round(number * precision) / precision);

}

round([3.1415926535897932384626433832795, 3]);