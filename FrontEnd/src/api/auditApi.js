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
export const getReports = async () => {
    const reports = await API.get('/reoprt/get');
    return reports.data;
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
    formData.append("blogCommentJson", JSON.stringify(comment));

    const response = await API.post("/blog/comments/post", formData);
    return response.data;
};
