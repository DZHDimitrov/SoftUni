function search() {
   let searchText = document.getElementById('searchText').value;
   let resultElement = document.getElementById('result')
   let listItems = Array.from(document.querySelectorAll('#towns li'));
   let validOptions = listItems.map(x=> x.innerHTML);
   console.log(searchText);
   if (validOptions.some(x=> x.includes(searchText))) {
      let array = listItems.filter(x=> x.innerHTML.includes(searchText)).map(x=> {
         x.style.textDecoration = 'underline';
         x.style.fontWeight = 'bolder';
      });

      resultElement.innerHTML = `${array.length} matches found`
   }
}
