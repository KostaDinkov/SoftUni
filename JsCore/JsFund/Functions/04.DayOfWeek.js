function dayOfWeek(day){

    let days = ['monday', 'tuesday','wednesday', 'thursday','friday','saturday','sunday'];
    let dayNumber = days.indexOf(day.toLowerCase())+1;
    return dayNumber<1?"error":dayNumber;
}

console.log(dayOfWeek('sunday'));