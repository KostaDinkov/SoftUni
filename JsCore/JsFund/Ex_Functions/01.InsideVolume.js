function insideVolume(points_arr){
    let xMin = 10;
    let xMax = 50;
    let yMin = 20;
    let yMax = 80;
    let zMin = 15;
    let zMax = 50;

    for (let i = 0; i < points_arr.length ; i+=3) {

        let x = points_arr[i];
        let y = points_arr[i+1];
        let z = points_arr[i+2];

        if(x <xMin || x>xMax || y < yMin || y > yMax || z<zMin || z> zMax){
            console.log('outside')
        }
        else{
            console.log('inside')
        }
    }
}

insideVolume([13.1, 50, 31.5,50, 80, 50,-5, 18, 43]);