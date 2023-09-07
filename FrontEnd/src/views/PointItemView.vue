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
import { fetchMyPoints, fetchItemInfo, performExchange } from '../api/mallApi.js';
import { useStore } from 'vuex'

export default {
    el: "#app",
    props: ['itemId'], // 父组件传递的属性
    data() {
        return {
            userId: "",
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
    methods: {
        async confirmExchange(item) {
            if (confirm(`确认兑换商品 ${item.name}?`)) {
                const exchangeResult = await performExchange(this.itemId, this.userId);
                if (exchangeResult.success) {

                    // update local data
                    item.sales += 1;
                    item.storage -= 1;
                    this.myPoints -= item.price;
                    
                    alert(exchangeResult.message);
                } else {
                    alert(exchangeResult.message);
                }
            }
        },
    },
    async created() {
        
        try {
            // init data
            
            this.userId = useStore().state.user.id;
            console.log("useStore().state", useStore().state)
            console.log("this.userId", this.userId);

            this.userId = "1";

            this.myPoints = await fetchMyPoints(this.userId); 

            const itemInfo = await fetchItemInfo(this.itemId); 
            console.log("itemInfo", itemInfo)

            this.item.name = itemInfo.itemName;
            this.item.price = itemInfo.price;
            this.item.sales = itemInfo.sales;
            this.item.storage = itemInfo.storage;
            this.item.carouselItems[0].imageUrl = itemInfo.image;
            this.item.carouselItems[1].imageUrl = itemInfo.image;
            this.item.carouselItems[2].imageUrl = itemInfo.image;

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
