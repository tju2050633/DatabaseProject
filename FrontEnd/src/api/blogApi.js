/*
 * @Author: Jialin Lu
 * @GitHub: https://github.com/tju2050633
 * @Date: 2023-09-06 19:42:12
 * @FilePath: /SharingGardenProject/FrontEnd/src/api/blogApi.js
 * @Description: 
 * 
 * Copyright (c) 2023 by 1640889387@qq.com, All Rights Reserved. 
 */
import axios from 'axios';

axios.defaults.headers.common['Content-Type'] = 'application/json';

const API = axios.create({
    baseURL: 'http://localhost:5194',
    timeout: 5000,
    async: true,
    crossDomain: true,
})

//获取更多的博客
//startNum决定从数据库的哪一条开始读取，num决定数量
export const getMoreBlogs = async (startNum, num) => {
    const response = await API.get('/blog/moreblogs',{ params: { startNum, num } });
    return response.data;
};

//获取博客对应的评论
export const getBlogComments = async (blog_id) => {
    const response = await API.get('/blog/comments',{ params: { blog_id } });
    return response.data;
};

// 提交评论
export const postBlogComment = async (owner_id, blog_id, content) => {
    const comment = {
        blogCommentId: "0",
        ownerId: owner_id,
        blogId: blog_id,
        content: content,
        releaseTime: new Date(),
    };

    console.log("API postBlogComment : ", comment);

    const formData = new FormData();
    formData.append("commentJson", JSON.stringify(comment));

    const response = await API.post("/blog/comments/post", formData);
    return response.data;
};

//点赞的接口
export const handleAgreeNum = async (agreeNum, blog_id) => {
    const response = await API.put(`/agreeNum`+ '?agreeNum=' + agreeNum+'&blog_id='+blog_id);
    return response.data;
};

// 提交博客
export const postBlog = async (owner_id, title, content, imagePath) => {
    let blog = {
        blogId: "0",
        ownerId: owner_id,
        title: title,
        content: content,
        imageUrl: imagePath,
        releaseTime: new Date(),
        agreeNum: 0,
        commentNum: 0,
    };

    console.log("API postBlog : ", blog);

    const formData = new FormData(); 
    formData.append('blogJson', JSON.stringify(blog));

    const response = await API.post("/blog/post", formData);
    return response.data;
};