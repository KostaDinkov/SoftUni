function colorful_numbers(n){

    result = '<ul>\n';
    for(let i = 1; i<=n;i++){

        let color = i%2==0?'blue':'green';
        result += `  <li><span style=\'color:${color}\'>${i}</span></li>\n`

    }
    result += '</ul>'
    return result;
}

console.log(colorful_numbers(5));