function addDestination() {
    const inputsElement = document.getElementById('input');
    const inputs = Array.from(inputsElement.querySelectorAll('input'));
    const outputElement = document.getElementById('destinations');
    const summaryBoxElements = document.getElementById('summaryBox');

    const city = inputs[0].value;
    const country = inputs[1].value;
    const season = document.getElementById('seasons').value;
    if (city && country && season) {
        inputs[0].value = '';
        inputs[1].value = '';
        const trElement = document.createElement('tr');

        const tdElementFirst = document.createElement('td');
        tdElementFirst.textContent = `${city[0].toUpperCase() + city.substring(1, city.length)}, ${country[0].toUpperCase() + country.substring(1, country.length)}`;

        const tdElementSecond = document.createElement('td');
        tdElementSecond.textContent = `${season[0].toUpperCase() + season.substring(1, season.length)}`;

        trElement.appendChild(tdElementFirst);
        trElement.appendChild(tdElementSecond);

        outputElement.appendChild(trElement);

        const summaryBox = Array.from(summaryBoxElements.querySelectorAll('input')).filter(x=>x.id == season);
        summaryBox[0].value++;
    }

}