import axios from 'axios';

const API = axios.create({
    baseURL: 'http://39.106.47.60:5194/',
    timeout: 5000,
    async: true,
    crossDomain: true,
})

export const getVolunteerContent = async () => {
    const response = await API.get('/recruit/random');
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

export const postRecruitment = async (recruitment) => {
    const content = `招募名称：${recruitment.name}\n招募描述：${recruitment.description}\n招募时间：${recruitment.time}\n招募地点：${recruitment.location}\n招募人数：${recruitment.size}\n招募要求：${recruitment.requirement}\n联系方式：${recruitment.contact}`;
    const volunteerRecruit = {
        RecruitmentId: "",
        GardenId: "001",
        RecruiterId: "1",
        RecruitTime: new Date(),
        RecruitContent: content
    };

    console.log("API postRecruimentComment : ", volunteerRecruit);

    const formData = new FormData();
    formData.append("volunteerRecruitJson", JSON.stringify(volunteerRecruit));

    const response = await API.post("/recruit/post", formData);
    return response.data;
};