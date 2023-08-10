import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5194/api/',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

export const getVolunteerContent = async (recruitment_id) => {
    const response = await API.get(`/Volunteer_Recruitment/${recruitment_id}`);
    return response.data;
};

export const getVolunteerList = async (account_id) => {
    const response = await API.get(`/Account/${account_id}`);
    return response.data;
};

export const submitForm = async (apply_id) => {
    const response = await API.post(`/Volunteer_Apply/${apply_id}`);
    return response.data;
};