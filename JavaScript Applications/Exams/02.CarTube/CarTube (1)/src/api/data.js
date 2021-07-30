import * as api from './api.js'



export const login = api.login;
export const register = api.register;
export const logout = api.logout;

const host = 'http://localhost:3030'

api.settings.host = host;

export async function getAllCars() {
    return await api.get(host+ '/data/cars?sortBy=_createdOn%20desc');
}

export async function getCarById(id) {
    return await api.get(host+ '/data/cars/'+id);
}

export async function updateCarById(id,data){
    return await api.put( host+ '/data/cars/'+id,data);
}

export async function createCar(data) {
    return await api.post(host+'/data/cars',data);
}

export async function deleteCarById(id) {
    return await api.del(host+'/data/cars/'+id);
}

export async function getMyCars(userId) {

    return await api.get(`http://localhost:3030/data/cars?where=_ownerId%3D%22${userId}%22&amp;sortBy=_createdOn%20desc`);
}

