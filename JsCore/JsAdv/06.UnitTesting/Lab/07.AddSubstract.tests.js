let expect = require('chai').expect;
let createCalculator = require('./07.AddSubstract').createCalculator;


describe('Tests for createCalculator function',function(){
    let calc;
    beforeEach(function(){
        calc = createCalculator();
    });
    describe('Test for normal input',function(){
        it('Should return 0 after get()',function(){
            expect(calc.get()).to.be.equal(0);
        });
        it('Should return 5 after add(2), add(3), get()',function(){
            calc.add(2);
            calc.add(3);
            expect(calc.get()).to.be.equal(5);
        });
        it('Should return -5 after add(2), add(3), get()',function(){
            calc.subtract(2);
            calc.subtract(3);
            expect(calc.get()).to.be.equal(-5);
        });
        it('Should return 4.2 after add(5.3), subtract(1.1)',function () {
            calc.add(5.3);
            calc.subtract(1.1);
            expect(calc.get()).to.be.closeTo(4.2,0.000001);
        });
        it('Should return 2 after add(10), subtract(7), add("-2"); subtract(-1)',function () {
            calc.add(10);
            calc.subtract(7);
            calc.add('-2');
            calc.subtract(-1);
            expect(calc.get()).to.be.equal(2);
        });
        it('Should return NaN after add("hello")',function () {
            calc.add("Hello");
            expect(calc.get()).to.be.NaN;
        });
        it('Should return NaN after subtract("hello")',function () {
            calc.subtract("Hello");
            expect(calc.get()).to.be.NaN;
        });
   })
});