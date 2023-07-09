import { createRouter, createWebHistory } from 'vue-router'

import HomeView from '../views/HomeView.vue'
import NotFoundView from '../views/NotFoundView.vue'
import LoginView from '../views/LoginView.vue'
import RegisterView from '../views/RegisterView.vue'
import AboutView from '../views/AboutView.vue'
import FeedbackView from '../views/FeedbackView.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
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
