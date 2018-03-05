function sum(arr) {
    let sum = 0;
    for (num of arr)
        sum += Number(num);
    return sum;
}
let expect = require('chai').expect;

describe('Sum function', function(){
   it('Should return 6 for [1,2,3].',function(){
        expect(sum([1,2,3])).to.be.equal(6);
   });
   it('Should sum decimals correctly.',function(){
       expect(sum([1.1,2.2])).to.be.closeTo(3.3,0.000001);
   });
   it('Should return 0 for empty array',function(){
       expect(sum([])).to.be.equal(0);
   });
   it('Should return 1 for [1]',function(){
       expect(sum([1])).to.be.equal(1);
   });
   it('Should return NaN for non numeric array',function(){
       expect(sum([1,'two','3'])).to.be.NaN;
   })
});