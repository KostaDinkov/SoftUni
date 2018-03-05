function makeCard(face,suit){
    let suits = {S:'\u2660',H:'\u2665',D:'\u2666',C:'\u2663'};
    let faces = [2,3,4,5,6,7,8,9,10,'J','Q','K','A'];

    if(!faces.includes(face)){
        throw new Error();
    }
    if(!suits.hasOwnProperty(suit)){
        throw new Error();
    }

    return {
        card: face+suits[suit],
        toString: function (){
            return this.card;
        }
    }
}
console.log('' + makeCard('A', 'S'));
console.log('' + makeCard('10', 'H'));
console.log('' + makeCard('1', 'C'));