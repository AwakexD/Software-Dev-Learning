function extendPrototype(classToExtend) {
    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function() {
        `I am a ${this.species} ${this.toString()}`
    };
}