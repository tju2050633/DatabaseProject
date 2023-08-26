import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5194/api/',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

// getAllUserInfo 提供userId 需要的返回值：
//       用户信息
//       UserInfo: {
//         name: "楚杰",
//         description: "我真的不卷。。。",
//         email: "123@tongji.edu.cn",
//         registerTime: "2020年1月",
//         tel: "123456",
//         points: "114",
//         id: "1919810",
//       },
export const getAllUserInfo = async (userId) => {
    try {
        const response = await API.get(`/getUserInfo/`, { params: { userId } });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};

//postAllUserInfo 提供修改过后的信息 需要返回修改成功的bool值 提供列表如下：

//         id: "1919810",
//         description: "我真的不卷。。。",
//         email: "123@tongji.edu.cn",
//         tel: "123456",
export const postAllUserInfo = async (UserInfo) => {
    try {
        const response = await API.post(`/postUserInfo/`, { 
            id:UserInfo.id,
            description:UserInfo.description,
            email:UserInfo.email,
            tel:UserInfo.tel,        
         });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};

// getGardenComment 提供userid，需要返回一个数组，具体形式如下：
      //互动：花园评论
//       GardenComment: [
//         {
//           author: "王浩",
//           title: "浩哥的后宫",
//           avatar: require("../assets/author-avatar.jpg"),
//           imageurl: require("../assets/Garden.jpg"),
//           comment: "晚上就把浩哥撅了",
//         },
//       ],
export const getGardenComment = async (userId) => {
    try {
        const response = await API.get(`/GardenComment/`, { params: { userId } });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};

// getGardenLike 提供userid 返回一个数组，具体形式如下：
//       //互动：花园点赞
//       GardenLike: [
//         {
//           author: "王浩",
//           avatar: require("../assets/author-avatar.jpg"),
//           title: "浩哥的后宫",
//           imageurl: require("../assets/Garden.jpg"),
//         },
//       ],
export const getGardenLike = async (userId) => {
    try {
        const response = await API.get(`/GardenLike/`, { params: { userId } });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};

//blogcomment和bloglike都是对别人的博客互动 

// getBlogComment 提供userid 返回一个数组，具体形式如下：
//  博客：博客评论
// BlogComment: [
//     {
//       author: "王浩",
//       avatar: require("../assets/author-avatar.jpg"),
//       blogName: "只因你太美",
//       fullContent: `8564876(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
//               这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
//               一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
//               所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
//               成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
//               baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
//       comment: "晚上就把浩哥撅了",
//       totalLikes: 114,
//       totalComment: 514,
//     },
//   ],
//ps: totalLikes和totalComment请后端同学统计 如果前段统计会很大程度上消耗资源
export const getBlogComment = async (userId) => {
    try {
        const response = await API.get(`/BlogComment/`, { params: { userId } });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};

// getBlogComment 提供userid 返回一个数组，具体形式如下：
    //   //博客：博客点赞
    //   BlogLike: [
    //     {
    //       author: "王浩",
    //       avatar: require("../assets/author-avatar.jpg"),
    //       blogName: "只因你太美",
    //       partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,//不能写死 还得computed
    //       fullContent: `12312)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
    //               这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
    //               一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
    //               所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
    //               成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
    //               baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
    //       showFullContent: false,
    //       isOpen: false,
    //       totalLikes: 114,
    //       totalComment: 514,
    //     },
    //   ],
//ps: totalLikes和totalComment请后端同学统计 如果前段统计会很大程度上消耗资源
export const getBlogLike = async (userId) => {
    try {
        const response = await API.get(`/BlogLike/`, { params: { userId } });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};


// getGardenInfo 提供userid 返回一个数组，具体形式如下：
    //   花园：花园信息
    //   Garden: [
    //     {
    //       author: "楚杰",
    //       title: "安楼的花园",
    //       cover:
    //         "https://img2.baidu.com/it/u=3194475248,8547823&fm=253&fmt=auto&app=138&f=JPEG?w=800&h=500",
    //     },
    //   ],
export const getGardenInfo = async (userId) => {
    try {
        const response = await API.get(`/GardenInfo/`, { params: { userId } });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};


// getRecords 提供userid 返回一个数组，具体形式如下：
// 工作记录：工作记录
// Records: [
//     {
//       date: "2023.1.1",
//       location: "19号楼",
//       fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
//               这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
//               一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
//               所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
//               成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
//               baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
//     },
//    ]
export const getRecords = async (userId) => {
    try {
        const response = await API.get(`/Records/`, { params: { userId } });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};