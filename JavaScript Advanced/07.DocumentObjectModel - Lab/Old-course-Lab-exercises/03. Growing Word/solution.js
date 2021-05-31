function growingWord() {
  let parentElement = document.getElementById('exercise');
  let growingWordElement = parentElement.lastElementChild;
  let colorsList = document.getElementById('colors');

  if (!growingWordElement.style.fontSize) {
      growingWordElement.style.fontSize = '2px';
  } else {
    growingWordElement.style.fontSize = parseInt(growingWordElement.style.fontSize) * 2 + 'px';
  }
  
  let firstColorElement = colorsList.firstElementChild;
  let color = colorsList.firstElementChild.innerHTML.toLowerCase();

  growingWordElement.style.color = color;

  colorsList.appendChild(firstColorElement);
}