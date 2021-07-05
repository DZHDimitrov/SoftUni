function attachEvents() {
    document.getElementById('btnLoadPosts').addEventListener('click',loadPosts);
    document.getElementById('btnViewPost').addEventListener('click',createHeadingAndBody);
}

function loadPosts() {
    const posts = document.getElementById('posts');

    if (posts.children.length > 0) {
        return;
    }

    const url = 'http://localhost:3030/jsonstore/blog/posts';

    //AJAX request
    fetch(url)
        .then(response => response.json())
        .then(data => {
            Object.values(data)
                  .forEach(el => 
                    posts.appendChild(createOption(el.title,el.id)));
        })
        .catch(error => {
            alert('Not found');
        })
}

function getComments(id) {
    const postComments = document.getElementById('post-comments');
    postComments.innerHTML = '';

    const url = 'http://localhost:3030/jsonstore/blog/comments';

    //AJAX request
    fetch(url)
        .then(response => response.json())
        .then(data => {
            let comments = Object.values(data).filter(x=>x.postId == id);
            comments.forEach(comment => {
                const liElement = document.createElement('li');
                liElement.textContent = comment.text;
                
                postComments.appendChild(liElement);
            })
        })
        .catch(error => {
            alert('No comments found!')
        })
}

function createHeadingAndBody(e) {
    const postTitle = document.getElementById('post-title');
    const postBody = document.getElementById('post-body');

    postTitle.innerHTML = '';
    postBody.innerHTML = '';
    const id = e.target.previousElementSibling.value;

    const url = 'http://localhost:3030/jsonstore/blog/posts/' + id;

    //AJAX request
    fetch(url)
        .then(response => response.json())
        .then(data => {
            postTitle.textContent = data.title;
            postBody.textContent = data.body;
            getComments(id);
        })
        .catch(error => {
            alert('Error')
        })
}

function createOption(title,id) {
    const option = document.createElement('option');
    option.value = id;
    option.textContent = title;

    return option;
}

attachEvents();