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

export const fetchAllItemID = async () => {
    const response = await API.get('/items/all_id');
    return response.data;
};

export const fetchItemInfo = async (itemId) => {
    const response = await API.get('/items/info', {
        params: {
            itemId: itemId.toString()
    } });
    return response.data;
};

export const performExchange = async (itemId, userId) => {
    const response = await API.post('/exchange', { 
            itemId: itemId.toString(),
            userId: userId.toString()
        });
    return response.data;
};

export const getItemCoverImage = async (itemId) => {
    const response = await API.get('/items/cover', {
        params: {
            itemId: itemId.toString()
        }
    });
    return response.data;
}

export const getItemImages = async (itemId) => {
    const response = await API.get('/items/images', {
        params: {
            itemId: itemId.toString()
    } });
    return response.data;
}