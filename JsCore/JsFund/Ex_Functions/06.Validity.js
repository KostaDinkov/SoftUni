function validateDistance(points_arr){

    let origin = {x:0,y:0};
    let p1 = {x:points_arr[0],y:points_arr[1]};
    let p2 = {x:points_arr[2],y:points_arr[3]};

    let p1ToOrigin = Number.isInteger(getDistance(p1,origin))?'valid':'invalid';
    let p2ToOrigin = Number.isInteger(getDistance(p2,origin))?'valid':'invalid';
    let p1Top2 = Number.isInteger(getDistance(p1,p2))?'valid':'invalid';

    console.log(`{${p1.x}, ${p1.y}} to {${origin.x}, ${origin.y}} is ${p1ToOrigin}`);
    console.log(`{${p2.x}, ${p2.y}} to {${origin.x}, ${origin.y}} is ${p2ToOrigin}`);
    console.log(`{${p1.x}, ${p1.y}} to {${p2.x}, ${p2.y}} is ${p1Top2}`);


    function getDistance(p1,p2){

        return Math.sqrt(Math.pow(p1.x-p2.x,2)+Math.pow(p1.y -p2.y,2))
    }

}
validateDistance([2, 1, 1, 1]);