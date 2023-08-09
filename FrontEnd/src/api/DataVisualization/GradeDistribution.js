import request from '@/utils/request'

//获取校区分配总数
//params中无参数
//response返回一个数组，形式如下：
// table:[
//     { value: 130, name: '大一' },
//     { value: 218, name: '大二' },
//     { value: 126, name: '大三' },
//     { value: 94, name: '大四' },
//     { value: 82, name: '其他（硕士、博士）' },
//   ]
export function getGradeTable(params) {
    return request({
        url: '/DV/gradeD/getGradeTable',
        method: 'get',
        params,
        // headers: {
        //     'Authorization': JSON.parse(localStorage.Authorization)
        // }
    })
}

