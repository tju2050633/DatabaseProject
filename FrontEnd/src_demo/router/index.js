import { createRouter, createWebHashHistory } from 'vue-router'

import HomeView from '../views/HomeView.vue'
import NotFoundView from '../views/NotFoundView.vue'
import LinkView from '../views/LinkView.vue'
import ActionView from '../views/ActionView.vue'
import AnotherActionView from '../views/AnotherActionView.vue'
import SthElseView from '../views/SthElseView.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/link',
    name: 'link',
    component: LinkView
  },
  {
    path: '/action',
    name: 'action',
    component: ActionView
  },
  {
    path: '/anotherAction',
    name: 'anotherAction',
    component: AnotherActionView
  },
  {
    path: '/sthElse',
    name: 'sthElse',
    component: SthElseView
  },
  {
    path: '/404',
    name: '404',
    component: NotFoundView
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
