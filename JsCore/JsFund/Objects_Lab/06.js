function countWords(text_arr){
    let result= new Map();
    text_arr[0]
        .split(/\W/g)
        .filter(x=>x)
        .map(x=>x.toLowerCase())
        .forEach(x=>result.has(x)?result.set(x,result.get(x)+1):result.set(x,1));
    let sortedByKey = Array.from(result.keys()).sort();
    for (let key    of sortedByKey) {
        console.log(`'${key}' -> ${result.get(key)} times`);
    }

}

countWords(['Far too slow, you\'re far too slow.']);