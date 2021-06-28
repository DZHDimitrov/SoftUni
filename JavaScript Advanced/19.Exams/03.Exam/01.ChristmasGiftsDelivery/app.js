function solution() {
    const sections = Array.from(document.querySelectorAll('section'));
    const [addGift,listOfGifts,sentGifts,discardedGifts] = sections;
    const addBtn = sections[0].querySelector('button');
    addBtn.addEventListener('click',add)

    function add(e){
        e.preventDefault();
        const input = addGift.querySelector('input');
        const inputValue = input.value;
        input.value = '';

        const outputList = listOfGifts.querySelector('ul');
        
        const liElement = document.createElement('li');
        liElement.classList.add('gift');
        liElement.textContent = inputValue;
        
        const sendBtn = document.createElement('button');
        sendBtn.setAttribute('id','sendButton');
        sendBtn.textContent = 'Send';
        sendBtn.addEventListener('click',send)

        const discardBtn = document.createElement('button');
        discardBtn.setAttribute('id','discardButton');
        discardBtn.textContent = 'Discard'
        discardBtn.addEventListener('click',discard)

        liElement.appendChild(sendBtn);
        liElement.appendChild(discardBtn);

        outputList.appendChild(liElement);

        Array.from(outputList.children)
        .sort((a,b) =>
             a.textContent.localeCompare(b.textContent))
        .forEach(x=> outputList.appendChild(x));
    }
    function send(e){
        const currentParrent = e.target.parentElement;
        Array.from(currentParrent.children).forEach(x=> x.remove())
        const outputList = sentGifts.querySelector('ul');
        outputList.appendChild(currentParrent);
    }
    function discard(e){
        const currentParrent = e.target.parentElement;
        Array.from(currentParrent.children).forEach(x=> x.remove())
        const outputList = discardedGifts.querySelector('ul');
        outputList.appendChild(currentParrent);
    }
}