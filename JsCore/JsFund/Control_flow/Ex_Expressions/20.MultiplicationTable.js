function multiplicationTable(n){

    let result = '<table border=\'1\'>\n';

    for( let row = 0; row<=n; row++){
        result +='<tr>';

        for(let col = 0; col<=n; col++){
            let cell_tag ='td';
            let cell_value= row*col;
            //heading row
            if(row == 0 && col== 0 ) {
                cell_value = 'x';
                cell_tag = 'th';
            }
            else if (col == 0) {
                cell_value = row;
                cell_tag = 'th';
            }
            else if (row == 0) {
                cell_value = col;
                cell_tag = 'th';
            }
            result+=`<${cell_tag}>${cell_value}</${cell_tag}>`;
        }
        result +='</tr>\n';
    }
    result+='</table>';
    console.log(result);
}

multiplicationTable(5);