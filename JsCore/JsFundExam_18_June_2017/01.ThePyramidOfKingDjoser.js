function pyramid(base, inc) {

    let currentRow = 0;
    let total_stone = 0;
    let total_marble = 0;
    let total_lapis = 0;
    let total_gold = 0;

    while (base > 0) {
        currentRow++;
        let rowArea = base * base;
        if(rowArea ==1 || rowArea==4){
            total_gold += rowArea*inc;
            break;
        }
        let row_stone = ((base - 2) * (base - 2))*inc;
        total_stone+=row_stone;

        if (currentRow % 5 === 0) {
            let row_lapis = rowArea*inc - row_stone;
            total_lapis +=row_lapis ;
        }
        else{
            let row_marble = rowArea*inc - row_stone;
            total_marble += row_marble;
        }
        base = base-2;

    }
    console.log(`Stone required: ${Math.ceil(total_stone)}`);
    console.log(`Marble required: ${Math.ceil(total_marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(total_lapis)}`);
    console.log(`Gold required: ${Math.ceil(total_gold)}`);
    console.log(`Final pyramid height: ${Math.floor(currentRow*inc)}`)

}

pyramid(1,1);