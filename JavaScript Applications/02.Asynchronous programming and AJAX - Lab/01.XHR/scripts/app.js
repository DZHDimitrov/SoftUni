function loadRepos() {
   let url = 'https://api.github.com/users/testnakov/repos';
   test();
  async function test() {
     let a = await fetch(url);
     let test  = await a.json();
     document.getElementById('res').textContent = JSON.stringify(test);
  }
}