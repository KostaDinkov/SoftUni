function wordCount(text,word){

    let re_string = `\\b${word}\\b`;
    let re = RegExp(re_string,'gi');

    let matches = text.match(re);
    console.log(matches==null?0:matches.length);

}
wordCount('There was one. Therefore I bought it. I wouldn’t buy it otherwise.','blah');