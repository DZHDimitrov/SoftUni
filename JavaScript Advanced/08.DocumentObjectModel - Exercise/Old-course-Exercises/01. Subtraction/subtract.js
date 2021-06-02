function subtract() {
    let elements = Array.from(document.querySelectorAll('input'));
    elements.forEach(x=> console.log(x.value));
    let result = elements.reduce((acc,el,index) => {
        if (index > 0) {
            return acc-Number(el.value);
        }
        return Number(el.value);
    },0);
    document.querySelector('#result').innerHTML = result;
}