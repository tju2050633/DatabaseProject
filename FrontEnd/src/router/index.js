import { createRouter, createWebHistory } from 'vue-router'

import NotFoundView from '../views/NotFoundView.vue'
import LoginView from '../views/LoginView.vue'
import RegisterView from '../views/RegisterView.vue'
import MessageView from '../views/MessageView.vue'
import AboutView from '../views/AboutView.vue'
import FeedbackView from '../views/FeedbackView.vue'
import DisplayView from '../views/DisplayView.vue'
import PersonalView from '../views/PersonalView.vue'
import PersonalInfo from '../views/PersonalInfo.vue'
import BlogView from '../views/BlogView.vue'

import { useStore } from 'vuex'

const routes = [
  {
    //主页路由及其子页面的组件路由
    path: '/',
    name: 'home',
    component: () => import('../views/HomePageView.vue'), //通过相对路径导入页面组件，和import是两种路由的方法
    children: [
      {
        path: 'GardenManage',
        component: () => import('../components/gardenManager.vue'),
      },
      {
        path: 'ItemBlock',
        component: () => import('../components/itemBlock.vue'),
      }
    ],
  },
  {
    path: '/login/',
    name: 'login',
    component: LoginView
  },
  {
    path: '/register/',
    name: 'register',
    component: RegisterView
  },
  {
    path: '/message/',
    name: 'message',
    component: MessageView
  },
  {
    path: '/about/',
    name: 'about',
    component: AboutView
  },
  {
    path: '/feedback/',
    name: 'feedback',
    component: FeedbackView
  },
  {
    path: '/404/',
    name: '404',
    component: NotFoundView
  },
  {
    path: '/:catchAll(.*)',
    redirect: '/404/'
  },
  {
    path: '/display/',
    name: 'display',
    component: DisplayView
  },
  {
    path: '/personal/',
    name: 'personal',
    component: PersonalView
  },
  {
    path:'/personalInfo/',
    name:'personalInfo',
    component:PersonalInfo
  },
  {
    path:'/BlogView/',
    name:'BlogView',
    component:BlogView
  },
  {
    path: '/TJMap/:lng/:lat',
    name: 'TJMap',
    component: () => import('../views/TJMap.vue'),
    props: true // 开启props传参
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

// 使用 router.beforeEach 注册一个全局前置守卫，判断用户是否登陆
router.beforeEach((to, from, next) => {
  console.log('to:',to)
// 判断用户是否已经登录
  const store = useStore();
  //const isLogin = store.state.user.is_login;
  const isLogin = true;
  console.log(store.state.user.is_login);

  if (to.path === '/login'
  ||to.path=== '/register') {
    // 需要用户权限的页面,如果用户已经登录，重定向到首页
    if (isLogin) {
      next('/')
    } else {
      // 否则，继续跳转到登录相应的页
      next()
    }
  } else {
    // 如果用户已经登录，继续跳转到目标页面
    if (isLogin) {
      next()
    } else {
      alert("该页面需要用户权限,请登录");
      // 否则，重定向到登录页
      next('/login')
    }
  }
});

export default router
