const expect = require('chai').expect;
const solution = require('./SubSum.js');

describe('Sub-sub Calculator', () => {
    it('Result when endIndex is larger than length', () => {
        // Arrange
        let expectedSum = 150;
        let numbers = [10, 20, 30, 40, 50, 60];
        let startIndex = 3;
        let endInex = 300;
    
        // Act
        let actualSum = solution(numbers, startIndex, endInex);
    
        // Assert
        expect(actualSum).to.be.equal(expectedSum);
    });
    
    it('Result when startIndex is lower than 0', () => {
        // Arrange
        let expectedSum = 60;
        let numbers = [10, 20, 30, 40, 50, 60];
        let startIndex = -100;
        let endInex = 2;
    
        // Act
        let actualSum = solution(numbers, startIndex, endInex);
    
        // Assert
        expect(actualSum).to.be.equal(expectedSum);
    })

    it("Given parameter is not array(object)", () => {
        expect(solution({}, 3, 300)).to.be.NaN;
        expect(solution(10, 3, 300)).to.be.NaN;
        expect(solution(null, 3, 300)).to.be.NaN;
        expect(solution(undefined, 3, 300)).to.be.NaN;
        expect(solution(true, 3, 300)).to.be.NaN;

    })
});



