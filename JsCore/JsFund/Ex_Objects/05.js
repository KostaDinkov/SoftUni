function autoEng(input_arr){

    let cars = new Map();
    for (let row of input_arr) {
        let [brand, model, count] = row.split(/ \| /g).filter(x=>x);
        count = Number(count);

        if(!cars.has(brand)){
            cars.set(brand, new Map());
            cars.get(brand).set(model, count);
        }
        else{
            if(!cars.get(brand).has(model)){
                cars.get(brand).set(model, count);
            }
            else{
                cars.get(brand).set(model, cars.get(brand).get(model)+count);
            }
        }
    }
    for (let [brand, stats] of cars) {
        console.log(brand);
        for (let [model, count] of stats) {
            console.log(`###${model} -> ${count}`)
        }
    }
}

autoEng(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']);