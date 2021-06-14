function solve(inputArr, sortCriteria) {
    class Ticket {
        constructor(destinationName, price, status) {
            this.destination = destinationName;
            this.price = price;
            this.status = status;
        }
    }

    let result = inputArr.reduce((acc, el) => {
        const currentLine = el.split('|');
        let [destination, curPrice, status] = currentLine;
        const price = Number(Number(curPrice).toFixed(2));
        acc.push(new Ticket(destination, price, status));
        return acc;
    }, []);

    return (sorting(result,sortCriteria));
    function sorting(arr,sortCriteria) {
        if (sortCriteria == 'destination') {
            arr.sort((a,b) => a.destination.localeCompare(b.destination));
        } else if (sortCriteria == 'price') {
            arr.sort((a,b) => a.price - b.price);
        } else if (sortCriteria == 'status') {
            arr.sort((a,b) => a.status.localeCompare(b.status));
        }
        return arr;
    }
}

// console.log(solve(['Philadelphia|94.20|available',
// 'New York City|95.99|available',
// 'New York City|95.99|sold',
// 'Boston|126.20|departed'],
// 'status'
// ));

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));