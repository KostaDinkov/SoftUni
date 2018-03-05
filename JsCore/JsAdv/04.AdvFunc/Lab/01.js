function aggregate(arr) {


    console.log('Sum = ' + redux(arr, (a, b) => a + b));
    console.log('Min = ' + redux(arr, (a, b) => a < b ? a : b));
    console.log('Max = ' + redux(arr, (a, b) => a > b ? a : b));
    console.log('Product = ' + redux(arr, (a, b) => a * b));
    console.log('Join = ' + redux(arr, (a, b) => '' + a + b));

    function redux(arr, func) {
        let result = arr[0];
        for (let next of arr.slice(1)) {
            result = func(result, next);
        }
        return result;
    }

}

aggregate([2, 3, 10, 5]);