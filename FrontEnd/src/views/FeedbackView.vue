<template>
    <!-- 导航栏 -->
    <NavBar />

    <body>
        <br>
        <br>
        <br>
        <br>
        <br>

        <!-- 反馈模块 -->
        <div class="d-flex">
            <FeedbackCard />
        </div>

        <br>
        <br>
        <br>
        <br>
        <br>

    </body>
</template>
  
<script>
export default {
    name: 'FeedbackView',
}
</script>
  
<style scoped>
body {
    background-color: rgb(244, 237, 228);
    background-image: url("../assets/img-feedback.png");
    background-size: 35vw;
    background-repeat: no-repeat;
    position: relative;
    background-position: right;
    background-attachment: fixed;
}

.d-flex {
    animation: slide-in-from-left 2.5s;
    margin-left: 10vw;
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