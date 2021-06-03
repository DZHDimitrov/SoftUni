function attachGradientEvents() {
    document.querySelector('#gradient').addEventListener('mousemove',onMove)
    let resultElement = document.querySelector('#result');
    function onMove(ev) {
        const result = ev.offsetX / ev.target.clientWidth * 100;
        resultElement.textContent = Math.floor(result) + '%';
    }
}