const {assert} = require('chai');
const rgbToHexColor = require('./rgbToHex');

describe('RgbToHex', () => {
    it('should return (#99785F) ', () => {
        assert.equal(rgbToHexColor(153,120,95),'#99785F');
    });

    it('should return zeros with 0 inputs',() => {
        assert.equal(rgbToHexColor(0,0,0), '#000000');
    });

    it('should return six F with 255 inputs',() => {
        assert.equal(rgbToHexColor(255,255,255), '#FFFFFF');
    });

    it('should return (#FAFB78)', () => {
        assert.equal(rgbToHexColor(250,251,120),'#FAFB78');
    });

    it('should return undefined if "r" is more than range', () =>{
        assert.isUndefined(rgbToHexColor(256,0,0));
    });

    it('should return undefined if "g" is more than range', () => {
        assert.isUndefined(rgbToHexColor(250,350,0));
    });

    it('should return undefined if "b" is more than range', () => {
        assert.isUndefined(rgbToHexColor(251,150,270));
    });

    it('should return undefined if "r" is less than range', () =>{
        assert.isUndefined(rgbToHexColor(-5,0,0));
    });

    it('should return undefined if "g" is less than range', () => {
        assert.isUndefined(rgbToHexColor(250,-1,0));
    });

    it('should return undefined if "b" is less than range', () => {
        assert.isUndefined(rgbToHexColor(251,150,-20));
    });

    it('should return undefiend if "r" parameter are invalid', () => {
        assert.isUndefined(rgbToHexColor('250',120,120));
    });

    it('should return undefiend if "g" parameter are invalid', () => {
        assert.isUndefined(rgbToHexColor(250,'asd',120));
    });

    it('should return undefiend if "b" parameter are invalid', () => {
        assert.isUndefined(rgbToHexColor(250,120,[1,2,3]));
    });

    it('should return undefiend if there is no input', () => {
        assert.isUndefined(rgbToHexColor());
    })
})