function FigureArea(w,h,W,H){

    return ((w*h + W*H)-Math.min(w,W)*Math.min(h,H));
}

console.log(FigureArea(2, 4, 5, 3));