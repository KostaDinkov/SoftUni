function modifyAverage(num){

    let num_str = String(num);
    let avg = getDigitAvg(num_str);
    while (avg <=5){
        num_str +='9';
        avg = getDigitAvg(num_str);
    }
    console.log(num_str);

    function getDigitAvg(string){

        let sum = 0;
        for (let ch of string) {
            sum += parseInt(ch);
        }
        return sum / string.length;
    }
}

modifyAverage(5835);