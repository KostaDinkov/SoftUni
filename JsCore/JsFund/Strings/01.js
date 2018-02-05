function printLetters(string){
    let result = string.split('');
    result.forEach((e,i)=>console.log(`str[${i}] -> ${e}`));
}

printLetters('Hello, World!');
