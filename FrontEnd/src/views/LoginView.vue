<template>
    <body>
        <div class="container">
            <div class="d-flex align-items-center" style="height: 100vh;">
                <!-- 组件内容 -->
                <LoginCard />
            </div>
        </div>
    </body>
</template>
  
<script>
export default {
    name: 'LoginView',
}
</script>
  
<style scoped>
body {
    background-image: url('../assets/Garden.jpg');
    background-repeat: no-repeat;
    background-size: cover;
}

.d-flex {
    margin-left: 75%;
}
</style>