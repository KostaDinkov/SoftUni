function tripLength(points_arr){

    let p1 ={name:'1',x:points_arr[0],y:points_arr[1]};
    let p2 = {name:'2',x:points_arr[2],y:points_arr[3]};
    let p3 = {name:'3',x:points_arr[4],y:points_arr[5]};

    var results = [];

    permute([p1,p2,p3]);
    let shortest_paht = results[0];
    for (let l of results) {

            calculateDist(l);
            if( l[3].distance < shortest_paht[3].distance){
                shortest_paht= l;
            }
    }
    console.log(`${shortest_paht[0].name}->${shortest_paht[1].name}->${shortest_paht[2].name}: ${shortest_paht[3].distance}`);

    function calculateDist(point_list){

        let distance = 0;
        distance += getDistance(point_list[0],point_list[1]);
        distance += getDistance(point_list[1],point_list[2]);
        point_list.push({distance:distance})
    }

    function getDistance(p1,p2){

        let x1 = p1.x;
        let y1 = p1.y;
        let x2 = p2.x;
        let y2 = p2.y;

        return Math.sqrt(Math.pow(x1-x2,2)+Math.pow(y1-y2,2))
    }

    function permute(arr, memo) {
        var cur, memo = memo || [];

        for (let i = 0; i < arr.length; i++) {
            cur = arr.splice(i, 1);
            if (arr.length === 0) {
                results.push(memo.concat(cur));
            }
            permute(arr.slice(), memo.concat(cur));
            arr.splice(i, 0, cur[0]);
        }
        return results;
    }
}
tripLength([-1, -2, 3.5, 0, 0, 2]);