<template>
    <!-- 导航栏 -->
    <NavBar />

    <body>
        <div class="d-flex align-items-center">
            <!-- 组件内容 -->
            <RegisterCard />
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
    animation: fade-in 2s forwards;
}

@keyframes fade-in {
    0% {
        opacity: 0;
    }

    100% {
        opacity: 1;
    }
}

.d-flex {
    height: 100vh;
    margin-left: 70vw;
    animation: slide-in-from-top 2s;
}

@keyframes slide-in-from-top {
    from {
        transform: translateY(-100%);
    }

    to {
        transform: translateY(0);
    }
}
</style>