function heroes(input_arr){
    let heroes = [];

    for (let row of input_arr) {

        let[name, level, items_str] = row.split(/ \/ /g);
        let items = [];
        if(items_str !== undefined){
            items = items_str.split(/, /);
        }

        let hero = {name : name, level: Number(level), items:items?items:[]};
        heroes.push(hero);
    }
    console.log(JSON.stringify(heroes))
}

heroes(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara',
    'Kodin / 100 / ']);