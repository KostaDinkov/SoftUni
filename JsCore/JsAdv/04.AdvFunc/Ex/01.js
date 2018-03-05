function sortArr(arr, direction) {

    let sort = {
        asc: (a, b) => a - b,
        desc: (a, b) => b - a
    };
    return arr.sort(sort[direction]);
}

console.log(sortArr([14, 7, 17, 6, 8], 'asc'));
console.log(sortArr([14, 7, 17, 6, 8], 'desc'));