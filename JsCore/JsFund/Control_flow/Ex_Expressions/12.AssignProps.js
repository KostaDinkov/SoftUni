function arrToObj(arr){

    let obj = {};
    for (let i = 0; i < arr.length; i+=2) {

        obj[arr[i]]=arr[i+1];
    }

    return obj;
}

obj = arrToObj(['name', 'Pesho', 'age', '23', 'gender', 'male']);
console.log(obj);