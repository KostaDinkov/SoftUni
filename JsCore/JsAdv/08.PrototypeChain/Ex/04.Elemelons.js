function solve(){
    class Melon{
        static get elements(){ return {Water:'Water',Fire:'Fire',Earth:'Earth',Air:'Air'}};

        constructor(weight, melonSort){
            if(new.target === Melon){
                throw new TypeError('Abstract class cannot be instantiated directly');
            }
            this.weight = weight;
            this.melonSort = melonSort;

            this._element = '';
        }

        get elementIndex(){
            return this.weight * this.melonSort.length;
        }
        toString(){
            return `Element: ${this._element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`
        }
    }
    class Watermelon extends Melon{
        constructor(weight,melonSort){
            super(weight,melonSort);
            this._element = Melon.elements.Water;
        }
    }
    class Firemelon extends Melon{
        constructor(weight,melonSort){
            super(weight,melonSort);
            this._element = Melon.elements.Fire;
        }

    }
    class Earthmelon extends Melon{
        constructor(weight,melonSort){
            super(weight,melonSort);
            this._element = Melon.elements.Earth;
        }
    }
    class Airmelon extends Melon{
        constructor(weight,melonSort){
            super(weight,melonSort);
            this._element = Melon.elements.Air;
        }
    }
    class Melolemonmelon extends Watermelon{
        constructor(weight,melonSort){
            super(weight,melonSort);
            this._currentElement = 0;
            this.morph();

        }

        morph(){

            this._element = Melon.elements[Object.keys(Melon.elements)[this._currentElement]];
            this._currentElement ++;
            if(this._currentElement>= Object.keys(Melon.elements).length){
                this._currentElement =0;
            }
        }

    }
    return {Melon,Watermelon,Firemelon,Earthmelon,Airmelon,Melolemonmelon};
}

let melons = solve();
let wm = new melons.Watermelon(1,'Extra');
console.log(melons.Watermelon.elements);


