import { createRouter, createWebHistory } from 'vue-router'

import NotFoundView from '../views/NotFoundView.vue'
import LoginView from '../views/LoginView.vue'
import RegisterView from '../views/RegisterView.vue'
import AboutView from '../views/AboutView.vue'
import FeedbackView from '../views/FeedbackView.vue'

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
        path:'ItemBlock',
        component:()=> import('../components/itemBlock.vue'),
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
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
