function solve() {
    let resultArray = [];
    
    let text = document.querySelector('.shopping-cart textarea');
    Array
        .from(document.querySelectorAll('.add-product'))
        .map(x => x.addEventListener('click', function addProduct(e) {
            let price = Number(e.currentTarget.parentNode.nextElementSibling.innerHTML).toFixed(2);
            let product = e.currentTarget.parentNode.previousElementSibling.firstElementChild.innerHTML;

            let productObj = {};
            productObj.name = product;
            productObj.price = Number(price);
            resultArray.push(productObj);

            text.innerHTML += `Added ${product} for ${price} to the cart.\n`;
        }));

    document.querySelector('.checkout').addEventListener('click', function () {
        let uniqueNames = [];
        for (let i = 0; i < resultArray.length; i++) {
            if (!uniqueNames.includes(resultArray[i].name)) {
                uniqueNames.push(resultArray[i].name)
            }
        }

        text.innerHTML += `You bought ${uniqueNames.map(x=> x).join(', ')} for ${resultArray.map(x=> Number(x.price)).reduce((acc,el) => acc + el,0).toFixed(2)}.`;
        Array
            .from(document.querySelectorAll('.add-product'))
            .map(x=> x.disabled = true);

        document.querySelector('.checkout').disabled = true;
    });
}