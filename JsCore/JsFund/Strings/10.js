function matchAll(string){
    const regex = new RegExp(/[A-Za-z0-9_]+/,"g");

    let match;
    let words = [];

    while ((match = regex.exec(string)) !== null) {
        // This is necessary to avoid infinite loops with zero-width matches
        if (match.index === regex.lastIndex) {
            regex.lastIndex++;
        }

        // The result can be accessed through the `m`-variable.
        match.forEach((m) => words.push(m));
    }
    console.log(words.join("|"));
}

matchAll('_(Underscores) are also word characters');