function attachEvents() {

    //login to firebase
    let email = 'k.v.dinkov@gmail.com';
    let password = 'sunshine';

    firebase.auth().signInWithEmailAndPassword(email, password).catch(function (error) {
        // Handle Errors here.
        var errorCode = error.code;
        var errorMessage = error.message;

    });

    //setup db
    let db = firebase.database();
    let messengerRef = db.ref('messenger/');

    //listen for value changes in the messenger section
    //and refresh the textarea automatically
    messengerRef.on('value', function (snapshot) {
        uptadeVeiew($messagesTextArea, snapshot.val());
    });

    //bind elements
    let $messagesTextArea = $('#messages');
    let $authorInput = $('#author');
    let $msgInput = $('#content');

    $('#submit').on('click', function () {
        submitMsg()
    });

    //when enter is pressed inside the msg input
    //submit the message
    $msgInput.keyup(function (e) {
        if (e.key == 'Enter') {
            submitMsg();
        }
    });

    function submitMsg() {
        let msg = {
            author: $authorInput.val(),
            content: $msgInput.val(),
            timestamp: Date.now()
        };
        db.ref('messenger/').push(msg);
        $msgInput.val('');
    }

    function uptadeVeiew(textArea, data) {
        let allMsgStr = [];
        for (let msg in data) {
            allMsgStr.push(`${data[msg].author}: ${data[msg].content}`);
        }
        textArea.val(allMsgStr.join('\n'));
    }
}