$(function () {

    //login();

    let database = firebase.database();
    let $phonebook = $('#contacts');

    database.ref('contacts/').on('value', function (snapshot) {
        displayContacts(database,$phonebook,snapshot.val());
    });


    $('#btnCreate').on('click', function () {
        let contactData = getContactData();
        if(contactData){
            writeUserData(database, contactData.name, contactData.phone);

        }
    });


});

function login() {
    let email = '...';
    let password = '...';
    firebase.auth().signInWithEmailAndPassword(email, password).catch(function (error) {
        // Handle Errors here.
        let errorCode = error.code;
        let errorMessage = error.message;
        console.log(errorCode, errorMessage);
        // ...
    });
}

function displayContacts(database,$element, snapshot) {
    $element.empty();
    for (let key in snapshot) {
        if (key) {
            $element.append($(`<tr><td>${snapshot[key].username}</td><td>${snapshot[key].phone}</td></tr>`)
                .append('<td><button>Delete</button></td>').on('click',function(){
                    database.ref('contacts/'+key).remove();
                }));
        }

    }
}

function getContactData() {
    let $name = $('#person');
    let $phone = $('#phone');

    if ($name.val() && $phone.val()) {
        let name = $name.val();
        let phone = $phone.val();

        $name.val('');
        $phone.val('');
        return{name: name, phone:phone};
    }
    return null;
}

function writeUserData(database, name, phone) {
    let data =
        {
            username: name,
            phone: phone,
        };
    let entryKey = database.ref().child('contacts').push().key;
    database.ref('contacts/'+entryKey).set(data);
    return entryKey;
}