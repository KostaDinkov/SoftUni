function concatReverse(arr){

    for (let i = 0; i < arr.length; i++) {
        arr[i] = arr[i].split('').reverse().join('')

    }
    let result =arr.reverse().join('');
    console.log(result)
}
concatReverse(['I', 'am', 'student']);