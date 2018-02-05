function cityMarkets(strArr){

    let towns = new Map();
    for (let str of strArr) {
        let [town, product, count, price] = str.split(/[\->:]/).filter(x=>x).map(x=>x.trim());
        if(towns.has(town)){
           if(towns.get(town).has(product)){

               towns.get(town).get(product).count +=Number(count);
           }
           else{
               towns.get(town).set(product,{count:Number(count),price: Number(price)});
           }
        }
        else{
            towns.set(town,  new Map(Object.entries({[product]:{count:Number(count), price:Number(price)}})))
        }

    }
    for (let [town, products] of towns) {
        console.log(`Town - ${town}`);
        for (let [product, stats] of products) {
            let count = stats.count;
            let price = stats.price;
            console.log(`$$$${product} : ${count*price}`)

        }
    }

}

cityMarkets(['Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3']
    );