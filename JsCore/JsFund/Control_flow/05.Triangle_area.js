function triangle_area(a,b,c){

    let p = (a+b+c)/2;
    console.log(Math.sqrt(p*(p-a)*(p-b)*(p-c)));
}
triangle_area(2,3.5,4);
