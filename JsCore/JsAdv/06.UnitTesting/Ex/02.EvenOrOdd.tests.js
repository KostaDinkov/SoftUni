let isOddOrEven = require('./02.EvenOrOdd').isOddOrEven;
let expect = require('chai').expect;

describe('isOddOrEven',function(){
   it('Should return undefined if argument is not a string',function(){
       expect(isOddOrEven(1)).to.be.undefined;
   });
   it('Should return "even" for "hi"',function(){
       expect(isOddOrEven('hi')).to.be.equal('even');
   });
   it('Should return "odd" for "hello"',function(){
       expect(isOddOrEven('hello')).to.be.equal('odd');
   });

});

