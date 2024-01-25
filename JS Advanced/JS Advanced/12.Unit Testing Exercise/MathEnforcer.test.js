const expect = require('chai').expect;
const mathEnforcer = require('./MathEnforcer.js')


describe('Math Enforcer', () => {
    describe('.addFive', () => {
        it('Should work with correct input', () => {
            expect(mathEnforcer.addFive(5)).to.equal(10);
        })

        it('Should return undefined if input is not a number', () => {
            expect(mathEnforcer.addFive(null)).to.be.undefined;
            expect(mathEnforcer.addFive([])).to.be.undefined;
            expect(mathEnforcer.addFive({})).to.be.undefined;
            expect(mathEnforcer.addFive('sdasa')).to.be.undefined;
        })

        it('Should work with negative number', () => {
            expect(mathEnforcer.addFive(-6)).to.equal(-1);
        })
    })

    describe('.subtractTen' , () => {
        it('Should work with correct input', () => {
            expect(mathEnforcer.subtractTen(12)).to.equal(2);
        })

        it('Should return undefined if input is not a number', () => {
            expect(mathEnforcer.subtractTen(null)).to.be.undefined;
            expect(mathEnforcer.subtractTen([])).to.be.undefined;
            expect(mathEnforcer.subtractTen({})).to.be.undefined;
            expect(mathEnforcer.subtractTen('text')).to.be.undefined;
        })

        it('Should work with negative numbers', () => {
            expect(mathEnforcer.subtractTen(-20)).to.equal(-30);
        })
    })

    describe('.sum', () => {
        it('Should sum correctly two numbers', () => {
            expect(mathEnforcer.sum(5, 6)).to.equal(11);
        })

        it('Should return undefines if input is not a number', () => {
            expect(mathEnforcer.sum('asd', 21)).to.be.undefined;
            expect(mathEnforcer.sum(21, 'str')).to.be.undefined;
            expect(mathEnforcer.sum([], {})).to.be.undefined;
            expect(mathEnforcer.sum(undefined, null)).to.be.undefined;
        })

        it('Should work with negative numbers', () => {
            expect(mathEnforcer.sum(-21, -30)).to.equal(-51);
        })
    })
})