function splitStr(string, delimiter){

    let chunks = string.split(delimiter);
    chunks.forEach(c=>console.log(c));
}
splitStr('http://platform.softuni.bg','.');