import { createRouter, createWebHistory } from 'vue-router'
import { useStore } from 'vuex'

// 定义路由，统一使用懒加载

const routes = [
  {
    // 主页
    path: '/',
    name: 'home',
    component: () => import('../views/HomePageView.vue'), //通过相对路径导入页面组件，和import是两种路由的方法
    children: [
      {
        path: 'ItemBlock',
        component: () => import('../components/ItemBlock.vue'),
      }
    ],
  },

  // 登录注册
  {
    path: '/login/',
    name: 'login',
    component: () => import('../views/LoginView.vue'),
  },
  {
    path: '/register/',
    name: 'register',
    component: () => import('../views/RegisterView.vue'),
  },

  // 消息、关于、反馈
  {
    path: '/message/',
    name: 'message',
    component: () => import('../views/MessageView.vue'),
  },
  {
    path: '/about/',
    name: 'about',
    component: () => import('../views/AboutView.vue'),
  },
  {
    path: '/feedback/',
    name: 'feedback',
    component: () => import('../views/FeedbackView.vue'),
  },

  // 花园展厅
  {
    path: '/display/',
    name: 'display',
    component: () => import('../views/GardenDisplayView.vue'),
  },
  {
    path: '/garden/:garden_id',
    name: 'garden',
    component: () => import('../views/GardenView.vue'),
    props: true // 开启props传参
  },

  // 个人主页
  {
    path: '/personalInfo/',
    name: 'personalInfo',
    component: () => import('../views/PersonalInfoView.vue'),
  },
  // 数据展示
  {
    path: '/DataVisualization/',
    name: 'DataVisualization',
    component: () => import('../views/DataVisualization.vue'),
  },

  // 博客
  {
    path: '/BlogView/',
    name: 'BlogView',
    component: () => import('../views/BlogView.vue'),
  },
  // 地图
  {
    path: '/TJMap/:lng/:lat',
    name: 'TJMap',
    component: () => import('../views/TJMap.vue'),
    props: true // 开启props传参
  },

  // 积分商城
  {
    path: '/PointMall/',
    name: 'PointMall',
    component: () => import('../views/PointMallView.vue')
  },
  {
    path: '/PointItem/:itemId',
    name: 'PointItem',
    component: () => import('../views/PointItemView.vue'),
    props: true // 开启props传参
  },

  //花园活动
  {
    path: '/GardenActivities/',
    name: 'GardenActivities',
    component: () => import('../views/GardenActivitiesView.vue')
  },

  // 志愿者招募
  {
    path: '/VolunteerRecruitment/',
    name: 'VolunteerRecruitment',
    component: () => import('../views/VolunteerRecruitment.vue')
  },

  // 搜索结果
  {
    path: '/SearchResults/:results',
    name: 'SearchResults',
    component: () => import('../views/SearchResultsView.vue'),
    props: true // 启用props来接收参数
  },

  // 当前热榜
  {
    path: '/CurrentHotList/',
    name: 'CurrentHotList',
    component: () => import('../views/CurrentHotList.vue')
  },

  // 404
  {
    path: '/404/',
    name: '404',
    component: () => import('../views/NotFoundView.vue'),
  },
  {
    path: '/:catchAll(.*)',
    redirect: '/404/'
  },

  //发布花园页
  {
    path: '/GardenPost',
    name: 'GardenPost',
    component: () => import('../views/GardenPost.vue'),
  },

  //发布博客页
    {
    path: '/BlogPost',
    name: 'BlogPost',
    component: () => import('../views/BlogPost.vue'),
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

// 使用 router.beforeEach 注册一个全局前置守卫，判断用户是否登陆
router.beforeEach((to, from, next) => {
  console.log('to:', to)
  // 判断用户是否已经登录
  const store = useStore();
  //const isLogin = store.state.user.is_login;
  const isLogin = true;
  console.log(store.state.user.is_login);

  if (to.path === '/login'
    || to.path === '/register') {
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
