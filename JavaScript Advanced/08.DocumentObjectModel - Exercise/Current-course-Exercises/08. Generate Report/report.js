function generateReport() {
    let checkBoxes = document.querySelectorAll('table thead tr th input');
    let rows = document.querySelectorAll('tbody tr');

    let resultArray = [];

    for (let i = 0; i < rows.length; i++) {
        let obj = {};

        let values = Array.from(rows[i].getElementsByTagName('td')).map(x=> x.textContent);
        for (let j = 0; j < checkBoxes.length; j++) {
            if (checkBoxes[j].checked) {
                obj[checkBoxes[j].name] = values[j];
            }
        }
        resultArray.push(obj);
    }
    document.querySelector('#output').value = JSON.stringify(resultArray,null,2);
}