let expect = require('chai').expect;
let rgbToHexColor = require('./06.RgbToHex').rgbToHexColor;

describe('Tests for rgbToHexColor function', function () {

    describe('Test for expected input arguments', function () {
        it('Should return #FF9EAA for (255,158,170', function () {
            expect(rgbToHexColor(255, 158, 170)).to.be.equal('#FF9EAA')
        });
        it('Should return #0C0D0E for (12,13,14)', function () {
            expect(rgbToHexColor(12, 13, 14)).to.be.equal('#0C0D0E');
        });
        it('Should return #000000 for(0,0,0)', function () {
            expect(rgbToHexColor(0, 0, 0)).to.be.equal('#000000');
        });
        it('Should return #FFFFFF for(255,255,255', function () {
            expect(rgbToHexColor(255, 255, 255)).to.be.equal('#FFFFFF');
        });

    });
    describe("Test for special cases", function () {
        it('Should return undefined for (-1,0,0)', function () {
            expect(rgbToHexColor(-1, 0, 0)).to.be.undefined;
        });
        it('Should return undefined for (0,0,-1)', function () {
            expect(rgbToHexColor(0, 0, -1)).to.be.undefined;
        });
        it('Should return undefined for (0,-1,0)', function () {
            expect(rgbToHexColor(0, -1, 0)).to.be.undefined;
        });

        it('Should return undefined for values more than 255 ', function () {
            expect(rgbToHexColor(256, 0, 0)).to.be.undefined;
            expect(rgbToHexColor(0, 256, 0)).to.be.undefined;
            expect(rgbToHexColor(0, 0, 256)).to.be.undefined;
        });
        it('Should return undefined for decimal values', function () {
            expect(rgbToHexColor(3.14, 0, 0)).to.be.undefined;
            expect(rgbToHexColor(0, 3.14, 0)).to.be.undefined;
            expect(rgbToHexColor(0, 0, 3.14)).to.be.undefined;
        });
        it('Should return undefined for empty input ()', function () {
            expect(rgbToHexColor()).to.be.undefined;
        });
        it('Should return undefined for invalid arguments', function () {
            expect(rgbToHexColor("5", [3], {8: 9})).to.be.undefined;
        });

    })
});