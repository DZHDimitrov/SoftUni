function solve(array) {
    let jsonData = array.shift();
    let input = JSON.parse(jsonData);
    let first = input[0];
    let html = '<table>';
    html += `<tr>${Object.keys(first).map(x => `<th>${x}</th>`).join('')}</tr>`;
    input.forEach(x => {
        html += '<tr>';
        html += Object.values(x).map(y => `<td>${y}</td>`).join('');
        html += '</tr>';
    })
    html += '</table>';
    return html;
}

console.log(solve(['[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]']));