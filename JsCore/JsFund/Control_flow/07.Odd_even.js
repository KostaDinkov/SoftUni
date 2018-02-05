function odd_even(n){

    if(n % 2 == 0){
        console.log("even");
    }
    else if (n != Math.ceil(n)){
        console.log('invalid');
    }
    else{
        console.log('odd');
    }
}

odd_even(1.4);