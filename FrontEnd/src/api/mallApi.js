import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5194',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

export const fetchMyPoints = async (userId) => {
    const response = await API.get('/user/points', {
        params: {
            userId: userId.toString()
        }});
    return response.data;
};

export const fetchItemCounts = async (itemId) => {
    const response = await API.get('/items', {
        params: {
            itemId: itemId.toString()
    } });
    return response.data;
};

export const performExchange = async (itemId, userId) => {
    const response = await API.post('/exchange', { itemId: itemId, userId: userId });
    return response.data;
};