import request from '@/utils/request'

//获取花园活动
//无params
// 返回：
// GardenAct: [
//     {
//         author: '楚杰',
//         title: '杰哥的安楼自习室',
//         avatar: require('../assets/author-avatar.jpg'),
//         imageurl: require('../assets/Garden.jpg'),
//         time: '2020年1月1日',
//         address: '安楼后面的小树林',
//         detail: '给你看点好康的'
//     },
export function getGardenAct(params) {
    return request({
        url: '/DV/bd/getGardenAct',
        method: 'get',
        params,
    })
}

// post报名信息
export function postRegisInfo(data1,data2) {
    let param=new
    URLSearchParams({Id:data1,gardenActId:data2})
    return request({
        url: '/order/feedback',
        method: 'post',
        data: param
    })
}