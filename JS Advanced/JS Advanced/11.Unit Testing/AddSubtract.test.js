const expect = require('chai').expect;
const createCalculator = require('./AddSubtract');

describe('Add-Subtract', () => { 
    let calculator;

    beforeEach(() => {
        calculator = createCalculator();
    })

    it('Should return 0 on .get', () => {
        expect(calculator.get()).to.equal(0);
    })

    it('Should return 7 after adding 3 + 4', () => {
        calculator.add(3);
        calculator.add(4);

        let actual = calculator.get();

        expect(actual).to.equal(7);
    })

    it('Should calculate negative value after subtraction', () => {
        calculator.subtract(3);
        calculator.subtract(7);

        let actual = calculator.get();

        expect(actual).to.equal(-10)
    })

    it('Should return NaN after string adding', () => {
        calculator.add('string');

        expect(calculator.get()).to.be.NaN;
    })

    it('Should return NaN after string subtraction', () => {
        calculator.subtract('str');
        expect(calculator.get()).to.be.NaN;
    })
 })