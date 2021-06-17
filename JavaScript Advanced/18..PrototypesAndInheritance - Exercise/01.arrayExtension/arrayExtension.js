function solve() {
    let myArray = [1, 2, 3, 4, 5];
    Array.prototype.last = function () {
        return this[this.length - 1];
    }
    Array.prototype.skip = function (n) {
        let arr = myArray.slice();
        arr.splice(0, n);
        return arr;
    }
    Array.prototype.take = function (n) {
        let arr = myArray.slice();
        arr.splice(n, arr.length);
        return arr;
    }
    Array.prototype.sum = function () {
        return this.reduce((acc, el) => acc + el, 0);
    }
    Array.prototype.average = function () {
        return this.reduce((acc, el) => acc + el / this.length, 0);
    }
}