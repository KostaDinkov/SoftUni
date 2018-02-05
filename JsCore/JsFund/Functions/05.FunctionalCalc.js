function solve(a, b, operation) {

    let operations = {"+": sum, "-": substract, "*": multiply, "/": divide};

    function applyOperation(a, b, op) {
        return op(a, b);
    }

    return applyOperation(a, b, operations[operation]);


    function sum(a, b) {
        return a + b;
    }

    function substract(a, b) {
        return a - b;
    }

    function multiply(a, b) {
        return a * b;
    }

    function divide(a, b) {
        return a / b;
    }
}

console.log(solve(18, -1, "*"));
