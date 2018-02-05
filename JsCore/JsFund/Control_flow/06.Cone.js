
function cone(r, h){

    console.log('volume = ' +(Math.PI * r * r * h / 3));
    console.log('area = '+(Math.PI*r*(r+Math.sqrt(h*h +r*r))));

}

cone(3,5);