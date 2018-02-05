function figure(n){

    let repeat_count = Math.floor((n-3)/2);
    if(repeat_count<0) repeat_count = 0;
    if(n == 2){
        console.log('+++');
        return;
    }
    let vertical_pattern = "+"+"|".repeat(repeat_count)+'+'+"|".repeat(repeat_count)+'+';
    //print plus row
    let row1 = '+'+"-".repeat(n-2)+"+"+"-".repeat(n-2)+"+";
    let row2 = '|'+" ".repeat(n-2)+"|"+" ".repeat(n-2)+"|";

    for (let symbol of vertical_pattern) {
        if(symbol == '+') console.log(row1);
        if(symbol == '|') console.log(row2);
    }
}


figure(2);