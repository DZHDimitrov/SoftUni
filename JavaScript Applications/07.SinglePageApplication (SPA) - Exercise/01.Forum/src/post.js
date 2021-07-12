import { e } from './dom.js'
import { showComment } from './comment.js';
import {date} from './common.js'

document.querySelector('form').addEventListener('submit', (e) => {
    e.preventDefault();

    const formData = new FormData(e.target);
    onCreateSubmit([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
    e.target.reset();
})

document.querySelector('#cancelBtn').addEventListener('click',(e) => {
    e.target.parentNode.previousElementSibling.reset();
})

function createPost(post) {
    const postElement =
        e('div', { className: 'topic-name-wrapper' },
            e('div', { className: 'topic-name' },
                e('a', { href: '#', className: 'normal' },
                    e('h2', {}, post.topicName)),
                e('div', { className: 'columns' },
                    e('div', {},
                        e('p', {},
                            'Date:',
                            e('time', {}, post.createdOn)),
                        e('div', { className: 'nick-name' },
                            e('p', {},
                                'Username: ',
                                e('span', {}, post.username)))))));

    postElement.setAttribute('data-id', post._id);
    return postElement;
}

async function getAllPosts() {
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');
    const data = await response.json();
    let posts = [...Object.values(data)].map(x => {
        return Object.entries(x).reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {});
    });
    return posts;
}

async function onCreateSubmit(data) {
    if (!data.topicName || !data.username || !data.postText) {
        return alert('All fields are required!')
    }
    const body = JSON.stringify({
        topicName: data.topicName,
        username: data.username,
        postText: data.postText,
        createdOn: date,
    });

    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body
    });
    const responseData = await response.json();
    if (response.status == 200) {
        const container = section.querySelector('.topic-title .topic-container');
        container.appendChild(createPost(responseData));
    } else {
        console.error(responseData.message)
    }
}

let main;
let section;

export function setupPost(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;

    const container = section.querySelector('.topic-title .topic-container');
    container.addEventListener('click', (e) => {
        if (!e.target.classList.contains('topic-container')) {
            e.preventDefault();
            const parentDiv = e.target.closest('div.topic-name-wrapper');
            const postId = parentDiv.dataset.id;
            showComment(postId);
        }
    })
}

export async function showPost() {
    main.innerHTML = '';
    const posts = await getAllPosts();
    const container = section.querySelector('.topic-title .topic-container');
    container.innerHTML = '';
    main.appendChild(section);
    posts.forEach(x => container.appendChild(createPost(x)))
}