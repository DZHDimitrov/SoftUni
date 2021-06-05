function solve () {
    let text = '';
    return {
        append(givenString) {
            text += givenString;
        },
        removeStart(n) {
            text = text.substring(n);
        },
        removeEnd(n) {
            text = text.substring(0,text.length - n);
        },
        print() {
            console.log(text);
        }
    }
}

let firstZeroTest = solve();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();