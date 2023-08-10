<template>
    <div class="container" style="margin-top: 60px;">
        <NavBar />
        <el-row>
            <SideBar />
            <el-card class="item-display">
                <el-carousel :interval="4000" type="card" height="300px" indicator-position="outside">
                    <el-carousel-item v-for="(item, index) in carouselItems" :key="index">
                        <img :src="item.imageUrl" class="carousel-image" alt="carousel-image" />
                    </el-carousel-item>
                </el-carousel>
                <hr />
                <div class="product-info">
                    <h2>{{ item.name }}</h2>
                    <hr />
                    <p>兑换所需积分: {{ item.price }}</p>
                    <p>我的积分: {{ myPoints }}</p>
                    <p>已兑换数量: {{ item.exchangeCount }}</p>
                    <p>剩余数量: {{ item.remainCount }}</p>
                </div>
                <el-button @click="exchange" type="primary">兑换</el-button>
            </el-card>
        </el-row>
    </div>
</template>
  
<script>

import { fetchMyPoints, fetchItemCounts, performExchange } from '../api/mallApi.js';

export default {
    el: "#app",
    props: ['id'],
    data() {
        return {
            item:
            {
                name: '',
                price: null,
                exchangeCount: null,
                remainCount: null,
            },
            carouselItems: [
                {
                    imageUrl: require('../assets/item.png'),
                },
                {
                    imageUrl: require('../assets/item.png'),
                },
                {
                    imageUrl: require('../assets/item.png'),
                },
            ],
            myPoints: 0,
        };
    },
    methods: {
        async confirmExchange(item) {
            if (confirm(`确认要兑换 ${item.name} 吗？`)) {
                const exchangeResult = await performExchange(item.id);
                if (exchangeResult.success) {
                    item.exchangeCount += 1;
                    item.remainCount -= 1;
                    this.myPoints -= item.price;
                    alert('兑换成功！');
                } else {
                    alert('兑换失败，请重试。');
                }
            }
        },
    },
    async created() {
        try {
            this.myPoints = await fetchMyPoints();
            const { name, price, exchangeCount, remainCount } = await fetchItemCounts(this.id); // 使用 API 请求函数获取商品详情数据
            this.item.name = name;
            this.item.price = price;
            this.item.exchangeCount = exchangeCount;
            this.item.remainCount = remainCount;
        } catch (error) {
            console.error('Error fetching item detail:', error);
        }
    },
};
</script>

<style>
.item-display {
    margin-top: 50px;
    margin-left: 20px;
    width: 80%;
    justify-content: center;
    align-items: center;

}

.carousel-image {
    width: 100%;
    height: 300px;
    object-fit: cover;
}

.product-info {
    margin-top: 20px;
}
</style>
