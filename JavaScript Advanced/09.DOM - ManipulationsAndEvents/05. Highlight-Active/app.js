function focused() {
    let elements = Array.from(document.querySelectorAll('[type="text"]'));
    elements.forEach(x=> {
        x.addEventListener('focus',onFocus)
        x.addEventListener('blur',onBlur)
    })

    function onFocus(ev) {
        ev.currentTarget.parentNode.className = 'focused';
    }

    function onBlur(ev) {
        ev.currentTarget.parentNode.className = '';
    }
}