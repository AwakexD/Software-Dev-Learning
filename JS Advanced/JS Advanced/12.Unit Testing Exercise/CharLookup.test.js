const expect = require('chai').expect;
const LookupChar = require('./CharLookup');

describe('Char Lookup', () => { 
    it('Should return correct char with correct parameters', () => {
        let actual = LookupChar('str', 1);
        expect(actual).to.equal('t');
    })

    it("Should return 'Incorrect index' when index is either lower/bigger", () => {
        expect( LookupChar('string', 200)).to.equal('Incorrect index');
        expect( LookupChar('string', -20)).to.equal('Incorrect index');
    })

    it('Should return error message when index is equal to string length', () => {
        expect(LookupChar('hello', 5)).to.equal('Incorrect index');
    })

    describe('Overload Test', () => { 
        it('Should return undefined when string or index are invalid data type', () => {
            expect(LookupChar(null, 2)).to.be.undefined;
            expect(LookupChar('str', [1])).to.be.undefined;
        })

        it('Should return undefined when index is floating number', () => {
            expect(LookupChar('str', 2.3)).to.be.undefined;
        })
    })

})