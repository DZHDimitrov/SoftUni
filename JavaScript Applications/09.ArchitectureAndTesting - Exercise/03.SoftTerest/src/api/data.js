import * as api from './api.js';

const host = 'http://localhost:3030';
api.settings.host = host;

export const login = api.login;
export const register=  api.register;
export const logout = api.logout;

export async function getIdeas(){
    return await api.get('http://localhost:3030/data/ideas?select=_id%2Ctitle%2Cimg&amp;sortBy=_createdOn%20desc');
}

export async function getIdeaById(id) {
    return await api.get('http://localhost:3030/data/ideas/'+id);
}

export async function postNewIdea(data){
    return await api.post('http://localhost:3030/data/ideas',data);
}

export async function deleteIdeaById(id) {
    return await api.del('http://localhost:3030/data/ideas/'+id);
}