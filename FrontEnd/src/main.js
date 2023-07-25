import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
//引入bootstrp
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/js/bootstrap'

//引入elemenets plus
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import 'dayjs/locale/zh-cn'
import * as ElementPlusIconsVue from '@element-plus/icons-vue'

//导入百度地图API
import vue3BaiduMapGl from 'vue3-baidu-map-gl'//这个是完整引用，若忽略打包后的文件大小，可不管，这里展示完整引用
import baiduMap from 'vue3-baidu-map-gl'

//创建app使用所需的组件，并挂载到#app
const app = createApp(App)
app.use(store)
app.use(router)

app.use(vue3BaiduMapGl)
app.use(baiduMap, {
  ak: 'HR8QVms0aC9N8giqxCuXfNXGhzBuT6X2',
  plugins: ['TrackAnimation']
})

app.use(ElementPlus)
for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
    app.component(key, component)
}
app.mount('#app')
