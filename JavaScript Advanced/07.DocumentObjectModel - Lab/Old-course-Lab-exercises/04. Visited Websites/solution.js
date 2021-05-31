function solve() {
  // let linkElements = document.getElementsByClassName('link-1');
   let linkElements = document.querySelectorAll('.link-1 a');

  for (const linkElement of linkElements) {
    linkElement.addEventListener('click', onLinkElementClick)
  }

  function onLinkElementClick(e) {
    let sibling = e.currentTarget.nextElementSibling;
    let visitedCount = Number(sibling.innerHTML.split(' ')[1]);
    visitedCount++;
    sibling.innerHTML = `visited ${visitedCount} times`;
    console.log(visitedCount);
  }
}