import request from '@/utils/request'

//获取总用户数据
//params中两个参数：开始时间 结束时间
//response返回一个数组，存开始时间到结束时间每天到total user number
export function getTotalUser(params) {
    return request({
        url: '/DV/gardenD/getTotalUser',
        method: 'get',
        params,
        // headers: {
        //     'Authorization': JSON.parse(localStorage.Authorization)
        // }
    })
}


//获取活跃用户总数
//params中两个参数：开始时间 结束时间
//response返回一个数组，存开始时间到结束时间每天的active user number
export function getActiveUser(params) {
    return request({
        url: '/DV/gardenD/getActiveUser',
        method: 'get',
        params,
        // headers: {
        //     'Authorization': JSON.parse(localStorage.Authorization)
        // }
    })
}

//获取活跃用户总数
//无params
// 返回：
// campus_distribution:[
//     { value: 430, name: '四平路校区' },
//     { value: 518, name: '嘉定校区' },
//     { value: 226, name: '沪西校区' },
//   ],
export function getCampusNum(params) {
    return request({
        url: '/DV/gardenD/getCampusNum',
        method: 'get',
        params,
        // headers: {
        //     'Authorization': JSON.parse(localStorage.Authorization)
        // }
    })
}




