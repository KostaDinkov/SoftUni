function cooking(com_arr){
    let chop= (num)=>num/2;
    let dice=(num) =>Math.sqrt(num);
    let spice = (num)=> num+1;
    let bake = (num)=> num*3;
    let fillet = (num)=> num*0.8;
    let num = com_arr[0];

    for (let i = 1; i < com_arr.length ; i++) {

        num = eval(com_arr[i])(num);
        console.log(num);
    }
}
cooking([9, 'dice', 'spice', 'chop', 'bake', 'fillet']);