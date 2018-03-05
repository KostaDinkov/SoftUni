let expect = require('chai').expect;
let isSymmetric = require('./05.js').isSymetric;

describe('Tests for isSymetric functionality', function () {
    describe('Test for valid array arguments',function (){
        it('Should return true for [1,2,3,2,1]', function () {
            expect(isSymmetric([1, 2, 3, 2, 1])).to.be.equal(true);
        });
        it('Should return true for [1,2,2,1]', function () {
            expect(isSymmetric([1, 2, 2, 1])).to.be.equal(true);
        });
        it('Should return false for [2,2,2,1]', function () {
            expect(isSymmetric([2, 2, 2, 1])).to.be.equal(false);
        });
        it("should return false for [-1,2,1]", function() {
            expect(isSymmetric([-1,2,1])).to.be.equal(false);
        });
        it('Should return true for [0]', function () {
            expect(isSymmetric([0])).to.be.equal(true);
        });
        it('Should return true for []', function () {
            expect(isSymmetric([])).to.be.equal(true);
        });
        it('Should return true for [5,\'hi\',{a:5},new Date(),{a:5},\'hi\',5] ', function () {
            expect(isSymmetric([5,'hi',{a:5},new Date(),{a:5},'hi',5] )).to.be.equal(true);
        });
        it('Should return true for [5,\'hi\',{a:5},new Date(),{X:5},\'hi\',5]  ', function () {
            expect(isSymmetric([5,'hi',{a:5},new Date(),{X:5},'hi',5])).to.be.equal(false);
        });
    });


    describe('Test for non array arguments', function () {
        it('Should return false for non array', function () {
            expect(isSymmetric(1)).to.be.equal(false);
        });
        it('Should return false for non array', function () {
            expect(isSymmetric('hello')).to.be.equal(false);

        });
        it('Should return false for non array', function () {
            expect(isSymmetric({a: 1, b: 1})).to.be.equal(false);
        });
        it('Should return false for non array', function () {
            expect(isSymmetric(1,2,3)).to.be.equal(false);
        });
    })
});