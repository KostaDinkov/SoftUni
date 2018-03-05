function validate() {

    $('#submit').on('click', checkFields);
    let isCompany = false;

    $('#company').on('change',function () {
        // language=JQuery-CSS
        $("#companyInfo").toggle(this.checked);
        isCompany = this.checked;
    });
    let $username = $('#username');
    let $email = $('#email');
    let $password = $('#password');
    let $confPassword = $('#confirm-password');
    let $companyNumber = $('#companyNumber');

    function checkFields(ev) {
        ev.preventDefault();



        let isValidUser = validateUsername($username.val());
        changeCss($username, isValidUser);

        let isValidMail = validateEmail($email.val());
        changeCss($email, isValidMail);

        let isValidPassword = validatePassword($password.val(), $confPassword.val());
        changeCss($password, isValidPassword);
        changeCss($confPassword, isValidPassword);
        let isValidCompany;
        if (isCompany) {
            isValidCompany = validateCompany($companyNumber.val());
            changeCss($companyNumber, isValidCompany)
        }
        let allValid = (isValidUser
                        && isValidMail
                        && isValidPassword
                        && ((isCompany && isValidCompany)||(!isCompany)));
        console.log(allValid);
        $('#valid').toggle(allValid);


    }

    function changeCss(jqueryObj, isValid) {
        if (isValid) {

            jqueryObj.css('border-color', '');
        }
        else {
            jqueryObj.css('border-color', 'red');
        }
    }

    function validateUsername(text) {

        let re = new RegExp(/^[a-zA-Z0-9]{3,20}$/);
        return re.test(text);

    }

    function validateEmail(text) {
        let re = new RegExp(/^\w+@\w*\..*?$/);
        return re.test(text);
    }

    function validatePassword(p1, p2) {
        let re = new RegExp(/^\w{5,15}$/);
        return (re.test(p1) && p1 === p2)

    }

    function validateCompany(text) {
        let companyNumber = Number(text);
        if (isNaN(companyNumber)) {
            return false;
        }
        return (companyNumber >= 1000 && companyNumber <= 9999);
    }
}
