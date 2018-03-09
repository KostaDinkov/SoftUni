let result = (function () {

    class Textbox {
        constructor(selector, regex) {
            let context = this;
            this._elements = $(selector);
            this._elements.on('input', function () {
                Textbox.updateValues(this.value, context)
            });
            this._invalidSymbols = regex;
        }

        isValid() {

            return !this._invalidSymbols.test(this.value);
        }

        get value() {
            return this._value;
        }

        set value(val) {

            Textbox.updateValues(val, this);
        }

        get elements() {
            return this._elements;
        }

        static updateValues(value, viewModel) {
            viewModel._value = value;
            viewModel.elements.each(function (i, v) {
                $(v).val(value);

            });

        }
    }

    class Form {
        constructor(...textBoxes) {
            this._element = $("<div class='form'></div>");
            this._textboxes = [];
            this.textboxes = textBoxes;


        }

        set textboxes(value) {
            for (let element of value) {
                if (element.constructor.name !== "Textbox") {
                    throw Error('One or more of the arguments were not of type "Textbox"');
                }
            }
            for (let element of value) {
                this._textboxes.push(element);
                this._element.append(element.elements);
            }
        }
        get textboxes(){
            return this._textboxes;
        }
        submit(){
            let allValid = true;
            for (let tbox of this.textboxes) {

                if (tbox.isValid()){
                    tbox.elements.each(function(i,el){
                        $(el).css('border', '2px solid green')
                    })
                }
                else{
                    tbox.elements.each(function(i,el){
                        $(el).css('border', '2px solid red')
                    });
                    allValid = false;
                }
            }
            return allValid;
        }

        attach(selector) {
            $(selector).append(this._element)
        }
    }


    return {
        Textbox: Textbox,
        Form: Form
    }
}());

let Textbox = result.Textbox;
let Form = result.Form;
let username = new Textbox("#username", /[^a-zA-Z0-9]/);
let password = new Textbox("#password", /[^a-zA-Z]/);
username.value = "username";
password.value = "password2";
let form = new Form(username, password);
form.attach("#root");
form.submit();

