function distance3d(data){

    let x1 = data[0];
    let y1 = data[1];
    let z1 = data[2];
    let x2 = data[3];
    let y2 = data[4];
    let z2 = data[5];

    console.log(Math.sqrt((Math.pow((x1 - x2), 2) + Math.pow((y1 - y2), 2) + Math.pow((z1 - z2), 2))));

}

distance3d([3.5, 0,1,0,2,-1]);