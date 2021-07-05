function solve() {
    const departEl = document.getElementById('depart');
    const arriveEl = document.getElementById('arrive');
    const info = document.querySelector('#info span');

    //state
    let stop = {
        next: 'depot'
    }

    function depart() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`;

        //AJAX request
        fetch(url)
            .then(x => x.json())
            .then(x => {
            stop = x;
            info.textContent = `Next stop ${x.name}`;
            departEl.disabled = true;
            arriveEl.disabled = false;
        })
            .catch(error => {
            info.textContent = 'Error';
            departEl.disabled = true;
            arriveEl.disabled = true;
        });
    }

    function arrive() {
        info.textContent = `Arriving at ${stop.name}`
        departEl.disabled = false;
        arriveEl.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();