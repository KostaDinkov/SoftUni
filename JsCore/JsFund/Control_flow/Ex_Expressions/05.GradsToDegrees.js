function gradsToDegrees(grads){

    if(grads <0){
        grads = 400 -Math.abs(grads%400)
    }
    let degrees =  (grads * (9/10))%360;

    console.log(degrees);
}


gradsToDegrees(850);

