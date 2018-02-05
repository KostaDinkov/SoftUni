function treasureLocator(points_arr) {

    let zones = [
        {name: 'Tuvalu', p1: {x: 1, y: 3}, p2: {x: 3, y: 1}},
        {name: 'Tonga', p1: {x: 0, y: 8}, p2: {x: 2, y: 6}},
        {name: 'Cook', p1: {x: 4, y: 8}, p2: {x: 9, y: 7}},
        {name: 'Samoa', p1: {x: 5, y: 6}, p2: {x: 7, y: 3}},
        {name: 'Tokelau', p1: {x: 8, y: 1}, p2: {x: 9, y: 0}}];

    let points = [];
    for (let i = 0; i <= points_arr.length - 2; i += 2) {
        points.push({x: points_arr[i], y: points_arr[i + 1]})
    }

    for (let point of points) {
        let inZone = false;
        for (let zone of zones) {

            if (isPointInZone(point, zone)) {
                console.log(zone.name);
                inZone = true;
                break;
            }
        }
        if (!inZone) {
            console.log('On the bottom of the ocean')
        }
    }

    function isPointInZone(p, zone) {

        return !(p.x < zone.p1.x || p.x > zone.p2.x || p.y > zone.p1.y || p.y < zone.p2.y);
    }
}

treasureLocator([6, 4]);