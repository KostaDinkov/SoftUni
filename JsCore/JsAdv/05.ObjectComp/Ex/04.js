function solve(){

    let myObj = {
        extend: function (other){
            let props = Object.keys(other);
            for (let prop of props) {
                if(typeof(other[prop]) ==='function'){
                    this.constructor.prototype[prop] = other[prop];
                }
                else{
                    this[prop] = other[prop];
                }
            }
        }
    };
    return myObj
}

let template = {
    extensionMethod: function () {return true},
    extensionProperty: 'someString'
};

let myObj = solve();
myObj.extend(template);
console.log(myObj);
console.log(Object.getPrototypeOf(myObj));
