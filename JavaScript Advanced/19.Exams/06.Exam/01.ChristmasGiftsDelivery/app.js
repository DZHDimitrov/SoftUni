function solution() {
    let sections = document.querySelectorAll('section');
    let addBtn = sections[0].querySelector('button');
    let listOfGiftsArray = [];
    addBtn.addEventListener('click', (e) =>{
        e.preventDefault();

        const input = document.querySelector('[placeholder="Gift name"]');
        if (!input.value) {
            return;
        }
        const listOfGifts = sections[1].querySelector('ul');
        listOfGifts.innerHTML = '';
        listOfGiftsArray.push(input.value);
        listOfGiftsArray.sort((a,b) => a.localeCompare(b)).forEach(x=> {listOfGifts.appendChild(createLiElement(x));})
        input.value = '';

    });

    function createLiElement(gift) {
        let liElement = document.createElement('li');
        liElement.classList.add('gift');
        liElement.textContent = gift;

        let buttonOne = document.createElement('button');
        buttonOne.textContent = 'Send';
        buttonOne.setAttribute('id','sendButton');
        buttonOne.addEventListener('click', send);

        let buttonTwo = document.createElement('button');
        buttonTwo.textContent = 'Discard';
        buttonTwo.setAttribute('id','discardButton');
        buttonTwo.addEventListener('click',discard);

        liElement.appendChild(buttonOne);
        liElement.appendChild(buttonTwo);

        return liElement;
    }

    function send(e) {
        let parentElement = e.target.parentElement;
        let text = e.target.parentElement.childNodes[0].nodeValue;
        listOfGiftsArray = listOfGiftsArray.filter(x=> x != text);

        e.target.nextElementSibling.remove();
        e.target.remove();

        const sentGifts = sections[2].querySelector('ul');
        sentGifts.appendChild(parentElement);
    }
    function discard(e) {
        let parentElement = e.target.parentElement;
        let text = e.target.parentElement.childNodes[0].nodeValue;
        listOfGiftsArray = listOfGiftsArray.filter(x=> x != text);
        e.target.previousElementSibling.remove();
        e.target.remove();

        const discardGifts = sections[3].querySelector('ul');
        discardGifts.appendChild(parentElement);
    }
}