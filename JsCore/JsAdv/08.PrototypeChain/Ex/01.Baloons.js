function solve() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }
    }

    class PartyBalloon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            this.ribbon = {color: ribbonColor, length: ribbonLength};

        }

        get ribbon() {
            return this._ribbon;
        }

        set ribbon(value) {
            this._ribbon = value;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength);
            this.text = text;
        }

        set text(value) {
            this._text = value;
        }

        get text() {
            return this._text;
        }
    }
    return {Balloon,PartyBalloon,BirthdayBalloon};
}