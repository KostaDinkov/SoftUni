function negetivePositive(arr){

    let result = [];
    arr.forEach(x=>x<0?result.unshift(x):result.push(x));
    console.log(result.join('\n'));
}

negetivePositive([3, -2, 0, -1]);

