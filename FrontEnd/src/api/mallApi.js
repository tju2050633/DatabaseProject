import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5194/api/',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

export const fetchItemCounts = async (itemId) => {
    const response = await API.get(`/items/${itemId}`);
    return response.data;
};

export const fetchMyPoints = async () => {
    const response = await API.get('/user/points');
    return response.data;
};

export const performExchange = async (itemId) => {
    const response = await API.post('/exchange', { itemId });
    return response.data;
};