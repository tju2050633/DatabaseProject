import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5194/Blog/',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

//获取更多的博客
//startNum决定从数据库的哪一条开始读取，num决定数量
export const getMoreBlogs = async (startNum, num) => {
    const response = await API.get(`/moreblogs`,{ params: { startNum, num } });
    return response.data;
};

//获取博客对应的评论
export const getBlogComments = async (blogId) => {
    const response = await API.get(`/comments`,{ params: { blogId } });
    return response.data;
};

//提交评论(这里的后端有问题)
export const postBlogComment = async (blogId, ownerId, content) => {
    const response = await API.post(`/comments`,{ params: { blogId, ownerId, content } });
    return response.data;
};

//点赞的接口
export const handleAgreeNum = async (agreeNum) => {
    const response = await API.put(`/agreeNum`,{ params: { agreeNum } });
    return response.data;
};