function chessboard(n){

    let chessboard = '<div class=\"chessboard\">\n';
    for(let row = 0; row <n; row++){
        chessboard +='  <div>\n';
        for(let col = 0; col<n;col++){
            let color = ((row +col) % 2 == 0)?'black':'white';
            chessboard +=`    <span class="${color}"></span>\n`
        }
        chessboard+='  </div>\n'
    }

    chessboard +='</div>'
    return chessboard;
}

console.log(chessboard(4));