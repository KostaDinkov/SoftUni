function rotateArray(arr){

    let count = arr.splice(arr.length-1,1) % arr.length;
    let last = arr.splice(arr.length-count,count);
    arr= last.concat(arr);
    console.log(arr.join(' '));
}
rotateArray(['Banana','Orange','Coconut','Apple',15]);