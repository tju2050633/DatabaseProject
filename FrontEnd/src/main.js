import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'

// 统一导入所有组件，main.js中的import语句全局生效
import BlogBlock from '@/components/BlogBlock.vue'
import CampusMap from '@/components/CampusMap.vue'
import ContentBase from '@/components/ContentBase.vue'
import FeedbackCard from '@/components/FeedbackCard.vue'
import GardenBlock from '@/components/GardenBlock.vue'
import ItemBlock from '@/components/ItemBlock.vue'
import LoginCard from '@/components/LoginCard.vue'
import NavBar from '@/components/NavBar.vue'
import PersonalBlogBlock from '@/components/PersonalBlogBlock.vue'
import PersonalGardenBlock from '@/components/PersonalGardenBlock.vue'
import PersonalRecordBlock from '@/components/PersonalRecordBlock.vue'
import RegisterCard from '@/components/RegisterCard.vue'
import SideBar from '@/components/SideBar.vue'
import ActiveUsers from '@/components/ActiveUsers'
import GardenDistribution from '@/components/GardenDistribution'
import GradeDistribution from '@/components/GradeDistribution'
import BlogDistribution from '@/components/BlogDistribution'
import VolunteerBlock from '@/components/VolunteerBlock.vue'
import SearchResults from '@/components/SearchResults.vue'
import GardenActivityBlock from '@/components/GardenActivityBlock.vue'
import PostBlog from '@/components/PostBlog.vue'

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


//导入echarts
import * as echarts from 'echarts';

//创建app使用所需的组件，并挂载到#app
const app = createApp(App)
app.use(store)
app.use(router)
app.use(vue3BaiduMapGl)
app.use(echarts)
app.use(baiduMap, {
  ak: 'HR8QVms0aC9N8giqxCuXfNXGhzBuT6X2',
  plugins: ['TrackAnimation']
})
app.use(ElementPlus)
for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
    app.component(key, component)
}

// 将所有组件统一挂载
app.component('BlogBlock', BlogBlock)
app.component('CampusMap', CampusMap)
app.component('ContentBase', ContentBase)
app.component('FeedbackCard', FeedbackCard)
app.component('GardenBlock', GardenBlock)
app.component('ItemBlock', ItemBlock)
app.component('LoginCard', LoginCard)
app.component('NavBar', NavBar)
app.component('PersonalBlogBlock', PersonalBlogBlock)
app.component('PersonalGardenBlock', PersonalGardenBlock)
app.component('PersonalRecordBlock', PersonalRecordBlock)
app.component('RegisterCard', RegisterCard)
app.component('SideBar', SideBar)
app.component('ActiveUsers', ActiveUsers)
app.component('GradeDistribution',GradeDistribution)
app.component('GardenDistribution',GardenDistribution)
app.component('BlogDistribution',BlogDistribution)
app.component('VolunteerBlock', VolunteerBlock)
app.component('SearchResults', SearchResults)
app.component('GardenActivityBlock',GardenActivityBlock)
app.component('PostBlog',PostBlog)
app.mount('#app')
