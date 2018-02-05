function pointInRect(num_arr){

    let x = num_arr[0];
    let y = num_arr[1];
    let xMin = num_arr[2];
    let xMax = num_arr[3];
    let yMin = num_arr[4];
    let yMax= num_arr[5];

    if ((x>=xMin && x<=xMax) && (y <= yMax && y>=yMin)){
        console.log('inside');

    }
    else{
        console.log('outside');
    }

}

pointInRect([8,-1,2,12,-3,3]);
