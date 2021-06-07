function printDeckOfCards(arr) {
    let result = arr.map(x => {
        let face = x.substring(0, x.length - 1);
        let suit = x[x.length - 1];
        try {
            return createCard(face, suit);
        } catch (error) {
            return error.message;
        }
    });
    console.log(result.join(' '));
    function createCard(face, suit) {
        const validCards = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const suits = {
            'Spades': '\u2660',
            'Hearts': '\u2665',
            'Diamonds': '\u2666',
            'Clubs': '\u2663'
        }

        if (!validCards.some(x => x == face) || !Object.keys(suits).some(x => x[0] == suit)) {
            throw new Error(`Invalid card: ${face + suit}`);
        }

        return `${face + suits[Object.keys(suits).find(x => x[0] == suit)]}`
    }
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);