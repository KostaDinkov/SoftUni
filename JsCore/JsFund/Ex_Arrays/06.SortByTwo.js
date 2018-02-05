function sortByTwo(arr){
    arr.sort(comparator);
    console.log(arr.join('\n'));

    function comparator(a,b){

        if(a.length < b.length){
            return -1;
        }
        else if(a.length == b.length){
            if(a.toLowerCase()>b.toLowerCase()){
                return 1;
            }
            else if( a.toLowerCase()==b.toLowerCase()){
                return 0;
            }
            else{
                return -1;
            }
        }
        else{
            return 1;
        }

    }
}
sortByTwo(["Isacc","Theodor","Jack","Harrison","George"]);
