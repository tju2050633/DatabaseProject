<template>
    <el-card class="item-card">
        <img :src="item.image" class="item-image" alt="Product Image" @load="resizeCard" />
        <div class="item-info">
            <div class="item-name">{{ item.itemName }}</div>
            <div class="item-price">{{ item.price }} 积分</div>
            <div class="item-exchange-count">
                已兑换：{{ item.sales }}&nbsp;&nbsp;
                剩余：{{ item.storage }}
            </div>
        </div>
    </el-card>
</template>
  
<script>
export default {
    props: {
        item: {
            type: Object,
            required: true,
        },
    },
    methods: {
        resizeCard() {
            const img = this.$refs.itemImage;
            if (img) {
                const height = img.offsetHeight;
                this.$el.style.height = `${height}px`;
            }
        },
    },
};
</script>
  
<style scoped>
.item-card {
    background-color: rgb(246, 243, 239);
    border-radius: 3vh;
    margin: 2vh;
    text-align: center;
    cursor: pointer;
}

.item-card:hover {
    transform: scale(1.05);
    transition: 0.5s;
}

.item-image {
    width: 90%;
    height: 200px;
    border-radius: 1vh;
}

.item-card:hover .item-image {
    transform: scale(1.1);
    transition: 0.5s;
}

.item-info {
    padding: 2vh;
    text-align: left;
}

.item-name {
    font-size: 2.5vh;
    font-weight: bold;
    color: rgb(12, 60, 38);
}

.item-price {
    font-size: 2vh;
    font-weight: bold;
    color: rgb(99, 110, 115);
}

.item-exchange-count {
    font-size: 2vh;
    color: rgb(99, 110, 115);
}
</style>
  
  