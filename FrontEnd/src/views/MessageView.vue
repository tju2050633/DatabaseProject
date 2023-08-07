<template>
    <!-- 导航栏 -->
    <NavBar />

    <body>
        <br>
        <br>
        <br>

        <!-- 消息模块 -->
        <div class="d-flex justify-content-center">
            <MessageCard />
        </div>

        <br>
        <br>
    </body>
</template>
  
<script>
import MessageCard from '@/components/MessageCard.vue';

export default {
    name: 'MessageView',
    components: {
        MessageCard
    }
}
</script>
  
<style scoped>
body {
    background-color: rgb(244, 237, 228);
    background-image: url("../assets/img-message.svg");
    background-size: 25vw;
    background-repeat: no-repeat;
    position: relative;
    background-position: left;
    background-attachment: fixed;
}

.d-flex {
    margin-left: 20%;
    animation: slide-in-from-left 2.5s;
}

@keyframes slide-in-from-left {
    from {
        transform: translateX(-50%);
    }

    to {
        transform: translateX(0);
    }
}
</style>