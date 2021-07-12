import { e } from './dom.js'
import {getDate,date} from './common.js'

async function getPostById(id){
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts/'+ id)
    const data = await response.json();
    return data;
}

async function getAllComments(id){
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments');
    const data = await response.json();
    let filteredComments = Object.values(data).filter(value => value.postId == id);
    console.log(filteredComments);
    return filteredComments;
}

async function postComment(event,data){
    if (!data.postText || !data.username) {
        return alert('All fields are required!')
    }
    const body = JSON.stringify({
        content: data.postText,
        username: data.username,
        postId,
    });

    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments',{
        method: 'POST',
        headers: {'Content-Type':'application/json'},
        body,
    })

    const responseData = await response.json();
    if (response.status == 200) {
        section.querySelector('#user-comment').appendChild(createCommentElement(responseData));
        event.target.reset();
    }
}

function createHeader(post) {
    const headerElement =
        e('div', { className: 'header' },
            e('img', { src: "./static/profile.png", alt: 'avatar' }),
            e('p', {},
                e('span', {}, `${post.username}`),
                ' posted on ',
                e('time', {}, `${post.createdOn}`)),
            e('p', { className: 'post-content' }, post.postText));
    return headerElement;
}

function createCommentElement(data) {
    const currentDate = date;
    const commentElement = e('div',{className: 'topic-name-wrapper'},
        e('div',{className:'topic-name'},
            e('p',{},
                e('strong',{},data.username),
                ' commented on ',
                e('time',{},currentDate)),
            e('div',{className:'post-content'},
                e('p',{},data.content))));
    return commentElement;
}

let main;
let section;
let postId;

export function setupComment(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;

    section.querySelector('form').addEventListener('submit',(e) => {
        e.preventDefault();
        const formData = new FormData(e.target)
        postComment(e,[...formData.entries()].reduce((p,[k,v])=> Object.assign(p,{[k]:v}),{}));
        
    })
}

export async function showComment(id) {
    postId = id;
    main.innerHTML = '';
    const commentDiv = section.querySelector('.comment');
    const fragment = document.createDocumentFragment();

    if (commentDiv.children.length > 1) {
        commentDiv.firstElementChild.remove();
    };
    section.querySelector('#user-comment').innerHTML = '';

    const data = await Promise.all([getPostById(id),getAllComments(id)]);
    const postData = data[0];
    const commentsByPostId = data[1];

    commentDiv.insertAdjacentElement('afterbegin',createHeader(postData));
    section.querySelector('#title').textContent = postData.topicName;
    commentsByPostId.forEach(x=> fragment.appendChild(createCommentElement(x)));
    section.querySelector('#user-comment').appendChild(fragment)

    main.appendChild(section);
}