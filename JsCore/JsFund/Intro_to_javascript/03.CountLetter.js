function CountCh(string, letter)
{
    let count = 0;
    for(let ch of string){
        if(ch == letter){
            count++;
        }
    }
    return count;
}

console.log(CountCh('hello', 'l'));