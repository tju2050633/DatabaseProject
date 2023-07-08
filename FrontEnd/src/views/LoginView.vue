<template>
    <body>
        <div class="container">
            <div class="d-flex align-items-center" style="height: 91.3vh;">
                <!-- 组件内容 -->
                <LoginCard />
            </div>
        </div>

    </body>
</template>
  
<script>
import LoginCard from '@/components/LoginCard.vue';

export default {
    name: 'LoginView',
    components: {
        LoginCard
    }
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

.error-message {
    color: red;
}
</style>