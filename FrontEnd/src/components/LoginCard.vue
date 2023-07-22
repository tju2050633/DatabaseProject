<template>
  <div class="card" style="height: 250px">
    <div class="card-body">
      <form class="login" @submit.prevent="login">
        <!-- 用户名 -->
        <div class="input-group mb-3">
          <!-- 图标 -->
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="36"
            fill="currentColor"
            class="bi bi-person"
            viewBox="0 0 16 16"
          >
            <path
              d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6Zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0Zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4Zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10Z"
            />
          </svg>
          <!-- 输入用户名 -->
          <input
            v-model="state.username"
            type="text"
            class="form-control"
            placeholder="学工号/用户名"
            id="username"
          />
        </div>

        <!-- 密码 -->
        <div class="input-group mb-3">
          <!-- 图标 -->
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="36"
            fill="currentColor"
            class="bi bi-lock"
            viewBox="0 0 16 16"
          >
            <path
              d="M8 1a2 2 0 0 1 2 2v4H6V3a2 2 0 0 1 2-2zm3 6V3a3 3 0 0 0-6 0v4a2 2 0 0 0-2 2v5a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2zM5 8h6a1 1 0 0 1 1 1v5a1 1 0 0 1-1 1H5a1 1 0 0 1-1-1V9a1 1 0 0 1 1-1z"
            />
          </svg>
          <!-- 输入密码 -->
          <input
            v-model="state.password"
            type="password"
            class="form-control"
            placeholder="密码"
            id="password"
          />
        </div>

        <!-- 错误提示 -->
        <div class="error-message">{{ error_message }}</div>

        <!-- 登录按钮 -->
        <button type="submit" class="btn btn-primary">登录</button>

        <!-- 注册 -->
        <p class="text" @click="goto_register">注册账号</p>
      </form>
    </div>
  </div>
</template>
  
<script>
import router from "@/router/index";
import { reactive, ref, computed } from "vue";
import API from "@/api/basicApi.js";
import { useStore } from "vuex"; //引入使用共享数据的入口

export default {
  name: "LoginCard",

  setup() {
    let error_message = ref("");
    const store = useStore();

    // 定义响应式数据
    const state = reactive({
      username: "",
      userid: "",
      password: "",
      repassword: "",
    });

    const goto_register = () => {
      router.push({
        name: "register",
      });
    };

    // 定义计算属性
    const isIdValid = computed(() => /^[0-9]{7}$/.test(state.id));
    const isPasswordValid = computed(() =>
      /^[a-zA-Z0-9]{6,16}$/.test(state.password)
    );

    /*检测输入的格式问题 */
    const FormatDetection = () => {
      if (!isIdValid.value) {
        error_message.value = "学工号格式不正确";
        return false;
      }
      if (!isPasswordValid.value) {
        error_message.value = "密码格式不正确";
        return false;
      }
      return true;
    };

    const login = () => {
      error_message.value = "";

      console.log("开始登录审核");
      API({
        url: "/Account/",
        method: "get",
        params: {
          //   id: state.userid,
          //   pwd: state.password,
          id: state.username,
          pwd: state.password,
        },
      }).then(
        function (res) {
          alert("登录成功");
          console.log("success");
          console.log(res);
          router.push({ name: "home" });
          //修改is_login,使navbar的渲染变化
          store.commit("updateUser", { is_login: true });
          console.log(store.state.user);
        },
        function (err) {
          console.log("fail");
          console.log(err);
          error_message.value = "登录失败,用户名或密码错误";
        }
      );

      // ajaxs请求我这里调试不成功,改为熟悉的axios-- by 周成杰
      //   store.dispatch("login", {
      //     // username: username.value,
      //     // password: password.value,
      //     //传的参数必须和服务端的API相对应
      //     id: state.userid,
      //     pwd: state.password,

      //     success() {
      //       console.log("success");
      //       router.push({ name: "home" });
      //     },
      //     error() {
      //       console.log("fail");
      //       error_message.value = "用户名或密码错误";
      //     },
      //   });
    };

    return {
      state,
      error_message,
      isIdValid,
      isPasswordValid,
      FormatDetection,
      login,
      goto_register,
    };
  },
};
</script>
  
<style scoped>
.text {
  position: absolute;
  bottom: 5%;
  right: 10%;
  cursor: pointer;
}

button {
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