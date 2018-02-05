function calculateInterest(data_arr){

    let principal = data_arr[0];
    let rate = data_arr[1]/100;
    let comp_period = data_arr[2];
    let total_time = data_arr[3];
    let freq = 12 / comp_period;
    let result = principal*(Math.pow(1+(rate/freq),freq*total_time))
    console.log(Math.round(result*100)/100);


}

calculateInterest([100000,5,12,25]);