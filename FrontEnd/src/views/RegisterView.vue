<template>
    <body>
        <div class="container">
            <div class="d-flex align-items-center" style="height: 100vh;">
                <!-- 组件内容 -->
                <RegisterCard />
            </div>
        </div>
    </body>
</template>
  
<script>
export default {
    name: 'RegisterView',
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
    height: 91.3vh;
}
</style>