function usernames(mails){

    let usernames = [];
    for (let i = 0; i < mails.length; i++) {

        let mail_str = mails[i];
        let user_index =mail_str.indexOf('@');
        let username = mail_str.substr(0,user_index);

        mail_str = mail_str.substr(user_index+1);
        let domains = mail_str.split('.');

        let abrev = '';
        domains.forEach(d=> abrev+=d[0]);
        usernames.push(username+'.'+abrev);


    }
    console.log(usernames.join(', '));

}
usernames(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);