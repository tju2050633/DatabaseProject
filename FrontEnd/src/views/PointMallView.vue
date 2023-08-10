<template>
    <div class="container" style="margin-top: 60px;">
        <NavBar />
        <el-row>
            <SideBar />
            <el-col :span="16">
                <div class="point-mall-view">
                    <el-card style="margin-left:10px;margin-bottom: 20px;">
                        <img src="../assets/mall-logo.png">
                    </el-card>
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
</template>
  
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
  
<style>
.point-mall-view {
    padding: 20px;
}
</style>
  





  