<template>
    <div>
        <!-- 导航栏 -->
        <NavBar />

        <body>
            <!-- 反馈模块 -->
            <div class="d-flex feedback-container">
                <FeedbackCard />
            </div>
        </body>
        
    </div>
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

.feedback-container {
  margin-top: 100px;
  margin-bottom: 50px;
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