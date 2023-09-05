//导入axios
import axios from 'axios'

//使用axios下面的create([config])方法创建axios实例，其中config参数为axios最基本的配置信息。
//下面的API就是你定义的最基本的API封装,你可以像函数一样在其他组件中使用它
const API = axios.create({
	baseURL:'http://localhost:5194/', //请求后端数据的基本地址，自定义
    timeout: 3000,                   //请求超时设置，单位ms
    async:true,
    crossDomain:true,
})

//导出我们建立的axios实例模块，ES6 export用法
export default API
