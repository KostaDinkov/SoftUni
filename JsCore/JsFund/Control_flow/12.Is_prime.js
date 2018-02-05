function is_prime (number){

    let is_prime = true;
    let limit = Math.ceil(Math.sqrt(number));
    if(number < 2) return false ;
    for(let i = 2; i <limit; i++){
        if(number % i == 0 || number == limit){
            is_prime = false;
        }
    }
    return is_prime;
}

console.log(is_prime(-5));