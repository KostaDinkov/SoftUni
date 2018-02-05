function biggest(num_arr){

    let biggest = Number.NEGATIVE_INFINITY;
    num_arr.forEach((x)=>x.forEach(y=>{if(y>biggest){biggest =y}}));
    return biggest;
}

console.log(biggest([[20, 50, 10], [8, 33, 145]]));