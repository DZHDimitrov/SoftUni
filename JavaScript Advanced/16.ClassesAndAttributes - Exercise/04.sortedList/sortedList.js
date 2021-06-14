class List {
    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(element) {
        this.list.push(element);
        this.size++;
        this._sort();
    }

    remove(index) {
        if (index < 0 || index > this.list.length - 1) {
            throw new Error('Invalid index');
        }
        this.list.splice(index,1);
        this.size--;
        this._sort();
    }

    get(index) {
        if (index < 0 || index > this.list.length - 1) {
            throw new Error('Invalid index');
        }
        return this.list[index];
    }
    
    _sort() {
        this.list.sort((a,b) => a-b);
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.size);
