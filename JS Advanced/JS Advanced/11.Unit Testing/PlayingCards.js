function solution(face, suit) {
    const validFaces = ['2', '3', '4', '5', '6'
    , '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    const validSuits = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663', 
    }

    function createCard(face, suit) {
        return newCard = {
            face,
            suit,
            ToString() {
                return this.face + validSuits[this.suit];
            }
        };
    }

    let isValid = (card) => {
        if (validFaces.includes(card.face) & 
            validSuits.hasOwnProperty(card.suit)) {
            return true;
        } else {
            return false;
        }
    }

    let card = createCard(face, suit);
    if (isValid(card)) {
        console.log(card.ToString());
    } else {
        throw new Error();
    }

}

solution('A', 'S');
solution('10', 'H');
solution('1', 'C');