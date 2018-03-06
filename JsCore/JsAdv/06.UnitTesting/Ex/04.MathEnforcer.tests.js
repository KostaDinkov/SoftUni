let expect = require('chai').expect;
let mathEnforcer = require('./04.MathEnforcer').mathEnforcer;

describe('mathEnforcer', function () {
    describe('"addFive" function', function () {
        it('mathEnforcer should have a function named "addFive", with a single parameter', function () {
            expect(mathEnforcer.hasOwnProperty('addFive')).to.be.true;
            expect(typeof(mathEnforcer.addFive)).to.be.equal('function');
            expect(mathEnforcer.addFive.length).to.be.equal(1);
        });
        it('Should return undefined for ("hello")',function(){
            expect(mathEnforcer.addFive('hello')).to.be.undefined;
        });
        it('Should return 10 for (5)',function(){
            expect(mathEnforcer.addFive(5)).to.be.equal(10);
        });
        it('Should return 0 for (-5)',function(){
            expect(mathEnforcer.addFive(-5)).to.be.equal(0);
        });
        it('Should return 5.5 for (0.5)',function(){
            expect(mathEnforcer.addFive(0.5)).to.be.closeTo(5.5,0.00001);
        });



    });

    describe('"subtractTen" function', function () {

        it('mathEnforcer should have a function named "subtractTen" with a single parameter', function () {
            expect(mathEnforcer.hasOwnProperty('subtractTen')).to.be.true;
            expect(typeof(mathEnforcer.subtractTen)).to.be.equal('function');
            expect(mathEnforcer.subtractTen.length).to.be.equal(1);
        });
        it('Should return undefined for ("hello")',function(){
            expect(mathEnforcer.subtractTen('hello')).to.be.undefined;
        });
        it('Should return 10 for (5)',function(){
            expect(mathEnforcer.subtractTen(5)).to.be.equal(-5);
        });
        it('Should return -20 for (-10)',function(){
            expect(mathEnforcer.subtractTen(-10)).to.be.equal(-20);
        });
        it('Should return -9.5 for (0.5)',function(){
            expect(mathEnforcer.subtractTen(0.5)).to.be.closeTo(-9.5,0.00001);
        });
    });

    describe('"sum" function', function () {

        it('mathEnforcer should have a function named "sum" with two parameters', function () {
            expect(mathEnforcer.hasOwnProperty('sum')).to.be.true;
            expect(typeof(mathEnforcer.sum)).to.be.equal('function');
            expect(mathEnforcer.sum.length).to.be.equal(2);
        });
        it('Should return undefined for ("hello",1)',function(){
            expect(mathEnforcer.sum('hello',1)).to.be.undefined;
        });
        it('Should return undefined for (1,"hello")',function(){
            expect(mathEnforcer.sum(1,'hello')).to.be.undefined;
        });
        it('Should return 10 for (5,5)',function(){
            expect(mathEnforcer.sum(5,5)).to.be.equal(10);
        });
        it('Should return -10 for (-5,-5)',function(){
            expect(mathEnforcer.sum(-5,-5)).to.be.equal(-10);
        });
        it('Should return 10 for (5.5,4.5)',function(){
            expect(mathEnforcer.sum(5.5,4.5)).to.be.closeTo(10,0.00001);
        });

    });
});
