function distance(data){

    let v1 = data[0];
    let v2 = data[1];
    let time_h = data[2] /3600;
    let s1 = v1 * time_h;
    let s2 = v2 * time_h;
    let delta = Math.abs(s1-s2)*1000;

    console.log(delta);
}

distance([11,10, 120]);

