function countWords(text_arr){
    let result={};
    text_arr[0]
        .split(/\W/g)
        .filter(x=>x)
        .forEach(x=> result[x]==undefined?result[x]=1:result[x]+=1);
    console.log(JSON.stringify(result))

}

countWords(['Far too slow, you\'re far too slow.']);