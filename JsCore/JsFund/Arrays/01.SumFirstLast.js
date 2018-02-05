function sumFirstLast(num_arr){

    let a = Number(num_arr[0]);
    let b = Number(num_arr[num_arr.length-1]);
    return a+b;
}

console.log(sumFirstLast(['20','30','40']));