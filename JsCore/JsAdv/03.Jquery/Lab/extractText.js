function extractText(){

    let text = [];
    $('ul li').each((i,v)=> text.push(v.textContent));

    $('#result').text(text.join(', '));
}