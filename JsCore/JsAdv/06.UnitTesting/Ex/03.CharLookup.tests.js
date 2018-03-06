let expect = require('chai').expect;
let lookupChar = require("./03.CharLookup").lookupChar;

describe('lookupChar', function () {
    it('Should return undefined for ()',function(){
        expect(lookupChar()).to.be.undefined;
    });

    it('Should return undefined for (1,1)', function () {
        expect(lookupChar(1, 1)).to.be.undefined;
    });
    it('Should return undefined for ("hello")', function () {
        expect(lookupChar('hello')).to.be.undefined;
    });
    it('Should return undefined for ("hello","1")', function () {
        expect(lookupChar('hello', '1')).to.be.undefined;
    });
    it('Should return undefined for ("hello",1.1)', function () {
        expect(lookupChar('hello', 1.1)).to.be.undefined;
    });
    it('Should return "Incorrect index" for ("hello",6)', function () {
        expect(lookupChar("hello", 5)).to.be.equal("Incorrect index");
    });
    it('Should return "Incorrect index" for ("hello",-1)', function () {
        expect(lookupChar("hello", -1)).to.be.equal("Incorrect index");
    });
    it('Should return undefined for ("",0)',function(){
        expect(lookupChar("",0)).to.be.equal("Incorrect index");
    });

    it('Should return correct char at given index', function () {
        expect(lookupChar("Hello", 0)).to.be.equal("H");
        expect(lookupChar("Hello", 4)).to.be.equal("o");
    });

});