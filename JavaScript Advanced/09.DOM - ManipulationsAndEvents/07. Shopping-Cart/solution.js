function solve() {
   document.querySelector('.shopping-cart').addEventListener('click',addProduct);
   document.querySelector('.checkout').addEventListener('click',checkout);
   let cart = [];
   let resultText = document.querySelector('textarea');
   function addProduct(ev) {
      if (ev.target.tagName == 'BUTTON' && ev.target.className == 'add-product') {
         let parent = ev.target.parentNode.parentNode;
         let productName = parent.querySelector('.product-title').textContent;
         let productPrice = Number(parent.querySelector('.product-line-price').textContent);
         cart.push({productName,productPrice});
         resultText.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`
      }
   }
   function checkout(ev) {
      let result = cart.reduce((acc,el) => {
         if (!acc.items.includes(el.productName)) {
            acc.items.push(el.productName);
         }
         acc.total += el.productPrice;
         return acc;
      },{items: [], total: 0});

      resultText.textContent += `You bought ${result.items.join(', ')} for ${result.total.toFixed(2)}.`
      let buttons = Array.from(document.querySelectorAll('button'));
      buttons.forEach(x=> x.disabled = true);
   }
}