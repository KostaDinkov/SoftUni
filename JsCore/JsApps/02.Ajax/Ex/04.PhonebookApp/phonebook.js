function attachEvents() {

    //app settings
    let url = 'https://phonebook-nakov.firebaseio.com/phonebook';

    //bind elements
    let $phoneBookList = $('#phonebook');
    let $personInput = $('#person');
    let $phoneInput = $('#phone');

    //bind buttons
    $('#btnCreate').click(createContact);
    $('#btnLoad').click(loadContacts);

    function createContact() {
        let postContactsUrl = url + '.json';
        let person = $personInput.val();
        let phone = $phoneInput.val();
        if (!person || !phone) {
            return;
        }
        let contactData = {
            person: person,
            phone: phone
        };

        $.ajax({
            url: postContactsUrl,
            method: 'POST',
            data: JSON.stringify(contactData)
        }).then(function(){
            $personInput.val('');
            $phoneInput.val('');
            loadContacts()
        });
    }

    function loadContacts() {
        let getContactsUrl = url + '.json';
        $phoneBookList.empty();
        $.ajax(getContactsUrl).done(displayContacts);
    }

    function deleteContact(id) {
        let deleteUrl = url + `/${id}.json`;
        $.ajax({
            url: deleteUrl,
            method: 'DELETE'
        }).then(loadContacts);
    }

    function displayContacts(data) {
        for (let key in data) {
            $phoneBookList
                .append($(`<li>${data[key].person}: ${data[key].phone}</li>`)
                    .append($('<button>Delete</button>')
                        .on('click', function () {
                            deleteContact(key)
                        })))
        }
    }

}