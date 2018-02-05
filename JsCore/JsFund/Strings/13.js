function matchDates(string){
    let re = new RegExp(/\b([0-9]{1,2})-([A-Z][a-z]{2})-([0-9]{4})\b/,'g');

    let match;
    let monthLength = {'Jan': 31,'Feb': 28,'Mar': 31,'Apr': 30,'May': 31,'Jun': 30,'Jul': 31,'Aug': 31,'Sep': 30,'Oct': 31,'Nov': 30,'Dec': 31};
    while((match = re.exec(string))!==null){
        if (match.index === re.lastIndex) {
            re.lastIndex++;
        }

        let date = parseInt(match[1]);
        let month = match[2];
        let year = parseInt(match[3]);


        if(year % 400 == 0 || (year % 100 != 0 && year % 4 == 0)){
            monthLength[1] =29;
        }

         if(date>0 && date <= monthLength[month]){
             console.log(`${match[0]} (Day: ${date}, Month: ${month}, Year: ${year})`);
         }

    }

}
matchDates("01-Jan-1999 is a valid date.So is 28-Feb-2000.I am an awful liar, by the way – Ivo, 28-Sep-2016.");