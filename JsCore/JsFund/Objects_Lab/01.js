function townsToJson(townsArr){

    let towns = [];
    for (let i = 1; i < townsArr.length; i++) {
        let tokens = townsArr[i].split("|").filter(val=>val).map(val=> val.trim());
        towns.push({Town:tokens[0],Latitude:Number(tokens[1]),Longitude:Number(tokens[2])})
    }
    console.log(JSON.stringify(towns));
}

townsToJson(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);