function NextDay(year, month, day){

    let date = new Date(year, month-1, day, 0,0,0);
    //console.log(date);

    let new_date = new Date(date);
    new_date.setDate(date.getDate()+(1));
    let dd = new_date.getDate();
    let mm= new_date.getMonth()+1 ;
    let y = new_date.getFullYear();

    return `${y}-${mm}-${dd}`;
}

console.log(NextDay(2016, 9, 30));
