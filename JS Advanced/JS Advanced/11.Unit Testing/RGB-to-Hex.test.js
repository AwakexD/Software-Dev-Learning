const expect = require('chai').expect;
const rgbToHexColor = require('./RGB-To-Hex');

describe('RGB-To-Hex', () => {
    it('Should return undefinded when input is not number', () => {
        expect(rgbToHexColor('str', '122', 'sda')).to.be.undefined;
    })

    it('Should return undefined when input is bigger than 255 or less than 0', () => {
        expect(rgbToHexColor(300, -1, 25)).to.be.undefined;
    })

    it('Should convert rgb to hex', () => {
        expect(rgbToHexColor(255,158,170)).to.equal('#FF9EAA')
    })
}) 