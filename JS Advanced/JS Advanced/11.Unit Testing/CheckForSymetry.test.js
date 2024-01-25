const expect = require('chai').expect;
const isSymmetric = require('./CheckForSymetry');

describe('Check-For-Symetrty', () => {
    it('Should return true for symetrical array', () => {
        expect(isSymmetric([1, 2, 1])).to.be.true;
    });

    it('Should return false when input is not correct', () => {
        expect(isSymmetric(undefined)).to.be.false;
        expect(isSymmetric({})).to.be.false;
        expect(isSymmetric('str')).to.be.false;
        expect(isSymmetric(null)).to.be.false;
        expect(isSymmetric(NaN)).to.be.false;

    });

    it('Should return true when the array is empty', () => {
        expect(isSymmetric([])).to.be.true;
    })

    it('Should return false for non-symetrical array', () => {
        expect(isSymmetric([1, 2, 3])).to.be.false;
    })

    it('Should return true for single element', () => {
        expect(isSymmetric([6])).to.be.true;
    })
});