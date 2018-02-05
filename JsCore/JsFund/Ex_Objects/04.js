

function catalogue(str_arr){

    let catalogue = new Map();
    for (let str of str_arr) {
        let [name, price] = str.split(' : ').filter(x=>x);
        price = Number(price);
        let letter = name[0].toUpperCase();
        if(!catalogue.has(letter)){
            catalogue.set(letter,new Map());
            catalogue.get(letter).set(name, price);
        }
        else{
            catalogue.get(letter).set(name,price);
        }

    }
    let sortedCatalogue = new Map([...catalogue.entries()].sort());
    for (let [letter,map] of sortedCatalogue) {
        sortedCatalogue.set(letter,new Map([...map.entries()].sort()));
    }
    for (let [letter, map] of sortedCatalogue) {
        console.log(letter);
        for (let [product, price] of map) {
            console.log(`  ${product}: ${price}`)
        }
    }
}
catalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);