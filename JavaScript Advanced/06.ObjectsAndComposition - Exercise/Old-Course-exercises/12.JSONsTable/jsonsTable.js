function solve(input) {
    let html = '<table>' + '\n';
    input.forEach(e => {
        html+='     ' + '<tr>' + '\n';
        let employee = JSON.parse(e);
        Object.values(employee).forEach(x=> {
            html+='\t'+ `<td>${x}</td>` + '\n'
        })
        html+= '    ' + '</tr>' + '\n';
    })

    html += '</table>';
    console.log(html);
}

solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
);