import request from '@/utils/request'

//获取总用户数据
//params中无参数 返回1-12月份的总博客数 具体格式如下：
//      origin_num:[ 242, 545, 657, 737, 858, 976, 1435, 2116, 2932, 3620, 4666, 5843 ],
export function getOriginNum(params) {
    return request({
        url: '/Statistics/blogcount',
        method: 'get',
        params,
    })
}


//获取活跃用户总数
//params中无参数 返回1-12月份的热门博客数 具体格式如下：
//      hot_num:[100, 235, 357, 437, 558, 676, 935, 1116, 1232, 1220, 1266, 1343]
export function getHotNum(params) {
    return request({
        url: '/Statistics/hotblogcount',
        method: 'get',
        params,
    })
}


