function composeImgTag(data){
    let filePath = data[0];
    let altText = data[1];

    console.log(`<img src="${filePath}" alt="${altText}">`);
}

composeImgTag(['smiley.gif', 'Smiley Face'])