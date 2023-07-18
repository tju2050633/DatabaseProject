<template>
    <div class="card" style="height: 350px;">
        <div class="card-body">
            <form class="register" @submit.prevent="register">
                <!-- 用户名 -->
                <div class="input-group mb-3">
                    <!-- 图标 -->
                    <svg xmlns="http://www.w3.org/2000/svg" width="36" fill="currentColor" class="bi bi-person"
                        viewBox="0 0 16 16">
                        <path
                            d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6Zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0Zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4Zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10Z" />
                    </svg>
                    <!-- 输入用户名 -->
                    <input v-model="username" type="text" class="form-control" placeholder="用户名" id="username">
                </div>

                <!-- 学工号 -->
                <div class="input-group mb-3">
                    <!-- 图标 -->
                    <svg xmlns="http://www.w3.org/2000/svg" width="36" fill="currentColor" class="bi bi-person-fill"
                        viewBox="0 0 16 16">
                        <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3Zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6Z" />
                    </svg>
                    <!-- 输入学工号 -->
                    <input v-model="userID" type="text" class="form-control" placeholder="学工号" id="userID">
                </div>

                <!-- 密码 -->
                <div class="input-group mb-3">
                    <!-- 图标 -->
                    <svg xmlns="http://www.w3.org/2000/svg" width="36" fill="currentColor" class="bi bi-lock"
                        viewBox="0 0 16 16">
                        <path
                            d="M8 1a2 2 0 0 1 2 2v4H6V3a2 2 0 0 1 2-2zm3 6V3a3 3 0 0 0-6 0v4a2 2 0 0 0-2 2v5a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2zM5 8h6a1 1 0 0 1 1 1v5a1 1 0 0 1-1 1H5a1 1 0 0 1-1-1V9a1 1 0 0 1 1-1z" />
                    </svg>
                    <!-- 输入密码 -->
                    <input v-model="password" type="password" class="form-control" placeholder="密码" id="password">
                </div>

                <!-- 确认密码 -->
                <div class="input-group mb-3">
                    <!-- 图标 -->
                    <svg xmlns="http://www.w3.org/2000/svg" width="36" fill="currentColor" class="bi bi-lock-fill"
                        viewBox="0 0 16 16">
                        <path
                            d="M8 1a2 2 0 0 1 2 2v4H6V3a2 2 0 0 1 2-2zm3 6V3a3 3 0 0 0-6 0v4a2 2 0 0 0-2 2v5a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2z" />
                    </svg>
                    <!-- 输入密码 -->
                    <input v-model="password2" type="password" class="form-control" placeholder="确认密码" id="password2">
                </div>

                <!-- 错误提示 -->
                <div class="error-message">{{ error_message }}</div>

                <!-- 注册按钮 -->
                <button type="submit" class="btn btn-primary">注册</button>

                <!-- 登录 -->
                <p class="text" @click="goto_login">登录</p>
            </form>
        </div>
    </div>
</template>
  
<script>
import router from '@/router/index';
import { ref } from 'vue';
import { useStore } from 'vuex';

export default {
    name: "RegisterCard",

    setup() {
        const store = useStore();
        let username = ref('');
        let userID = ref('');
        let password = ref('');
        let password2 = ref('');
        let error_message = ref('');

        const goto_login = () => {
            router.push({
                name: 'login',
            });
        };

        const register = () => {
            error_message.value = '';

            store.dispatch("login", {
                username: username.value,
                password: password.value,
                success() {
                    console.log('success');
                    router.push({ name: 'home' });
                },
                error() {
                    console.log('fail');
                    error_message.value = '用户名或密码错误';
                }
            });
        };

        return {
            username,
            userID,
            password,
            password2,
            error_message,
            register,
            goto_login
        }
    }
}
</script>
  
<style scoped>
.text {
    position: absolute;
    bottom: 5%;
    right: 10%;
    cursor: pointer;
}

.btn {
    width: 100%;
    margin-top: 20px;
    display: block;
    margin: 0 auto;
}

.card {
    height: 40%;
}

.error-message {
    color: red;
}
</style>