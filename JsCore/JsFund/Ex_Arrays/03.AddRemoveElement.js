function addRemove(commands){

    let result = [];
    for (let index in commands) {

        switch (commands[index]){
            case 'add':
                result.push(parseInt(index)+1);
                break;
            case 'remove':
                result.pop()
        }
    }
    if(result.length==0){
        console.log("Empty")
    }
    else {
        console.log(result.join('\n'));
    }
}

addRemove(['remove','remove','remove']);