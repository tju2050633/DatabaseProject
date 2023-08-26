import request from '@/utils/request'

//获取总花园数
//params中无参数 返回1-12月份的总花园数 具体格式如下：
//      total_garden_num:[242, 545, 657, 737, 858, 976, 1435, 2116, 2932, 3620, 4666, 5843],
export function getTotalGarden(params) {
    return request({
        url: '/DV/gardenD/getTotalGarden',
        method: 'get',
        params,
    })
}


//获取活跃花园数
//params中无参数 返回1-12月份的活跃花园数 具体格式如下：
//      active_garden_num:[100, 235, 357, 437, 558, 676, 935, 1116, 1232, 1220, 1266, 1343],
export function getActiveGarden(params) {
    return request({
        url: '/DV/gardenD/getActiveGarden',
        method: 'get',
        params,
    })
}

//获取花园分布总数
//无params
// 返回：
// campus_distribution:[
//     { value: 430, name: '四平路校区' },
//     { value: 518, name: '嘉定校区' },
//     { value: 226, name: '沪西校区' },
//   ],
export function getCampusGardenNum(params) {
    return request({
        url: '/DV/gardenD/getCampusGardenNum',
        method: 'get',
        params,
    })
}




