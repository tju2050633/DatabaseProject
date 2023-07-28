<template>
    <!-- 导航栏 -->
    <NavBar />

    <!-- 反馈模块 -->
    <div class="d-flex justify-content-center">
        <FeedbackCard />
    </div>
</template>
  
<script>
export default {
    name: 'FeedbackView',
}
</script>
  
<style scoped>
.d-flex {
    margin-top: 100px;
    margin-bottom: 40px;
}
</style>