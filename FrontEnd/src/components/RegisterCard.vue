<!-- 注册模块，仅在RegisterView里使用 -->

<template>
  <!-- 卡片 -->
  <div class="card">
    <div class="card-body">
      <form class="register" @submit.prevent="register">
        <!-- 用户名 -->
        <div class="input-group mb-3">
          <!-- 图标 -->
          <svg xmlns="http://www.w3.org/2000/svg" width="36" fill="currentColor" class="bi bi-person" viewBox="0 0 16 16">
            <path
              d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6Zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0Zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4Zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10Z" />
          </svg>
          &emsp;
          <!-- 输入用户名 -->
          <input v-model="state.username" type="text" class="form-control" placeholder="用户名" id="userid" />
        </div>

        <!-- 学工号 -->
        <div class="input-group mb-3">
          <!-- 图标 -->
          <svg xmlns="http://www.w3.org/2000/svg" width="36" fill="currentColor" class="bi bi-person" viewBox="0 0 16 16">
            <path
              d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6Zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0Zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4Zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10Z" />
          </svg>
          &emsp;
          <!-- 输入学工号 -->
          <input v-model="state.userid" type="password" class="form-control" placeholder="学工号" id="password" />
        </div>

        <!-- 密码 -->
        <div class="input-group mb-3">
          <!-- 图标 -->
          <svg xmlns="http://www.w3.org/2000/svg" width="36" fill="currentColor" class="bi bi-lock" viewBox="0 0 16 16">
            <path
              d="M8 1a2 2 0 0 1 2 2v4H6V3a2 2 0 0 1 2-2zm3 6V3a3 3 0 0 0-6 0v4a2 2 0 0 0-2 2v5a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2zM5 8h6a1 1 0 0 1 1 1v5a1 1 0 0 1-1 1H5a1 1 0 0 1-1-1V9a1 1 0 0 1 1-1z" />
          </svg>
          &emsp;
          <!-- 输入密码 -->
          <input v-model="state.password" type="password" class="form-control" placeholder="密码" id="password" />
        </div>

        <!-- 确认密码 -->
        <div class="input-group mb-3">
          <!-- 图标 -->
          <svg xmlns="http://www.w3.org/2000/svg" width="36" fill="currentColor" class="bi bi-lock" viewBox="0 0 16 16">
            <path
              d="M8 1a2 2 0 0 1 2 2v4H6V3a2 2 0 0 1 2-2zm3 6V3a3 3 0 0 0-6 0v4a2 2 0 0 0-2 2v5a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2zM5 8h6a1 1 0 0 1 1 1v5a1 1 0 0 1-1 1H5a1 1 0 0 1-1-1V9a1 1 0 0 1 1-1z" />
          </svg>
          &emsp;
          <!-- 输入密码 -->
          <input v-model="state.repassword" type="password" class="form-control" placeholder="确认密码" id="repassword" />
        </div>

        <!-- 错误提示 -->
        <div class="error-message">{{ error_message }}</div>

        <!-- 注册按钮 -->
        <button type="submit" class="btn btn-success">注册</button>

        <!-- 登录 -->
        <p class="text" @click="goto_login">登录</p>
      </form>
    </div>
  </div>
</template>
  
<script>
import router from "@/router/index";
import { reactive, ref, computed } from "vue";
import API from "@/api/basicApi.js";

export default {
  name: "RegisterCard",

  setup() {
    let error_message = ref("");

    // 定义响应式数据
    const state = reactive({
      username: "",
      userid: "",
      password: "",
      repassword: "",
    });

    // 定义计算属性
    const isUsernameValid = computed(() =>
      /^[a-zA-Z0-9_-]{4,16}$/.test(state.username)
    );
    const isIdValid = computed(() => /^[0-9]{7}$/.test(state.userid));
    const isPasswordValid = computed(() =>
      /^[a-zA-Z0-9]{6,16}$/.test(state.password)
    );

    const goto_login = () => {
      router.push({
        name: "login",
      });
    };

    /*检测输入的格式问题 */
    const FormatDetection = () => {
      if (!isUsernameValid.value) {
        error_message.value = "用户名格式不正确(允许大小写字母和数字,长度4-16)";
        return false;
      }
      if (!isIdValid.value) {
        error_message.value = "学工号格式不正确(0-9,长度7)";
        return false;
      }
      if (!isPasswordValid.value) {
        error_message.value = "密码格式不正确(允许大小写字母和数字,长度6-16)";
        return false;
      }
      if (state.password != state.repassword) {
        error_message.value = "两次密码不同";
        return false;
      }
      return true;
    };

    const register = () => {
      if (!FormatDetection()) {
        console.log("fail");
      } else {
        console.log("开始注册审核");
        API({
          url: "/Account/",
          method: "post",
          params: {
            id: state.userid,
            pwd: state.password,
            name: state.username,
          },
        }).then(
          function (res) {
            alert("注册成功，请登录");
            console.log(res);
            router.push({ name: "login" });
          },
          function (err) {
            console.log("fail");
            console.log(err);
            error_message.value = "连接数据库失败";
          }
        );
      }
    };

    return {
      state,
      isUsernameValid,
      isIdValid,
      isPasswordValid,
      error_message,
      goto_login,
      register,
      FormatDetection,
    };
  },
};
</script>
  
<style scoped>
.card {
  padding: 2vh;
  height: 61vh;
  width: 22vw;

  border-width: 3px;
  border-color: rgb(99, 110, 115);
  border-radius: 3vh;

  background-color: rgb(228, 220, 220);

  user-select: none;
  position: relative;
}

.form-control {
  font-weight: bold;
  background-color: lightgray;
  border-width: 0vh;
  color: rgb(12, 60, 38);
}

.form-control:hover {
  transform: scale(1.1);
  transition: 1000ms;
}

.error-message {
  color: red;
  margin-top: 1vh;
  margin-bottom: 1vh;
}

button {
  position: absolute;
  width: 70%;
  margin: 0 auto;
  bottom: 13vh;
  right: 3vw;
  font-weight: bold;
}

button:hover {
  transform: scale(1.2);
  transition: 1000ms;
}

.text {
  position: absolute;
  bottom: 3vh;
  right: 3vw;
  font-weight: bold;
  cursor: pointer;
}

.text:hover {
  transform: scale(1.2);
  transition: 1000ms;
}
</style>