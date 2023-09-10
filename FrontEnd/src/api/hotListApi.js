
import axios from 'axios';

const API = axios.create({
    baseURL: 'http://39.106.47.60:5194',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

export const getHotGardens = async (cur_num, len) => {
    const response = await API.get('/garden/hot', {
        params: {
            cur_num,
            len
        }
    });
    return response.data;
};

export const getHotBlogs = async (cur_num, len) => {
    const response = await API.get('/blog/hot', {
        params: {
            cur_num,
            len
        }
    });
    return response.data;
};
