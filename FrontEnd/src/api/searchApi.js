import axios from 'axios';

const API = axios.create({
    baseURL: 'http://39.106.47.60:5194/',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

export const getSearchResults = async (searchTerm) => {
    const response = await API.get(`/Search`,{ params: { searchTerm } });
    return response.data;
};