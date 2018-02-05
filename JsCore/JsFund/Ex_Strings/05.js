function capitalizeWords(string){

    let words = string.split(' ');
    for (let i=0;i<words.length;i++) {
        let result = '';
        result += words[i].charAt(0).toUpperCase();
        result += words[i].substr(1).toLowerCase();
        words[i] = result;
    }
    console.log(words.join(' '));
}
capitalizeWords('Was that Easy? tRY thIs onE for SiZe!');