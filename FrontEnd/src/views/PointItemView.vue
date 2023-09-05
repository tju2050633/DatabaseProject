<template>
    <div class="container" style="margin-top: 60px;">
        <NavBar />
        <el-row>
            <SideBar />
            <el-card class="item-display">
                <!-- 轮播图 -->
                <el-carousel :interval="4000" type="card" height="300px" indicator-position="outside">
                    <el-carousel-item v-for="(it, index) in item.carouselItems" :key="index">
                        <img :src="it.imageUrl" class="carousel-image" alt="carousel-image" />
                    </el-carousel-item>
                </el-carousel>
                <hr />

                <!-- 商品信息 -->
                <div class="product-info">
                    <h2>{{ item.name }}</h2>
                    <hr />
                    <p>兑换所需积分: {{ item.price }}</p>
                    <p>我的积分: {{ myPoints }}</p>
                    <p>已兑换数量: {{ item.sales }}</p>
                    <p>剩余数量: {{ item.storage }}</p>
                </div>

                <!-- 兑换按钮 -->
                <el-button @click="confirmExchange(item)" type="primary">兑换</el-button>
            </el-card>
        </el-row>
    </div>
</template>
  
<script>

import { fetchMyPoints, fetchItemCounts, performExchange } from '../api/mallApi.js';

export default {
    el: "#app", // 组件挂载的元素
    // props: ['id'], // 父组件传递的属性
    data() { // 组件的数据
        return {
            myPoints: 0,
            item: {
                name: '',
                price: 0,
                sales: 0,
                storage: 0,
                carouselItems: [
                    { id: '1', imageUrl: '' },
                    { id: '2', imageUrl: '' },
                    { id: '3', imageUrl: '' },
                ],
            },
        };
    },
    methods: { // 组件的方法
        async confirmExchange(item) { // 确认兑换
            if (confirm(`确认要兑换 ${item.name} 吗？`)) { // 弹出确认框
                const exchangeResult = await performExchange(this.id); // 调用兑换 API
                if (exchangeResult.success) { // 兑换成功

                    // 本地数据更新
                    item.sales += 1; // 增加商品兑换次数
                    item.storage -= 1; // 减少商品剩余数量
                    this.myPoints -= item.price; // 减少用户积分
                    
                    alert(exchangeResult.message); // 弹出兑换成功提示框
                } else { // 兑换失败
                    alert(exchangeResult.message); // 弹出兑换失败提示框
                }
            }
        },
    },
    async created() { // 组件创建时执行的方法
        this.id = "001";
        try {
            // 获取用户积分
            this.myPoints = await fetchMyPoints(); 

            // 使用 API 请求函数获取商品详情数据
            const itemInfo = await fetchItemCounts(this.id); 

            this.item.name = itemInfo.itemName; // 设置商品名称
            this.item.price = itemInfo.price; // 设置商品价格
            this.item.sales = itemInfo.sales; // 设置商品兑换次数
            this.item.storage = itemInfo.storage; // 设置商品剩余数量
            this.item.carouselItems[0].imageUrl = itemInfo.image; // 设置商品轮播图
            this.item.carouselItems[1].imageUrl = itemInfo.image; // 设置商品轮播图
            this.item.carouselItems[2].imageUrl = itemInfo.image; // 设置商品轮播图

        } catch (error) { // 获取商品详情数据失败
            console.error('Error fetching item detail:', error); // 输出错误信息
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
