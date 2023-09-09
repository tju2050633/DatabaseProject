/*
 * @Author: Jialin Lu
 * @GitHub: https://github.com/tju2050633
 * @Date: 2023-08-26 21:40:51
 * @FilePath: /SharingGardenProject/FrontEnd/src/api/gardenAPI.js
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

export const getGardenInfo = async (garden_id) => {
    const response = await API.get('/garden/info', {
        params: {
            garden_id: garden_id.toString()
        }
    });
    return response.data;
};

export const getGardenIdByUserId = async (user_id) => {
    console.log("API getGardenIdByUserId user_id: ", user_id);
    const response = await API.get('/garden/user', {
        params: {
            user_id: user_id.toString()
        }
    });
    console.log("API getGardenIdByUserId data: ", response.data);
    return response.data;
};

export const getGardenNameById = async (garden_id) => {
    const response = await API.get('/garden/name', {
        params: {
            garden_id: garden_id.toString()
        }
    });
    return response.data;
};

export const getComments = async (garden_id) => {
    const response = await API.get('/garden/comments', {
        params: {
            garden_id: garden_id.toString()
        }
    });
    return response.data;
};

export const postComment = async (user_id, garden_id, content) => {

    let commentInfo = {
        userId: user_id,
        gardenId: garden_id,
        content: content
    }

    const formData = new FormData();
    formData.append('commentJson', JSON.stringify(commentInfo));

    const response = API.post('/garden/comment', formData);
    return response;
};