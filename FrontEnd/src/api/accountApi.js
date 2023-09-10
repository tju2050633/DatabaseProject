/*
 * @Author: Jialin Lu
 * @GitHub: https://github.com/tju2050633
 * @Date: 2023-09-06 10:06:06
 * @FilePath: /SharingGardenProject/FrontEnd/src/api/accountApi.js
 * @Description: 
 * 
 * Copyright (c) 2023 by 1640889387@qq.com, All Rights Reserved. 
 */
//导入axios
import axios from 'axios'

const API = axios.create({
	baseURL:'http://39.106.47.60:5194/', 
    timeout: 3000,                   
    async:true,
    crossDomain:true,
})

export const getUserNameById = async (userId) => {
    const response = await API.get("/user/name", {
        params: {
            userId: userId,
        }
    });
    return response.data;
};

export const getUserAvatarById = async (userId) => {
    const response = await API.get("/user/avatar", {
        params: {
            userId: userId,
        }
    });
    return response.data;
};