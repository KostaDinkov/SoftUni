class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this.online = false;
    }

    set online(value){
        this._online = (value);
        if(value){
            if(this._$title) this._$title.addClass('online');
        }
        else{
            if(this._$title) this._$title.removeClass('online');
        }
    }
    get online(){
        return this._online;
    }


    render(id) {

        this._$article = $('<article>');
        this._$title = $('<div class="title">').text(`${this.firstName} ${this.lastName}`)
            .append($('<button>&#8505;</button>').on('click', this.toggleInfo));
        this._$info = $(`<div class="info" style="display: none;">
                        <span>&phone; ${this.phone}</span>
                        <span>&#9993; ${this.email}</span>
                    </div>`);
        this._$article.append(this._$title);
        this._$article.append(this._$info);
        $("#" + id).append(this._$article);
        this.online = this.online;


    }

    toggleInfo(e) {
        console.log($(e.target).parent().next('.info').toggle())
    }
    get template() {
        return `<article>
                    <div class="title">${this.firstName} ${this.lastName}<button>&#8505;</button></div>
                    
                </article>`
    }
}

let contacts = [
    new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
];

contacts.forEach(c => c.render('main'));
setTimeout(() => contacts[1].online = true, 2000);

setTimeout(() => contacts[1].online = false, 4000);

