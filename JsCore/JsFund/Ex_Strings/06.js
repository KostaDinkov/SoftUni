function captureNumbers(text){

    let re = RegExp(/\d+/,'g');
    let match;
    let numbers=[];
    while((match = re.exec(text))!==null){
        numbers.push(match[0])
    }
    console.log(numbers.join(' '));
}
captureNumbers('123a456\n' +
    '789b987\n' +
    '654c321\n' +
    '0\n')