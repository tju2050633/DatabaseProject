import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5194/',
    timeout: 5000,
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

//修改后的报名申请
export const submitForm = async (apply_id, description) => {
    const response = await API.post(`/Volunteer/apply`+'?id='+apply_id+'&description=' + description);
    return response.data;
};


//创建申请招募信息的API
export const getMoreRecruits = async (startNum, num) => {
    const response = await API.get(`/Volunteer/moreRecruits`, { params: { startNum, num } });
    return response.data;
};

//创建获取积分排名信息的请求
export const getTopPointsList = async () => {
    const response = await API.get(`/Volunteer/TopPointsList`);
    return response.data;
};