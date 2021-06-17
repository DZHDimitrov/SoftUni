(function solve() {
    String.prototype.ensureStart = function (str) {
        if (this.split(' ')[0] != str) {
            return str + this;
        }
        return this;
    }
    String.prototype.ensureEnd = function (str) {
        if (this.split(' ')[this.length-1] != str) {
            return this + str;
        }
        return this;
    }
    String.prototype.isEmpty = function () {
        return !this ? true : false;
    }
    String.prototype.truncate = function (n) {
        if (this.length < n) {
            return this;
        } else if (n < 4) {
            return n === 0 ? '' : n === 1 ? '.' : n === 2 ? '..' : '...';
        } else {
            if (this.includes(' ')) {
                let words = this.split(' ');
                let arr = [];
                for (let i = 0; i < words.length; i++) {
                    
                    if (arr.join(' ').length + words[i].length >= n && arr.join(' ').length + '...'.length <= n) {
                        return arr.join(' ') + '...';
                    }
                    arr.push(words[i]);
                }
            } else {
                return this.substr(0, n - 3) + '...';
            }
        }
    }
    String.format = function (string, ...params) {
        let counter = 0;
        string.split(' ').forEach(x => {
            if (x.startsWith('{') && x.endsWith('}')) {
                counter++;
            }
        });

        let arr = string.split(' ');
        let paramsCounter = 0;
        for (let i = 0; i < arr.length; i++) {
            if (arr[i].startsWith('{') && arr[i].endsWith('}')) {
                arr[i] = params[paramsCounter] !== undefined ? params[paramsCounter] : `{${paramsCounter}}`;
                paramsCounter++;
            }
        }
        return arr.join(' ');
    }
})();