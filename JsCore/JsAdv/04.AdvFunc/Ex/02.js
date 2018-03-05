function solve(){

    let types = new Map();

    for (let arg of arguments) {

        let type = typeof(arg);
        if(!types.has(type)){
            types.set(type, []);
            types.get(type).push(arg);
        }
        else{
            types.get(type).push(arg);
        }
    }
    console.log(types);
}

solve('cat', 42, function () { console.log('Hello world!'); });
