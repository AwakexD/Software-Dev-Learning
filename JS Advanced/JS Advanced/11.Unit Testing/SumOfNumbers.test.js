const expect = require('chai').expect;
const sum = require('./SumOfNumbers'); 

describe('Sum-Of-Numbers', () => {
    it('Should return the sum of numbers in the array', () => {
        let numbers = [1, 2, 3];
        let actual = sum(numbers);

        expect(actual).to.equal(6)
    });

    it('Should return zero for empty array', () => {
        expect(sum([])).to.equal(0);
    })

    it('Should handle negative numbers correctly', () => {
        expect(sum([-1, -2, -3, -4, -5])).to.equal(-15);
    })

    it('Should return NaN for non-number array', () => {
        let arr = ['a', 'b', 'str'];
        expect(sum(arr)).to.be.NaN;
    }) 
})