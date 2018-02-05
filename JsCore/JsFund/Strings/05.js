function aggregateTable(table){
    let total = 0;
    let towns = [];
    for (let i = 0; i < table.length; i++) {

        let town = table[i].split('|');
        town = town.filter(val=>val);
        towns.push(town[0].trim());
        total += Number(town[1]);

    }
    console.log(towns.join(', '));
    console.log(total);
}

aggregateTable(['| Sofia           | 300',
    '| Veliko Tarnovo  | 500',
    '| Yambol          | 275']
);