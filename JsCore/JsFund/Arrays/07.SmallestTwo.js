function smallestTwo(num_arr){
    console.log(num_arr.sort((a,b)=> a-b).slice(0,2).join(", "));
}

smallestTwo([3, 0, 10, 4, 7, 3]);