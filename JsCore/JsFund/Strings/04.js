function extractText(string){
    let results = [];
    let re = new RegExp(/\((.+?)\)/,'g');
    let match;
    while ((match = re.exec(string))!== null){
        results.push(match[1]);
    }

    console.log(results.join(', '))

}

extractText('Rakiya (Bulgarian brandy) is self-made liquor (alcoholic drink)');