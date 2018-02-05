function bill(string){

    let items = [];
    let total = 0;
    for (let i = 0; i < string.length; i+=2) {

        items.push(string[i]);
        total += Number(string[i+1])
    }
    let result_str = `You purchased ${items.join(', ')} for a total sum of ${total}`;
    console.log(result_str)

}

bill(['Beer Zagorka', '2.65', 'Tripe soup', '7.80','Lasagna', '5.69']);