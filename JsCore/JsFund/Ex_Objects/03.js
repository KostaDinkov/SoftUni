function juice(input_arr) {

    let juices = new Map();
    let bottleOrder = new Set();
    for (let str of input_arr) {

        let [name, count] = str.split(/ => /);
        count = Number(count);
        if (!juices.has(name)) {
            juices.set(name, count);
        }
        else{
            juices.set(name, juices.get(name) + count);
        }

        if (juices.get(name) >= 1000) {
            bottleOrder.add(name);

        }
    }
    for (let juice of bottleOrder) {
        let bottles = Math.floor( juices.get(juice)/ 1000);
        console.log(`${juice} => ${bottles}`)

    }
}
juice(['Orange => 2000' ,
    'Peach => 1432' ,
    'Banana => 450' ,
    'Peach => 600' ,
    'Strawberry => 549']);

