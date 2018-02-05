function variableNames(text){

    let re = RegExp(/\b_[a-zA-Z0-9]+\b/,'g');
    let variables = [];
    let match;
    while((match = re.exec(text))!==null){

        variables.push(match[0].substr(1))
    }
    console.log(variables.join(','))

}
variableNames('__invalidVariable _evenMoreInvalidVariable_ _validVariable\tvalidVariable');