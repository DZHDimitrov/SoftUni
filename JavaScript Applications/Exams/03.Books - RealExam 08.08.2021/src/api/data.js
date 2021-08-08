import * as api from './api.js';

const host = 'http://localhost:3030';
api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;


export async function getAll(){
    return await api.get(host + '/data/books?sortBy=_createdOn%20desc');
}

export async function getById(id){
    return await api.get(host + '/data/books/' + id);
}

export async function createNew(data) {
    return await api.post(host + '/data/books',data);
}

export async function editById(id,data){
    return await api.put(host + '/data/books/' + id,data);
}

export async function deleteById(id){
    return await api.del(host + '/data/books/' + id);
}

export async function getUserBooks(userId) {
    return await api.get(host + `/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function createLike(data){
    return await api.post(host + '/data/likes',data);
}

export async function getTotalCountOfLikesForBook(bookId) {
    return await api.get(host + `/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);
}

export async function getLikesForBookFromASpecificUser(bookId,userId){
    return await api.get(host + `/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}