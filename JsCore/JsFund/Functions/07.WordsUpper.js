function wordsToUpper(text){
    let words = (String(text).match(/\w+/g));
    words = words.map( w=> w.toUpperCase());
    console.log(words.join(', '))

}

console.log(wordsToUpper('Hi, how are you?'));