function firstLastK(input_arr){

    let k = input_arr[0];
    console.log(input_arr.slice(1,1+k).join(" "));
    console.log(input_arr.slice(input_arr.length-k).join(" "))

}
firstLastK([3,6, 7, 8, 9]);