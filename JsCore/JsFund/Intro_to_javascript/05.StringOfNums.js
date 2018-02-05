
function StringOfNums(n){
    let result = ''
    for (let i=1; i<=n; i++){
        result = result.concat(i)
    }
    return result;
}

console.log(StringOfNums(11));