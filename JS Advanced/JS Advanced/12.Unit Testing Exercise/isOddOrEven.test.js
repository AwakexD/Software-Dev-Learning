const expect = require('chai').expect;
const { it } = require('mocha');
const isOddOrEven = require('./isOddOrEven');

describe('Is Odd Or Even', () => { 
    it('Should return that string lenght is even', () => {
        expect(isOddOrEven('text')).to.equal('even');
    })
    
    it('Should return that string length is odd', () => {
        expect(isOddOrEven('str')).to.equal('odd')
    })

    it('Should return undefined when input is not string', () => {
        expect(isOddOrEven(16)).to.be.undefined;
        expect(isOddOrEven(null)).to.be.undefined;
        expect(isOddOrEven({})).to.be.undefined;
        expect(isOddOrEven([])).to.be.undefined;
    })

 })
