function inch_to_feet(number){

    let whole = Math.floor(number / 12);
    let decimal = number % 12;
    console.log(`${whole}'-${decimal}"`);
}

inch_to_feet(11);