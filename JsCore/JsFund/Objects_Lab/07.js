function population(strArr){

    let towns = new Map();
    for (let str of strArr) {
        let [town, pop] = str.split(/ <-> /);
        towns.has(town)?towns.set(town, towns.get(town)+Number(pop)):towns.set(town,Number(pop));
    }

    towns.forEach((value, key)=> console.log(`${key} : ${value}`))

}

population(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Sofia <-> 2345000',
    'Las Vegas <-> 1000000']);