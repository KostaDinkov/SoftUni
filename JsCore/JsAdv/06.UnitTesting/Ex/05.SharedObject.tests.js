let expect = require('chai').expect;
let sharedObject = require('./05.SharedObject.js').sharedObject;
let jsdom = require('jsdom-global')();
$ = require('jquery');

document.body.innerHTML = `<body>
    <div id="wrapper">
        <input type="text" id="name">
        <input type="text" id="income">
    </div>
</body>
`;

describe('sharedObject', function () {
    beforeEach(function () {
        sharedObject.name = null;
        sharedObject.income = null;
    });
    it('should have a "name" property initially set to null', function () {
        expect(sharedObject.hasOwnProperty('name')).to.be.true;
        expect(sharedObject.name).to.be.null;
    });
    it('should have an "income" property initially set to null', function () {
        expect(sharedObject.hasOwnProperty('income')).to.be.true;
        expect(sharedObject.income).to.be.null;
    });
    describe('changeName', function () {

        it('sharedObject should have "changeName" function that accepts 1 argument', function () {
            expect(sharedObject.hasOwnProperty('changeName')).to.be.true;
            expect(typeof (sharedObject.changeName)).to.be.equal('function');
            expect(sharedObject.changeName.length).to.be.equal(1);
        });
        it('should do nothing if empty string is passed', function () {
            let currentVal = sharedObject.name;
            sharedObject.changeName('');
            expect(sharedObject.name).to.be.equal(currentVal);
        });
        it('should change name property correctly', function () {
            sharedObject.changeName('My name');
            expect(sharedObject.name).to.be.equal('My name')
        });
        
        it('should change textbox value correctly', function () {
            sharedObject.changeName('New name');
            expect($('#name').val()).to.be.equal('New name');
        });

    });
    describe('changeIncome', function () {
        it('sharedObject should have "changeIncome" function that accepts 1 argument', function () {
            expect(sharedObject.hasOwnProperty('changeIncome')).to.be.true;
            expect(typeof (sharedObject.changeIncome)).to.be.equal('function');
            expect(sharedObject.changeIncome.length).to.be.equal(1);
        });
        it('should change nothing if argument is non positive integer', function () {
            let currentVal = sharedObject.income;
            sharedObject.changeIncome(0);
            expect(sharedObject.income).to.be.equal(currentVal);
            sharedObject.changeIncome(-1);
            expect(sharedObject.income).to.be.equal(currentVal);
            sharedObject.changeIncome(1.1);
            expect(sharedObject.income).to.be.equal(currentVal);
            sharedObject.changeIncome("1");
            expect(sharedObject.income).to.be.equal(currentVal);
        });
        it('should update income property and #income texbox value when valid arg is provided', function () {
            let currentVal = sharedObject.income;
            sharedObject.changeIncome(5);

            expect(sharedObject.income).to.be.equal(5);
            expect($('#income').val()).to.be.equal('5');
        })

    });
    describe('updateName', function () {
        it('sharedObject should have "updateName" function that accepts 0 argument', function () {
            expect(sharedObject.hasOwnProperty('updateName')).to.be.true;
            expect(typeof (sharedObject.updateName)).to.be.equal('function');
            expect(sharedObject.updateName.length).to.be.equal(0, "Incorrect number of parameters");
        });

        it('should change nothing if empty string is passed', function () {
            $('#name').val('');
            sharedObject.name = 'Vader';
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal('Vader');
        });
        it('should update name property with the value of the #name textbox', function () {
            $("#name").val('Obi');
            sharedObject.name = 'Vader';
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal('Obi')
        })

    });
    describe('updateIncome', function () {
        it('sharedObject should have "updateIncome" function that accepts 0 argument', function () {
            expect(sharedObject.hasOwnProperty('updateIncome')).to.be.true;
            expect(typeof (sharedObject.updateIncome)).to.be.equal('function');
            expect(sharedObject.updateIncome.length).to.be.equal(0);
        });
        it('should not change income property if the value of the #income textbox is not a positive int', function () {
            let currentIncome = sharedObject.income;
            let $income = $('#income');
            $income.val('hi');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(currentIncome);

            $income.val(0);
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(currentIncome);

            $income.val(-1);
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(currentIncome);

            $income.val(1.1);
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(currentIncome);
        });
        it('should update income property when the value of the #income textbox is valid', function () {
            sharedObject.income = 0;
            $('#income').val(5);
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(5);
        })

    });

});