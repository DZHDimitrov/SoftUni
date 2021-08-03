const Tree = require("./tree.js");

function solve(text) {
    const tree = new Tree();
    tree.createTree(text);

    const encoded = tree.encode(text);
    let encodedResult = '';
    encoded.forEach(x=> {
        encodedResult += (x == true ? 1 : 0) + "";
    })

    console.log(encodedResult);

    const decoded = tree.decode(encoded);
    console.log(decoded);
}

solve('EECCCCCCAAADDDDBBBBB');