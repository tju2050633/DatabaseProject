<template>
    <body>
        <div class="container">
            <NavBar /> <!-- 导航栏 -->

            <el-row>
                <SideBar />
                <el-col :span="20">
                    <div class="point-mall-view">

                        <!-- 顶部标题卡片 -->
                        <div class="card heading-card">
                            <div class="card-body">
                                &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;
                                <!-- 图标 -->
                                <svg xmlns="http://www.w3.org/2000/svg" width="35" fill="currentColor" class="bi bi-cart"
                                    viewBox="0 0 16 16">
                                    <path
                                        d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" />
                                </svg>

                                <!-- 图片 -->
                                <img src="../assets/mall-logo.png" style="display: inline-block; width: 20vw;">&emsp;
                            </div>
                        </div>

                        <el-row>
                            <el-col v-for="item in items" :key="item.id" :xs="24" :sm="12" :md="8" :lg="6"
                                @click="this.$router.push({ name: 'PointItem', params: { id: item.id } })">
                                <PointItemBlock :item="item" />
                            </el-col>
                        </el-row>
                    </div>
                </el-col>
            </el-row>
        </div>
    </body>
</template>

<style scoped>
body {
    background-color: rgb(244, 237, 228);
    background-image: url("../assets/img-mall-bg.png");
    background-size: auto;
    background-repeat: no-repeat;
    position: relative;
    background-position: 92vw 15vh;
    background-attachment: fixed;
}

.container {
    margin-top: 60px;
}

.point-mall-view {
    padding: 3vh;
}

.heading-card {
    border-width: 0vh;
    border-radius: 3vh;

    margin-bottom: 3vh;

    color: rgb(4, 145, 59);
    background-color: rgb(244, 237, 228);
    box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);

    text-align: center;
    user-select: none;
    position: relative;

    animation: slide-in-from-top 1s;
}

.heading-card:hover {
    transform: scale(1.02);
    transition: 1000ms;
}

@keyframes slide-in-from-top {
    from {
        transform: translateY(-100%);
    }

    to {
        transform: translateY(0);
    }
}
</style>
  
<script>
import PointItemBlock from '../components/PointItemBlock.vue';
import { fetchItemCounts } from '../api/mallApi.js';

export default {
    components: {
        PointItemBlock,
    },
    data() {
        return {
            items: [
                {
                    id: 1,
                    name: '商品1',
                    price: 100,
                    exchangeCount: null,
                    remainCount: null,
                    image: require('../assets/item.png'),
                },
                {
                    id: 2,
                    name: '商品2',
                    price: 200,
                    exchangeCount: null,
                    remainCount: null,
                    image: require('../assets/item.png'),
                },
                {
                    id: 3,
                    name: '商品3',
                    price: 300,
                    exchangeCount: null,
                    remainCount: null,
                    image: require('../assets/item.png'),
                },
                {
                    id: 4,
                    name: '商品4',
                    price: 400,
                    exchangeCount: null,
                    remainCount: null,
                    image: require('../assets/item.png'),
                },
                {
                    id: 5,
                    name: '商品5',
                    price: 500,
                    exchangeCount: null,
                    remainCount: null,
                    image: require('../assets/item.png'),
                },
                {
                    id: 6,
                    name: '商品6',
                    price: 600,
                    exchangeCount: null,
                    remainCount: null,
                    image: require('../assets/item.png'),
                },
                {
                    id: 7,
                    name: '商品7',
                    price: 700,
                    exchangeCount: null,
                    remainCount: null,
                    image: require('../assets/item.png'),
                },
                {
                    id: 8,
                    name: '商品8',
                    price: 800,
                    exchangeCount: null,
                    remainCount: null,
                    image: require('../assets/item.png'),
                },
                {
                    id: 9,
                    name: '商品9',
                    price: 900,
                    exchangeCount: null,
                    remainCount: null,
                    image: require('../assets/item.png'),
                },
                {
                    id: 10,
                    name: '商品10',
                    price: 1000,
                    exchangeCount: null,
                    remainCount: null,
                    image: require('../assets/item.png'),
                }, {
                    id: 11,
                    name: '商品11',
                    price: 1100,
                    exchangeCount: null,
                    remainCount: null,
                    image: require('../assets/item.png'),
                },
                {
                    id: 12,
                    name: '商品12',
                    price: 1200,
                    exchangeCount: null,
                    remainCount: null,
                    image: require('../assets/item.png'),
                },
            ],
        };
    },
    methods: {
        //这里不确定商品是否固定，不固定的话修改下面的代码
        async fetchItemCounts() {
            try {
                for (const item of this.items) {
                    const { exchangeCount, remainCount } = await fetchItemCounts(item.id);
                    item.exchangeCount = exchangeCount;
                    item.remainCount = remainCount;
                }
            } catch (error) {
                console.error('Error fetching item counts:', error);
            }
        },
    },
};
</script>
  





  