
const settings = {
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
            const data = await response.json();
            return data; 
        } catch (error) {
            return response;
        }
        
    } catch (error) {
        alert(error.message);
        throw error;
    }
}

function createOptions(method='get',data){
    const result = {
        method,
        headers: {},
    };

    if (data) {
        result.headers['Content-Type'] = 'application/json';
        console.log(data);
        result.body = JSON.stringify(data);
    }
    const token = sessionStorage.getItem('userToken');

    if (token) {
        result.headers['X-Authorization'] = token;
    }

    return result;
}

async function get(url) {
    return request(url,createOptions());
}

async function post(url,data) {
    return request(url,createOptions('post',data))
}

async function put(url,data){
    return request(url,createOptions('put',data))
}

async function del(url) {
    return request(url,createOptions('delete'))
}

async function login(email,password) {
    const userInfo = await post('http://localhost:3030/users/login',{email,password});
    
    sessionStorage.setItem('userId',userInfo._id);
    sessionStorage.setItem('email',userInfo.email);
    sessionStorage.setItem('userToken',userInfo.accessToken);

    return userInfo;
}

async function register(email,password) {
    const userInfo = await post('http://localhost:3030/users/register',{email,password});

    sessionStorage.setItem('userId',userInfo.userId);
    sessionStorage.setItem('email',userInfo.email);
    sessionStorage.setItem('userToken',userInfo.accessToken);

    return userInfo;
}

async function logout() {
    const userInfo = await get('http://localhost:3030/users/logout',createOptions('get'));

    sessionStorage.removeItem('username');
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('userToken');

    return userInfo;
}

export {
    settings,
    register,
    login,
    logout,
    get,
    post,
    put,
    del,
}