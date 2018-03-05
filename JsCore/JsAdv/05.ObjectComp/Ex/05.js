(function solve() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return str + this;
        }
        else return this.toString();
    };
    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this.toString() + str;
        }
        else return this.toString();
    };
    String.prototype.isEmpty = function () {
        return this.toString().length === 0;
    };
    String.prototype.truncate = function (n) {
        if(this.toString().length<=n){
            return this.toString();
        }
        return getSubstring(this.toString());

        function getSubstring(str) {
            let indexOfSpace = str.lastIndexOf(' ');
            if (n < 4) {
                return '.'.repeat(n);
            }

            if (indexOfSpace < 0) {
                return str.slice(0, n - 3) + '...';
            }
            if (indexOfSpace + 3 <= n) {
                return str.slice(0, indexOfSpace) + '...';
            }
            else {
                return getSubstring(str.slice(0, indexOfSpace))
            }
        }
    };

    String.format = function (string, ...params) {


        let re = new RegExp(/{(\d)}/);
        let match;
        let result = string;
        while ((match = re.exec(result)) !== null) {

            let text = params[Number(match[1])];
            if(!text){
                return result;
            }
            result = result.slice(0,match.index)+ text + result.slice(match.index +3);
        }
        return result;


    }

}());

let str = 'my string';
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
    'quick', 'brown');
console.log(str);
str = String.format('jumps {0} {1}',
    'dog');
console.log(str);

var testString = 'the quick brown fox jumps over the lazy dog';
console.log(testString.truncate(43));

