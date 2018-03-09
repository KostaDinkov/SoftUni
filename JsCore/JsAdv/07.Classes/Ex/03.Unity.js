class Rat{
    constructor(name){
        this.name = name;
        this.unitedRats = [];
    }

    unite(other){

        if(other.constructor.name === 'Rat'){
            this.unitedRats.push(other);
        }

    }
    getRats(){
        return this.unitedRats;
    }

    toString(){
        let result = this.name;
        for (let rat of this.unitedRats) {
            result+=`\n##${rat.name}`
        }
        return result;
    }
}

let test = new Rat("Pesho");
console.log(test.toString()); //Pesho

console.log(test.getRats()); //[]

test.unite(new Rat("Gosho"));
test.unite(new Rat("Sasho"));
console.log(test.getRats());


console.log(test.toString());
