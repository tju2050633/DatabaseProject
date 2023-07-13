import {
    createRouter,
    createWebHistory,
} from 'vue-router'

const routes = [
    {
        path: '/',
        component: () => import('../components/main.vue'),
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
        // redirect: '/'


    },

]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router