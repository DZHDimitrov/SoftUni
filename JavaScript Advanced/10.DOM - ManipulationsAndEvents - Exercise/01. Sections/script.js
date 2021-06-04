function create(words) {
   let parentElement = document.getElementById('content');
   words.forEach(x => {
      let div = createElement('div');
      div.addEventListener('click',show)
      let paragraph = createElement('p', x);
      paragraph.style.display = 'none';
      div.appendChild(paragraph);
      parentElement.appendChild(div);
   });


   function show () {
      console.log(this.firstElementChild.style = 'block');
   }
   function createElement(type, content) {
      let element = document.createElement(type);
      if (content) {
         element.textContent = content;
      }
      return element;
   }
}