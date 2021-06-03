function deleteByEmail() {
    let input = document.querySelector('[name="email"]').value;
    let result = document.getElementById('result');
    let isFound = false;
    console.log(input);

    let tableRows=Array.from(document.querySelectorAll('tbody tr'));
    for (const row of tableRows) {
        if (row.lastElementChild.textContent == input) {
            row.remove();
            result.textContent = 'Deleted';
            isFound = true;
        }
    }
    if (!isFound) {
        result.textContent = 'Not found.'
    }
}