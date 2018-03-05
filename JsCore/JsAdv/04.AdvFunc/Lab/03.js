function cp(str_array) {


    let execute = function () {
        let str_result = '';
        return {
            append: (text) => str_result = str_result + text,
            removeStart: (count) => str_result = str_result.slice(Number(count)),
            removeEnd: (count) => str_result = str_result.slice(0, str_result.length - Number(count)),
            print: () => console.log(str_result)

        }
    }();

    for (let command_arg of str_array) {
        let [command, arg] = command_arg.split(' ');
        execute[command](arg);
    }


}


cp(['append hello',
    'append again',
    'removeStart 3',
    'removeEnd 4',
    'print']
);
