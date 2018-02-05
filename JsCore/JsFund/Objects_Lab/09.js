function lowestPrice(products_arr){

    let result = '';
    let products = new Map();
    for (let entry of products_arr) {
        let [town,product,price] = entry.split(/ \| /g);

        if(!products.has(product)){
            products.set(product,new Map());

        }
        products.get(product).set(town, Number(price));

    }
    for (let [product, towns] of products) {
        let minPrice = Number.MAX_VALUE;
        let minPriceTown = '';
        for (let [town, price] of towns) {
            if (price < minPrice) {
                minPrice = price;
                minPriceTown = town;
            }
        }

        console.log(`${product} -> ${minPrice} (${minPriceTown})`);
    }

}

let test1 =
    ['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'];

let test2=
    ['Sofia City | Audi | 100000' ,
    'Sofia City | BMW | 100000' ,
    'Sofia City | Mitsubishi | 10000' ,
    'Sofia City | Mercedes | 10000' ,
    'Sofia City | NoOffenseToCarLovers | 0' ,
    'Mexico City | Audi | 1000',
    'Mexico City | Audi | 100000',
    'Mexico City | BMW | 99999'];

lowestPrice(test2);



if (typeof exports !== 'undefined') {
    exports.testFunc = lowestPrice
}