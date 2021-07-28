
export const settings = {
    host: '',
}

async function request(url,options){
    try {
        const response = await fetch(url,options);

        if (response.ok == false) {
            const error = await response.json();
            throw new Error(error.message);
        }

        try {
            return await response.json();
        } catch (error) {
            return response;
        }
    } catch (error) {
        throw error;
    }
}

function createOptions(method = 'get',data){
    const result = {
        method,
        headers: {},
    }
    
    if (data) {
        result.headers['Content-Type']='application/json';
        result.body = JSON.stringify(data);
    }

    const token = sessionStorage.getItem('userToken');

    if (token) {
        result.headers['X-Authorization'] = token;
    }

    return result;
}

export async function get(url) {
    return request(url,createOptions('get'))
}

export async function post(url,data){
    return request(url,createOptions('post',data))
}

export async function put(url,data){
    return request(url,createOptions('put',data))
}

export async function del(url){
    return request(url,createOptions('delete'));
}

export async function login(email,password) {
    const response = await post(settings.host + '/users/login',{email,password});
    
    sessionStorage.setItem('userId',response._id);
    sessionStorage.setItem('userToken',response.accessToken);
    sessionStorage.setItem('email',email);
    sessionStorage.setItem('gender',response.gender);
    sessionStorage.setItem('username',response.username);

    return response;
}

export async function register(username,email,password,gender) {
    const response = await post(settings.host + '/users/register',{username,email,password,gender});

    sessionStorage.setItem('userId',response._id);
    sessionStorage.setItem('userToken',response.accessToken);
    sessionStorage.setItem('email',email);
    sessionStorage.setItem('gender',gender);
    sessionStorage.setItem('username',response.username);

    return response;
}

export async function logout(){
    return await get(settings.host + '/users/logout');
}