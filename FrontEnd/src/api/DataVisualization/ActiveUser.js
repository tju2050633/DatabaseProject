import request from '@/utils/request'

//获取总用户数据
//params中无参数 返回1-12月份的总用户人数 具体格式如下：
//      total_user_num:[22, 45, 67, 237, 258, 376, 435, 516, 532, 620, 666, 843]
export function getTotalUser(params) {
    return request({
        url: '/DV/ac/getTotalUser',
        method: 'get',
        params,
    })
}


//获取活跃用户总数
//params中无参数 返回1-12月份的活跃用户人数 具体格式如下：
 //     active_user_num: [10, 23, 33, 45, 163, 222, 203, 234, 220, 215, 120, 362],
export function getActiveUser(params) {
    return request({
        url: '/DV/ac/getActiveUser',
        method: 'get',
        params,
    })
}


