<template>
    <body>
        <div class="container">
            <div class="d-flex align-items-center">
                <!-- 组件内容 -->
                <RegisterCard />
            </div>
        </div>
    </body>
</template>
  
<script>
import RegisterCard from '@/components/RegisterCard.vue';

export default {
    name: 'RegisterView',
    components: {
        RegisterCard
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
    height: 91.3vh;
}
</style>