import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5194/api/',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

// getGardenInfo 提供userId 需要的返回值：
//       用户信息
//    GardenInfo:{
//        username:"楚杰",
//        gardenname:"杰哥的花园",
//        hot:"50",
//        describe:`在这个梦幻般的A花园里，自然与人工的完美融合令人惊叹。踏入花园的瞬间，弥漫着清新的花香，让人心情为之一振。
//        location:"安楼后的小树林",
//      },
export const getGardenInfo = async (userId) => {
    try {
        const response = await API.get(`/GardenInfo/`, { params: { userId } });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};

//postComment 提交评论 需要返回修改成功的bool值 

export const postComment = async (comment) => {
    try {
        const response = await API.post(`/postComment/`, { 
            gardencomment:comment,        
         });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};

// getimageList 提供userid，需要返回一个数组，具体形式如下：
      //图片列表
//       imageList: [
//         {
//           imageUrl: require("../assets/Garden.jpg"),
//         },
//       ],
export const getImageList = async (userId) => {
    try {
        const response = await API.get(`/getimageList/`, { params: { userId } });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};