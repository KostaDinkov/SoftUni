function solveQuadratic(a,b,c){

    let d = b*b - 4*a*c;
    if (d<0){
        console.log('No');
    }
    else if (d == 0){

        console.log(-b/(2*a));
    }
    else{
        let x1 = (-b + Math.sqrt(d))/(2*a);
        let x2 = (-b - Math.sqrt(d))/(2*a);
        console.log(Math.min(x1,x2));
        console.log(Math.max(x1,x2));
    }
}

solveQuadratic(5,2,1);
