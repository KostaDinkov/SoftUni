function notation(arr) {
    let operations = {
        '+': ((a, b) => a + b),
        '-': ((a,b)=> a-b),
        '/': ((a,b) =>a/b),
        '*': ((a,b)=> a*b)
    };
    let numbers = [];

    for (let el of arr) {
        if (Number.isInteger(el)) {
            numbers.push(el);
        }
        else {
            let b=numbers.pop();
            let a=numbers.pop();
            if(!a || !b){
                console.log("Error: not enough operands!");
                return;
            }
            let func = operations[el];

            numbers.push(func(a,b));
        }
    }
    if(numbers.length>1){
        console.log('Error: too many operands!');
        return;
    }
    console.log(numbers[0]);
}
