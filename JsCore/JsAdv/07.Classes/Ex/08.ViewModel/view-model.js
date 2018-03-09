class Textbox {
    constructor(selector, regex){
        let context = this;
        this._elements = $(selector);
        this._elements.on('input', function(){Textbox.updateValues(this.value, context) });
        this._invalidSymbols = regex;
    }
    isValid(){

        return !this._invalidSymbols.test(this.value);
    }

    get value(){
        return this._value ;
    }
    set value(val){

        Textbox.updateValues(val,this);
    }

    get elements(){
        return this._elements;
    }

    static updateValues(value, viewModel){
        viewModel._value = value;
        viewModel.elements.each(function(i,v){
            $(v).val(value);

        });

    }
}




