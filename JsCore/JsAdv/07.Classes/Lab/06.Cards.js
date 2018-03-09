let result = (function () {
    let suits = {
        'SPADES': '♠',
        'HEARTS': '♥',
        'DIAMONDS': '♦',
        'CLUBS': '♣'
    };

    class Card{
        constructor(face, suit){
            this.face=face;
            this.suit = suit;
        }

        set face(value){
            if(!Card.faces.includes(value)){
                throw Error('Invalid card face!')
            }
            this._face = value;
        }
        get face(){
            return this._face;
        }

        set suit(value){

            let suitValues =[];
            for(let key of Object.keys(suits)){
                suitValues.push(suits[key]);
            }
            if(!suitValues.includes(value)){
                throw new Error('Invalid card suit!');
            }


            this._suit = value;
        }
        get suit(){
            return this._suit;
        }

        static get faces(){
            return ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
        }

        toString(){
            return `${this._face}${this._suit}`;
        }
    }

    return {Suits: suits, Card:Card};
}());

let Card = result.Card;
let Suits = result.Suits;

let card = new Card('Q',Suits.CLUBS);
console.log(card.toString());
card.face = 'A';
card.suit = Suits.DIAMONDS;
console.log(card.toString());

//let card2 = new Card('1', Suits.DIAMONDS);
let card3 = new Card("2",Suits.Pesho);