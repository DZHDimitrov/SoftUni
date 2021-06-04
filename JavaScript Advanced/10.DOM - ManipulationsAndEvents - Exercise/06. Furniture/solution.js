function solve() {
  let generateButtonElement = Array.from(document.querySelectorAll('#exercise button'));
  let table = document.querySelector('#exercise tbody');
  Array.from(document.querySelectorAll('[type="checkbox"]')).map(x => x.removeAttribute('disabled'));
  let textAreas = Array.from(document.getElementsByTagName('textarea'));
  generateButtonElement[0].addEventListener('click', generate);
  generateButtonElement[1].addEventListener('click', buy);

  function generate(ev) {
    let json = JSON.parse(textAreas[0].value);
    json.forEach(x=> {
      let tds = [];
      tds.push(createElement('td',`<img src=${x.img}>`));
      tds.push(createElement('td',`<p>${x.name}</p>`));
      tds.push(createElement('td',`<p>${Number(x.price)}</p>`));
      tds.push(createElement('td',`<p>${Number(x.decFactor)}</p>`));
      tds.push(createElement('td',`<input type="checkbox" />`));

      

      let trElement = createElement('tr');
      tds.forEach(x=> trElement.appendChild(x));

      table.appendChild(trElement);
      console.log(trElement);

    });
    function createElement(tag, content) {
      console.log(content);
      let element = document.createElement(tag);
      if (content != undefined) {

        element.innerHTML = content;
      }
      console.log(element.innerHTML);
      return element;
    };
  };
  function buy() {
    let checkBoxes = Array.from(document.querySelectorAll('[type="checkbox"]'));
    checkBoxes.forEach(x => x.removeAttribute('disabled'));
    let checkedBoxes = checkBoxes.filter(x => x.checked == true);

    let resultArray = [];
    checkedBoxes.forEach(x => {
      let parent = x.parentNode.parentNode;
      let paragraphs = Array.from(parent.querySelectorAll('p')).map(x => x.innerHTML);
      let [productName, productPrice, average] = paragraphs;
      productPrice = Number(productPrice);
      average = Number(average);
      let obj = { productName, productPrice, average };
      resultArray.push(obj);
    });

    let result = resultArray.reduce((acc, el) => {
      acc.boughtFurniture.push(el.productName);
      acc.totalPrice += el.productPrice;
      acc.average += el.average;
      return acc;
    }, { boughtFurniture: [], totalPrice: 0, average: 0 });
    let resultElement = generateButtonElement[1].previousElementSibling;
    console.log(resultElement);
    resultElement.value = `Bought furniture: ${result.boughtFurniture.join(', ')}\n` + `Total price: ${result.totalPrice.toFixed(2)}\n` + `Average decoration factor: ${result.average / resultArray.length}`
  }
};