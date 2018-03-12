let Sumator = require('./sumator').Sumator;
let expect = require('chai').expect;

describe('Sumator class', function () {
    let sumator;
    beforeEach(function () {
        sumator = new Sumator();
    });

    it('should have property data initialized to empty array', function () {

        expect(sumator.hasOwnProperty('data')).to.be.true;
        expect(Array.isArray(sumator.data)).to.be.true;
        expect(sumator.data.length === 0).to.be.true;
    });
    it('has functions attached to prototype', function () {
        expect(Object.getPrototypeOf(sumator).hasOwnProperty('add')).to.equal(true, "Missing add function");
        expect(Object.getPrototypeOf(sumator).hasOwnProperty('sumNums')).to.equal(true, "Missing sumNums function");
        expect(Object.getPrototypeOf(sumator).hasOwnProperty('removeByFilter')).to.equal(true, "Missing removeByFilter function");
        expect(Object.getPrototypeOf(sumator).hasOwnProperty('toString')).to.equal(true, "Missing toString function");
    });

    describe('add(item) method', function () {
        it('should add the passed item to the data array', function () {
            sumator.add(1);
            expect(sumator.data[0]).to.be.equal(1);

            sumator.add('hello');
            expect(sumator.data[1]).to.be.equal('hello');

            sumator.add({});
            expect(typeof sumator.data[2]).to.be.equal('object');

            sumator.add((a) => a);
            expect(typeof sumator.data[3]).to.be.equal('function');
        })
    });
    describe('sumNums() method', function () {
        it('should sum only the numbers in the data array', function () {
            sumator.add(1);
            sumator.add('hello');
            sumator.add(1);
            expect(sumator.sumNums()).to.be.equal(2);
        });
        it('should sum decimals correctly', function () {
            sumator.add(0.1);
            sumator.add('hello');
            sumator.add(0.1);
            expect(sumator.sumNums()).to.be.closeTo(0.2, 0.00001)
        });
        it('should sum negative numbers correctly', function () {
            sumator.add(-1);
            sumator.add('hello');
            sumator.add(-1);
            expect(sumator.sumNums()).to.be.equal(-2)
        });
        it('should return zero if no numbers are stored', function () {
            expect(sumator.sumNums()).to.be.equal(0);
            sumator.add('hello');
            expect(sumator.sumNums()).to.be.equal(0);
        })
    });
    describe('removeByFilter(filterFunc) mehtod', function () {
        it('should remove all items from data based on the filter function', function () {
            sumator.add(1);
            sumator.add('hello');
            sumator.add('hello');
            expect(sumator.data.includes('hello')).to.be.true;
            sumator.add(0.5);
            sumator.removeByFilter((a) => a === 'hello');
            expect(sumator.data.includes('hello')).to.be.false;
        });
        it('should change nothing if no items satisfy the filter function', function () {

            sumator.add('hello');
            sumator.add('you');

            sumator.removeByFilter((a) => a === 'there');
            expect(sumator.data.length).to.be.equal(2);
            expect(sumator.data[0]).to.be.equal('hello');
            expect(sumator.data[1]).to.be.equal('you');
        })
    });
    describe('toString() method', function () {
        it('should return a string containing a list of all items from the data arr', function () {
            sumator.add(1);
            sumator.add(2);
            sumator.add('hello');
            let expected = '1, 2, hello';
            expect(sumator.toString()).to.be.equal(expected);
        });

        it('should return "(empty)" if the data array has no items', function () {
            expect(sumator.toString()).to.be.equal('(empty)')
        })
    })

});