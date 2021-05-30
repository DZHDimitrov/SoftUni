function createSortedList() {
    class SortedList {
        constructor(list = []) {
            this.list = list.sort((a, b) => a - b);
            this.size = this.list.length;
        }

        add(element) {
            this.list.push(element);
            this.list.sort((a, b) => a - b);
            this.size++;
            return;
        }
        remove(index) {
            if (index < 0 || index > this.list.length - 1) {
                throw new Error('Number does not exist')
            } else {
                this.list.splice(index, 1);
                this.size--;
                return;
            }
        }
        get(index) {
            if (index < 0 || index > this.list.length - 1) {
                throw new Error('Numer does not exist')
            } else {
                return this.list[index];
            }
        }
    }
    return new SortedList();
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));

