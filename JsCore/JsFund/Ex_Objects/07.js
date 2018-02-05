function usernames(input_arr){

    let names = new Set(input_arr);
    let sorted = new Set(input_arr.sort(customSort));
    function customSort(a,b) {

        if(a.length>b.length){
            return 1;
        }
        else if (a.length===b.length){
            return a<=b?-1:1;
        }
        else {
            return -1;
        }

    }
    sorted.forEach(n=>console.log(n));


}
usernames(['Ashton' ,
    'Kutcher' ,
    'Ariel' ,
    'Lilly' ,
    'Keyden' ,
    'Aizen' ,
    'Billy' ,
    'Braston']);