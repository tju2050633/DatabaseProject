import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5194/api/',
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
export const getGardenList = async (userId) => {
    try {
        const response = await API.get(`/GardenList/`, { params: { userId } });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};

// getHotGarden 提供userid 返回一个数组，具体形式如下：
//       //热门花园
//       HotGarden: [
//         {
//           imageUrl: require("../assets/Garden-e.jpg"),
//           username: "Student1",
//           gardenname: "Garden1",
//           hot: "90",
//         },
//       ],
export const getHotGarden = async (userId) => {
    try {
        const response = await API.get(`/HotGarden/`, { params: { userId } });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};


// getNewGarden 提供userid 返回一个数组，具体形式如下：
//       //最新花园
//       NewGarden: [
//         {
//           imageUrl: require("../assets/Garden.jpg"),
//           username: "Student6",
//           gardenname: "Garden6",
//           hot: "10",
//         },
//       ],
export const getNewGarden = async (userId) => {
    try {
        const response = await API.get(`/NewGarden/`, { params: { userId } });
        return response.data;
    } catch (error) {
        console.error('Error occured! :', error);
    }
};