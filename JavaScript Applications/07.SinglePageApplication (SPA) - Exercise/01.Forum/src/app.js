import {setupPost,showPost} from './post.js'
import {setupComment} from './comment.js'
main();

const links = {
    'homeLink':showPost,
}
function main() {
  const nav = document.querySelector('nav');
  const mainSection = document.querySelector('main');
  const postSection = document.getElementById('postSection');
  const commentSection = document.getElementById('commentSection');

  setupPost(mainSection,postSection);
  setupComment(mainSection,commentSection);

  showPost();
  setupNavigation();
  function setupNavigation() {
    nav.addEventListener('click', (e)=> {
        if (e.target.id == 'homeLink') {
            const view = links[e.target.id];
            if (typeof view == 'function') {
                view();
            }
        }
    })
  }
}