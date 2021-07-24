export const settings = {
    host: '',
}

async function request(url, options) {
    try {
        const response = await fetch(url, options);

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

function createOptions(method = 'get', data) {
    const result = {
        method,
        headers: {}
    }

    if (data) {
        result.headers['Content-Type'] = 'application/json';
        result.body = JSON.stringify(data);
    }

    const token = sessionStorage.getItem('userToken');

    if (token) {
        result.headers['X-Authorization'] = token;
    }

    return result;
}

export async function get(url) {
    return request(url, createOptions());
}

export async function post(url, data) {
    return request(url, createOptions('post', data))
}

export async function put(url, data) {
    return request(url, createOptions('put', data))
}

export async function del(url) {
    return request(url, createOptions('delete'));
}

export async function login(email, password) {

    const response = await post('http://localhost:3030/users/login', { email, password });

    sessionStorage.setItem('userToken', response.accessToken);
    sessionStorage.setItem('username', response.username);
    sessionStorage.setItem('userId', response._id);

    return response;
}

export async function register(email, username, password) {

    const response = await post('http://localhost:3030/users/register', { email, username, password });

    sessionStorage.setItem('userToken', response.accessToken);
    sessionStorage.setItem('username', response.username);
    sessionStorage.setItem('userId', response._id);
}

export async function logout() {
    const response = await get('http://localhost:3030/users/logout');

    sessionStorage.removeItem('userToken');
    sessionStorage.removeItem('username');
    sessionStorage.removeItem('userId');

    return response;
}