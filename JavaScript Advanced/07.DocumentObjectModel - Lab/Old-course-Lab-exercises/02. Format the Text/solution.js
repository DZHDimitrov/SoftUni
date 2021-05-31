function solve() {
   let parentElement = document.getElementById('exercise');
   let paragraphElement = parentElement.firstElementChild;
   let outputElement = document.getElementById('output');
   let paragraphs = paragraphElement.innerHTML.split('.');
  
   
   while (paragraphs.length > 0) {
     let currentParagraph = paragraphs.splice(0,3).join('.') + '.';
     let newElement = document.createElement('p');
     newElement.innerHTML += currentParagraph;
     outputElement.appendChild(newElement);
   }
}