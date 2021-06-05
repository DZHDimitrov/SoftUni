function solve(commands) {
    let array = [];

    let obj = {
        add,
        remove,
        print,
    }
    console.log(commands);
    commands.forEach(x=> {
        const line = x.split(' ');
        if (line[0] == 'add') {
            obj.add(line[1]);
        } else if (line[0] == 'remove'){
            obj.remove(line[1])
        } else if (line[0] == 'print') {
            obj.print();
        }
    })

    function add(text) {
         array.push(text);
    }
    function remove(text) {
        array = array.filter(x=> x != text);
    }
    function print() {
        console.log(array.join(',') + 'haha');
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);
solve(['add stallone','remove stallone','remove stallone','print']);