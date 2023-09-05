import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5194',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

export const fetchMyPoints = async () => {
    const response = await API.get('/user/points');
    return response.data;
};

export const fetchItemCounts = async (itemId) => {
    const response = await API.get('/items', {
        params: {
            itemId: itemId.toString()
    } });
    return response.data;
};

export const performExchange = async (itemId) => {
    const response = await API.post('/exchange', { itemId: itemId });
    return response.data;
};