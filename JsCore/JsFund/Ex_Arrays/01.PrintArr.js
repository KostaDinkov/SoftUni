function joinArr(arr){

    let delimiter = arr[arr.length-1];
    console.log(arr.slice(0,arr.length-1).join(delimiter));
}

joinArr(['One','Two','Three','Four','Five', '-']);