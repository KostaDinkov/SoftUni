var assert = require('assert');

var testFile = require('../09.js');
//var testFunc = Object.getOwnPropertyNames(testFile);

var expected = 'Sample Product -> 1000 (Sample Town)\n' +
    'Orange -> 2 (Sample Town)\n' +
    'Peach -> 1 (Sample Town)\n' +
    'Burger -> 10 (New York)\n';

let testCase = ['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'];

describe('City Markets Tests', function(){

    it(`returns:\n ${expected}`, function (done){

        let result = testFile.testFunc(testCase);
        assert.equal(result, expected);
        done();
    })
});