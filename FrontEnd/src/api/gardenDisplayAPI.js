/*
 * @Author: Jialin Lu
 * @GitHub: https://github.com/tju2050633
 * @Date: 2023-08-26 21:40:51
 * @FilePath: /SharingGardenProject/FrontEnd/src/api/gardenDisplayAPI.js
 * @Description: 
 * 
 * Copyright (c) 2023 by 1640889387@qq.com, All Rights Reserved. 
 */
import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5194',
    timeout: 3000,
    async: true,
    crossDomain: true,
})


// getGardenList 提供userid，需要返回一个数组，具体形式如下：
      //花园排行榜
//       GardenList: [
//         {
//           imageurl: require("../assets/Garden.jpg"),
//           description: "TOP1 Garden",
//         },
//       ],
export const getGardenList = async () => {
    try {
        const response = await API.get(`/randon/`);
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};

// get garden methods

export const getHotGarden = async () => {
    const response = await API.get('/garden/random');
    return response.data;
};

export const getNewGarden = async () => {
    const response = await API.get('/garden/random');
    return response.data;
};

export const getMyGarden = async () => {
    const response = await API.get('/garden/random');
    return response.data;
};