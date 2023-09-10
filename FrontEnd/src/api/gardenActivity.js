import axios from 'axios';

const API = axios.create({
    baseURL: 'http://39.106.47.60:5194',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

export const getGardenActivities = async () => {
    const response = await API.get('/activities/get');
    console.log("API getGardenActivities response.data: ", response.data);
    return response.data;
};

// post报名信息
// export function postRegisInfo(data1,data2) {
//     let param=new
//     URLSearchParams({Id:data1,gardenActId:data2})
//     return request({
//         url: '/order/feedback',
//         method: 'post',
//         data: param
//     })
// }