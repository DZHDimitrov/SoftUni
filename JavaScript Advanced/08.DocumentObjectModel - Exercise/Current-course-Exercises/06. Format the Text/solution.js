function solve() {
  let text = document.getElementById('input').value;
  let resultElement = document.getElementById('output')
  let sentences = text.split('.').filter(x => x.length >= 1);
  while (sentences.length > 0) {
    let currentParagraph = sentences.splice(0,3).join('.') + '.';
    let newElement = document.createElement('p');
    newElement.innerHTML += currentParagraph;
    resultElement.appendChild(newElement);
  }
}