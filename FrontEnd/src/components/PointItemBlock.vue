<template>
    <div class="point-item-block">
        <el-card :body-style="{ padding: '0px' }">
            <img :src="item.image" class="item-image" alt="Product Image" @load="resizeCard" />
            <div class="item-info">
                <div class="item-name">{{ item.name }}</div>
                <div class="item-price">{{ item.price }} 积分</div>
                <div class="item-exchange-count">已兑换：{{ item.exchangeCount }}&nbsp;&nbsp;剩余：{{ item.remainCount }}</div>
            </div>
        </el-card>
    </div>
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
  
<style>
.point-item-block {
    margin: 10px;
    width: 90%;
    text-align: center;
    cursor: pointer;
    transition: transform 0.3s;
}

.item-image {
    margin: 15px;
    width: 80%;
    height: auto;
    transition: transform 0.3s;
}

.point-item-block:hover {
    transform: scale(1.1);
}

.point-item-block:hover .item-image {
    transform: scale(1.2);
}

.item-info {
    padding: 10px;
    text-align: left;
}

.item-name {
    font-size: 16px;
    font-weight: bold;
    margin-bottom: 5px;
}

.item-price {
    font-size: 14px;
    color: #888;
    margin-bottom: 5px;
}

.item-exchange-count {
    font-size: 12px;
    color: #666;
}
</style>
  
  