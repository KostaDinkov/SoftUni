function diagonal(input_arr){

    let arr = [];
    input_arr.forEach(s=> arr.push(s.split(" ").map(Number)));


    let sum1 = getSum1(arr);
    let sum2 = getSum2(arr);
    if (sum1 == sum2){

        fillArr(arr, sum1);
    }
    arr.forEach(row=>console.log(row.join(' ')));

    function getSum1(arr){
        let sum = 0;
        for (let i = 0; i < arr.length; i++) {
            sum+=arr[i][i];
        }
        return sum;
    }
    function getSum2(arr){
        let sum = 0;
        for (let i = arr.length-1, j=0; i >=0 ; i--,j++) {

          sum+= arr[i][j];
        }
        return sum;
    }

    function fillArr(arr,num){

        for (let i = 0; i < arr.length ; i++) {

          for (let j = 0; j < arr[0].length ; j++) {

            if(i!=j && i!=arr[0].length-1-j){
                arr[i][j]=num;
            }
          }
        }
    }


}
diagonal(['1 1 1',
    '1 1 1',
    '1 1 0']

);