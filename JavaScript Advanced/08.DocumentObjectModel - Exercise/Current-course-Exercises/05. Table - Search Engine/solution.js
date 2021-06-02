function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchText = document.getElementById('searchField').value;
      let rowElements = Array.from(document.querySelectorAll('.container tbody tr'))
      rowElements.map(x=> x.classList.remove('select'));
      rowElements.forEach(x=> {
         for (let i = 0; i < x.children.length; i++) {
            if (x.children[i].innerHTML.includes(searchText)) {
               let parentElement = x.classList.add('select');
               break;
            }
         }
      })

   }
}