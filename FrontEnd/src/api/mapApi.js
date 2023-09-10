import axios from 'axios';

const API = axios.create({
    baseURL: 'http://39.106.47.60:5194/api/',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

export const postLocation = async (lng,lat) => {
    const response = await API.post('/map/', { lng,lat });
    return response.data;
};