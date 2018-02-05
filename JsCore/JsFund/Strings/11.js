function validateEmail(email){

    let re = RegExp(/\b[a-zA-Z0-9]+@[a-z]+\.[a-z]+\b/,"g");
    let result = '';
    re.test(email)?result = "Valid":result = 'Invalid';
    console.log(result);
}

validateEmail('invalid@emai1.bg');