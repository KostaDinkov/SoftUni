function expressionSplit(expr){

    const regex = new RegExp(/[^,()\s;'\\\.]+/,"g");

    let match;
    let parts = [];

    while ((match = regex.exec(expr)) !== null) {
        // This is necessary to avoid infinite loops with zero-width matches
        if (match.index === regex.lastIndex) {
            regex.lastIndex++;
        }

        match.forEach((m) => parts.push(m));
    }
    console.log(parts.join("\n"));
}

expressionSplit('let sum = 1 + 2;if(sum > 2){\tconsole.log(sum);}');
