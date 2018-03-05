function printDeckOfCards(cards){

    function makeCard(face,suit){
        let suits = {S:'\u2660',H:'\u2665',D:'\u2666',C:'\u2663'};
        let faces = ['2','3','4','5','6','7','8','9','10','J','Q','K','A'];

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
    let result = [];
    for (let card of cards) {
        let face = card.slice(0,card.length-1);
        let suit = card[card.length-1];
        try{
            result.push(makeCard(face,suit).toString());
        }
        catch (err){
            console.log(`Invalid card: ${card}`);
            return;
        }
    }
    console.log(result.join(' '));
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);