import axios from 'axios';

axios.defaults.headers.common['Content-Type'] = 'application/json';

const API = axios.create({
    baseURL: 'http://localhost:5194/Blog/',
    timeout: 5000,
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
export const getBlogComments = async (blog_id) => {
    const response = await API.get(`/Comments`,{ params: { blog_id } });
    return response.data;
};

//提交评论(这里的后端有问题)
export const postBlogComment = async (owner_id, blog_id, content) => {
    const response = await API.post(`/Comments`+'?owner_id='+owner_id+'&blog_id='+blog_id+'&content='+content);
    return response.data;
};

//点赞的接口
export const handleAgreeNum = async (agreeNum, blog_id) => {
    const response = await API.put(`/agreeNum`+ '?agreeNum=' + agreeNum+'&blog_id='+blog_id);
    return response.data;
};

//提交博客
export const postBlog = async (owner_id, title,content,imgs) => {
    const response = await API.post(`/Comments`+'?owner_id='+owner_id+'&title='+title+'&content='+content+'&imagePath='+imgs);
    return response.data;
};