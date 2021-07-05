function getInfo() {
    const busId = document.getElementById('stopId').value;
    const stopName = document.getElementById('stopName');
    const busesElement = document.getElementById('buses');
    busesElement.innerHTML = '';
    fetch('http://localhost:3030/jsonstore/bus/businfo/'+busId)
        .then(response => response.json())
        .then(data => {
            stopName.textContent = data.name;
            Object.entries(data.buses).forEach(([key,value]) => {
                document.getElementById('buses').appendChild(createLiElement(key,value));
            })
        })
        .catch(error => {
            busesElement.innerHTML = '';
            stopName.textContent = 'Error';
        });
    document.getElementById('stopId').value = '';
}

function createLiElement(key,value) {
    const liElement = document.createElement('li');
    liElement.textContent = `Bus ${key} arrives in ${value} minutes`;
    return liElement;
}