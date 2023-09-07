import request from '@/utils/request'

export function postFeedback(data1,data2,data3,data4,data5) {
    let param=new
    URLSearchParams({issueId:data1,title:data2,content:data3,picture:data4,address:data5})
    return request({
        url: '/order/feedback',
        method: 'post',
        data: param
    })
}