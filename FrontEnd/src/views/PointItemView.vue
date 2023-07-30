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
                    <h2>{{ product.name }}</h2>
                    <hr />
                    <p>兑换所需积分: {{ product.price }}</p>
                    <p>我的积分: {{ myPoints }}</p>
                    <p>已兑换数量: {{ exchangeCount }}</p>
                    <p>剩余数量: {{ remainCount }}</p>
                </div>
                <el-button @click="exchange" type="primary">兑换</el-button>
            </el-card>
        </el-row>
    </div>
</template>
  
<script>
export default {
    el: "#app",
    data() {
        return {
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
            product: {
                name: "商品名称",
                price: 100,
            },
            myPoints: 5000,
            exchangeCount: 50,
            remainCount: 50,
        };
    },
    methods: {
        exchange() {
            if (this.myPoints >= this.product.price) {
                this.myPoints -= this.product.price;
                this.exchangeCount++;
                this.remainCount--;
                this.showExchangeResult("兑换成功");
            } else {
                this.showExchangeResult("兑换失败");
            }
        },
        showExchangeResult(message) {
            this.$message({
                message: message,
                type: message === "兑换成功" ? "success" : "error",
            });
        },
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
