class CheckingAccount {

    /**
     * @constructor
     * @param {string} id
     * @param {string} email
     * @param {string} firstName
     * @param {string} lastName
     */
    constructor(id, email, firstName, lastName) {
        this.clientId = id;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;

    }

    set clientId(value) {
        let re = new RegExp(/^\d{6}$/);
        if (!re.test(value)) {
            throw new TypeError('Client ID must be a 6-digit number')
        }
        this._clientId = value;
    }

    get clientId() {
        return this._clientId;
    }

    set email(value) {
        let re = new RegExp(/^\w+@[\w.]+$/);
        if (!re.test(value)) {
            throw new TypeError('Invalid e-mail')
        }

        this._email = value;
    }

    get email() {
        return this._email;
    }

    set firstName(value) {
        CheckingAccount.checkName(value, 'First');
        this._firstName = value;
    }

    get firstName() {
        return this._firstName;
    }

    set lastName(value) {
        CheckingAccount.checkName(value, 'Last');
        this._lastName = value;
    }

    get lastName() {
        return this._lastName;
    }

    static checkName(name, first_last) {
        if (name.length < 3 || name.length > 20) {
            let length_msg = `${first_last} name must be between 3 and 20 characters long`;
            throw new TypeError(length_msg);
        }
        let re = new RegExp(/^[a-zA-Z]+$/);

        if (!re.test(name)) {
            let latin_msg =`${first_last} name must contain only Latin characters`;
            throw new TypeError(latin_msg);
        }
    }
}

let acc = new CheckingAccount('423415', 'petkan@another.co.uk', 'Petkan', 'Draganov');