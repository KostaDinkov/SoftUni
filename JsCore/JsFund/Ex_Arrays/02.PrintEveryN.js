function printEveryN(arr){

    let step = arr[arr.length-1];

    arr = arr.slice(0,arr.length-1);
    arr.forEach((x,i)=>{if(i%step == 0){console.log(x)}});
}

printEveryN([1,2,3,4,5,6]);