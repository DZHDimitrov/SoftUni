function solve(input) {
    let parsed = JSON.parse(input);
    let obj = parsed[0];
    let html = '<table>' + '\n';
    html += `<tr>\n ${Object.keys(obj).map(x=> `<th>${x}</th>\n`).join('')}</tr>\n`
    html += parsed.map(x=> `<tr>\n${Object.values(x).map(y=> `<td>${y}</td>\n`).join('')}</tr>\n`).join('');
    html += '</table';
    console.log(html);
}

solve(
    JSON.stringify([{"Name":"Pesho",
    "Score":4,
    " Grade":8},
   {"Name":"Gosho",
    "Score":5,
    " Grade":8},
   {"Name":"Angel",
    "Score":5.50,
    " Grade":10}]
)
);