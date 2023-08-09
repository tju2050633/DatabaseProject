import request from '@/utils/request'

//获取总用户数据
//params中两个参数：开始时间 结束时间
//response返回一个数组，存开始时间到结束时间每天到total user number
export function getOriginNum(params) {
    return request({
        url: '/DV/bd/getOriginNum',
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
export function getHotNum(params) {
    return request({
        url: '/DV/bd/getHotNum',
        method: 'get',
        params,
        // headers: {
        //     'Authorization': JSON.parse(localStorage.Authorization)
        // }
    })
}


