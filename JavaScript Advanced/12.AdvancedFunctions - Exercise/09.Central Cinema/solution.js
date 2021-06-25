function solve() {
    let onScreenBtn = document.querySelector('#container button');
    let clearBtn = document.querySelector('#archive button');
    clearBtn.addEventListener('click',clear)
    onScreenBtn.addEventListener('click',onScreen);

    function onScreen(e) {
        e.preventDefault();
        let name = document.querySelector('[placeholder="Name"]');
        let hall = document.querySelector('[placeholder="Hall"]');
        let ticketPrice = document.querySelector('[placeholder="Ticket Price"]');
        let valueOfTicket = Number(ticketPrice.value)
        if (!name.value || !hall.value || isNaN(valueOfTicket) ||!ticketPrice.value) {
            return;
        }

        let liElement = createLiElement(name.value,hall.value,Number(ticketPrice.value));

        let moviesOnScreenOutput = document.querySelector('#movies>ul');
        moviesOnScreenOutput.appendChild(liElement);
        name.value = '';
        hall.value = '';
        ticketPrice.value = '';
    }

    function createLiElement(name,hall,ticketPrice) {
        let liElement = document.createElement('li');

        let spanElement = document.createElement('span');
        spanElement.textContent = name;

        let strongElement = document.createElement('strong');
        strongElement.textContent = `Hall: ${hall}`;

        let divElement = document.createElement('div');

        let strongDivElement = document.createElement('strong');
        strongDivElement.textContent = `${ticketPrice.toFixed(2)}`;

        let inputDivElement = document.createElement('input');
        inputDivElement.setAttribute('placeholder','Tickets Sold');

        let buttonDivElement = document.createElement('button');
        buttonDivElement.textContent = 'Archive';
        buttonDivElement.addEventListener('click',archive)

        divElement.appendChild(strongDivElement);
        divElement.appendChild(inputDivElement);
        divElement.appendChild(buttonDivElement);

        liElement.appendChild(spanElement);
        liElement.appendChild(strongElement);
        liElement.appendChild(divElement);

        return liElement;
    }
    function archive(e) {
        let liElement = e.target.parentElement.parentElement;
        let ticketPrice = Number(e.target.parentElement.firstElementChild.textContent);
        let valueOfInput = e.target.previousElementSibling.value;
        let parsedInput = Number(valueOfInput);
        console.log(parsedInput);
        console.log(valueOfInput);
        if (isNaN(parsedInput) || !valueOfInput) {
            return;
        }

        e.target.parentElement.previousElementSibling.remove();
        e.target.parentElement.remove();

        let archiveOutputList = document.querySelector('#archive>ul');
        let strongElement = document.createElement('strong');
        let totalAmount = parsedInput * ticketPrice;
        strongElement.textContent = `Total amount: ${totalAmount.toFixed(2)}`;

        let btnElement = document.createElement('button');
        btnElement.textContent = 'Delete';
        btnElement.addEventListener('click',(e) => {
            e.target.parentElement.remove();
        })
        liElement.appendChild(strongElement);
        liElement.appendChild(btnElement);
        archiveOutputList.appendChild(liElement);
    }
    function clear(e) {
        let listToClear = e.target.previousElementSibling;
        listToClear.innerHTML = '';
    }
}