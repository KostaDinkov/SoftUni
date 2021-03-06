function extendClass(classToExtend){

    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function(){
        return `I am a ${this.species}. ${this.toString()}`
    }

}

class Person{
    constructor(name,email){
        this.name = name;
        this.email = email;
    }
}

extendClass(Person);
console.log(Person.toString());
console.log(Person.prototype);