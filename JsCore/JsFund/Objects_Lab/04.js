function sumByTown(arr) {

    let result = {};
    for (let i = 0; i < arr.length; i += 2) {

        if (result.hasOwnProperty(arr[i])) {
            result[arr[i]] += Number(arr[i + 1]);
        }
        else{
            result[arr[i]]=Number(arr[i+1]);
        }

    }
    console.log(JSON.stringify(result))
}

sumByTown(['Sofia','20','Varna','3','Sofia','5', 'Varna','4']);