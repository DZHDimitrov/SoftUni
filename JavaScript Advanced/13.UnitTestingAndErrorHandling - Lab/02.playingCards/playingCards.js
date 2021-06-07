function solve(face,suit) {
    const validCards = ['2','3','4','5','6','7','8','9','10','J','Q','K','A'];
    const suits = {
        'Spades': '\u2660',
        'Hearts': '\u2665',
        'Diamonds': '\u2666',
        'Clubs': '\u2663'
    }

    if (!validCards.some(x=>x == face) || !Object.keys(suits).some(x=> x[0] == suit)) {
        throw new Error('Error');
    }

    return `${face + suits[Object.keys(suits).find(x=> x[0] == suit)]}`
}

console.log(solve('2','D'));