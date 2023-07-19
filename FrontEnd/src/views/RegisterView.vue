<template>
  <body>
    <div class="container">
      <div class="d-flex align-items-center" style="height: 91.3vh">
        <div class="card mx-auto my-auto h-50">
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
                <input v-model="state.username" type="text" class="form-control" placeholder="用户名" id="username" />
              </div>

              <!-- 学工号 -->
              <div class="input-group mb-3">
                <!-- 图标 -->
                <svg xmlns="http://www.w3.org/2000/svg" width="36" fill="currentColor" class="bi bi-person"
                  viewBox="0 0 16 16">
                  <path
                    d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6Zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0Zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4Zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10Z" />
                </svg>
                <!-- 输入学工号 -->
                <input v-model="state.username" type="text" class="form-control" placeholder="学工号" id="userid" />
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
                <input v-model="state.password" type="password" class="form-control" placeholder="密码" id="password" />
              </div>

              <!-- 确认密码 -->
              <div class="input-group mb-3">
                <!-- 图标 -->
                <svg xmlns="http://www.w3.org/2000/svg" width="36" fill="currentColor" class="bi bi-lock"
                  viewBox="0 0 16 16">
                  <path
                    d="M8 1a2 2 0 0 1 2 2v4H6V3a2 2 0 0 1 2-2zm3 6V3a3 3 0 0 0-6 0v4a2 2 0 0 0-2 2v5a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2zM5 8h6a1 1 0 0 1 1 1v5a1 1 0 0 1-1 1H5a1 1 0 0 1-1-1V9a1 1 0 0 1 1-1z" />
                </svg>
                <!-- 输入密码 -->
                <input v-model="state.repassword" type="password" class="form-control" placeholder="确认密码"
                  id="repassword" />
              </div>

              <!-- 错误提示 -->
              <div class="error-message">{{ error_message }}</div>

              <!-- 登录按钮 -->
              <button type="submit" class="btn btn-primary">注册</button>

              <!-- 注册 -->
              <p class="text" @click="goto_login">登录</p>
            </form>
          </div>
        </div>
      </div>
    </div>
  </body>
</template>
  
<script>
import router from "@/router/index";
import { reactive, ref, computed } from "vue";
import API from "@/api/basicApi.js";

export default {
  name: "RegisterView",
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
    const isIdValid = computed(() => /^[0-9]{7}$/.test(state.id));
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
        error_message.value = "用户名格式不正确";
        return false;
      }
      if (!isIdValid.value) {
        error_message.value = "学工号格式不正确";
        return false;
      }
      if (!isPasswordValid.value) {
        error_message.value = "密码格式不正确";
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
          url: "/HelloWorld/Options",
          method: "post",
          params: {
            _username: state.username,
            _userid: state.userid,
            _password: state.password,
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
body {
  background-image: url('../assets/Garden.jpg');
  background-repeat: no-repeat;
  background-size: cover;
}

.d-flex {
  margin-left: 75%;
  height: 91.3vh;

  /* 使用到自己创建的图床 */
  background-image: url("https://img1.imgtp.com/2023/07/18/8174q8tl.jpg");
  background-repeat: no-repeat;
  background-size: cover;
}

.d-flex {
  margin-left: 75%;
}

.error-message {
  color: red;
}

.card {
  height: 100%;
}

.btn {
  width: 100%;
}

.text {
  position: relative;
  top: 30px;
  left: 200px;
}
</style>