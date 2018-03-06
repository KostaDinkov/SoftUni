function validateRequest(request_obj) {

    let props = Object.keys(request_obj);
    const errorText = 'Invalid request header: Invalid ';
    checkMethod();
    checkURI();
    checkVersion();
    checkMessage();
    return request_obj;

    function checkMessage(){
        let message_str = request_obj[props[3]];
        let re = new RegExp(/[<>\\&'"]/);
        if(re.test(message_str) || props[3]!=='message'){
            throw new Error(`${errorText}Message`);
        }
    }

    function checkVersion(){
        let version_str = request_obj[props[2]];
        let validVersions = ['HTTP/0.9','HTTP/1.0','HTTP/1.1','HTTP/2.0'];
        if(!validVersions.includes(version_str) || props[2]!=='version'){
            throw new Error(`${errorText}Version`)
        }
    }
    function checkURI(){
        let uri_str = request_obj[props[1]];
        let re = new RegExp(/^[\w.]+$/);
        if(!uri_str || !re.test(uri_str) || props[1]!=='uri'){
            throw new Error(`${errorText}URI`)
        }
    }


    function checkMethod() {
        let method_str = request_obj[props[0]];
        let validMethods = ['GET', 'DELETE', 'POST', 'CONNECT'];
        if (!validMethods.includes(method_str) || props[0]!=='method') {
            throw new Error(`${errorText}Method`)
        }
    }
}

validateRequest({
    method: 'GET',
    uri: 'kkk jjjj',
    version: 'HTTP/0.8',
    message: ''
});


