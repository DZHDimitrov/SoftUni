class Node {
    constructor(value,frequency,right,left){
        this.value = value;
        this.frequency = frequency;
        this.right = right;
        this.left = left;
    }
}

Node.prototype.traverse = function(symbol,data) { 
    if (!this.left && !this.right) {
        const result = symbol === this.value ? data : undefined;

        return result;
    } else {
        let left = undefined;
        let right = undefined;

        if (this.left != undefined) {
            let leftPath = [];

            leftPath = data.slice();
            leftPath.push(false);

            left = this.left.traverse(symbol,leftPath);
        }

        if (this.right != undefined) {
            let rightPath = [];

            rightPath = data.slice();
            rightPath.push(true);

            right = this.right.traverse(symbol,rightPath);
        }

        if (left) {
            return left;
        } else {
            return right;
        }

    }
}

module.exports = Node;