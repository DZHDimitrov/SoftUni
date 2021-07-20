import * as api from '../api/api.js';

const host = 'http://localhost:3030/data/catalog';
api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function createFurniture(data) {
    return  await api.post(host,data);
}

export async function getAllFurniture() {
    return await api.get(host);
}

export async function getFurnitureDetails(id){
    return await api.get(host + `/${id}`);
}

export async function updateFurniture(id,data){
    return await api.put(host + `/${id}`,data);
}

export async function deleteFurniture(id) {
    return await api.del(host + `/${id}`);
}

export async function getMyFurniture(userId) {
    return await api.get(host + `?where=_ownerId%3D%22${userId}%22`);
}

