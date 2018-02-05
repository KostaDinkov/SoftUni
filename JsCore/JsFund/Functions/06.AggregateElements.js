/**
 *
 * @param {Array} elements_arr
 *
 */
function aggregate(elements_arr){

    console.log(elements_arr.reduce((sum,i)=> sum+i));
    console.log(elements_arr.reduce((invSum,i)=> invSum + (1/i),0));
    console.log(elements_arr.reduce((str, i)=> ""+str+i));
}

aggregate([2, 4, 8, 16]);