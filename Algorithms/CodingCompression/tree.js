const Node = require("./node.js");

class Tree {
    constructor () {
        this.allNodes = [];
        this.root = undefined;
        this.symbolFrequency = [];
    }
}

Tree.prototype.createTree = function(text) {
    [...text].forEach(textSymbol=> {
        if (!this.symbolFrequency.some(x=>x.symbol == textSymbol)) {
            const symbolInfo = {symbol:textSymbol , appearance:0};
            this.symbolFrequency.push(symbolInfo);
        }
        const symbolInfo = this.symbolFrequency.find(si=>si.symbol == textSymbol);
        symbolInfo.appearance++;
    })

    this.symbolFrequency.forEach(x=> {
        let node = new Node();
        node.value = x.symbol;
        node.frequency = x.appearance;
        this.allNodes.push(node);
    })

    while (this.allNodes.length > 1) {
        let ascendingNodes = this.allNodes.sort((a,b) => compareNodes(a,b));

        if (ascendingNodes.length >= 2) {
            let firstNodes = ascendingNodes.slice(0,2);

            let value = '*';
            let frequency = firstNodes[0].frequency + firstNodes[1].frequency;
            let left = firstNodes[0];
            let right = firstNodes[1];

            let currentNode = new Node(value,frequency,left,right);

            this.allNodes.splice(0,1);
            this.allNodes.splice(0,1);
            this.allNodes.push(currentNode);
        }

        this.root = this.allNodes[0];
    }
}

Tree.prototype.encode = function(text) {
    const encodingList = [];

    [...text].forEach(symbol=> {
        const encodedSymbol = this.root.traverse(symbol,[]);
        encodedSymbol.forEach(boolValue=> encodingList.push(boolValue));
    })

    let bitArray = encodingList.map(boolValue=> {
        if (boolValue == true) {
            return 1;
        }else {
            return 0;
        }
    })

    return bitArray;
}

Tree.prototype.decode = function(bits) {
    let node = this.root;
    let result = '';

    bits.forEach(bit=> {
        if (bit) {
            if (node.right != null) {
                node = node.right;
            }
        }
        else {
            if (node.left != null) {
                node = node.left;
            }
        }
        if (isLeaf(node)) {
            result += node.value;
            node = this.root;
        }
    })
    return result;
}

function isLeaf(node){
    return (!node.left && !node.right)
}

function compareNodes(a,b) {
    return a.frequency - b.frequency;
}

module.exports = Tree;