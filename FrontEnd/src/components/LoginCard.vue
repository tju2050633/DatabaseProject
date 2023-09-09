<!-- 登录模块，仅在LoginView里使用 -->

<template>
  <!-- 卡片 -->
  <div class="card">
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
          &emsp;
          <!-- 输入学工号 -->
          <input
            v-model="state.userid"
            type="text"
            class="form-control"
            placeholder="学工号"
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
          &emsp;
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
        <button type="submit" class="btn btn-success">登录</button>

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
    const isIdValid = computed(() => /^[0-9]{7}$/.test(state.userid));
    const isPasswordValid = computed(() =>
      /^[a-zA-Z0-9]{6,16}$/.test(state.password)
    );

    /*检测输入的格式问题 */
    const FormatDetection = () => {
      if (!isIdValid.value) {
        error_message.value = "学工号格式不正确(0-9,长度7)";
        return false;
      }
      if (!isPasswordValid.value) {
        error_message.value = "密码格式不正确(允许大小写字母和数字,长度6-16)";
        return false;
      }
      return true;
    };

    const login = () => {
      error_message.value = "";

      console.log("开始登录审核");
      API({
        url: "/Account/login",
        method: "get",
        params: {
          id: state.userid,
          pwd: state.password,
        },
      }).then(
        function (res) {
          alert("登录成功");
          console.log("success");
          console.log(res);
          router.push({ name: "home" });
          //修改is_login,使navbar的渲染变化
          store.commit("updateUser", {
            id: state.userid,
            username: "",
            photo: "",
            followerCount: 0,
            access: "",
            refresh: "",
            is_login: true,
          });
          // store.commit("updateUser", { id: state.id });
          console.log(store.state.user);
        },
        function (err) {
          console.log("fail");
          console.log(err);
          error_message.value = "登录失败,用户名或密码错误";
        }
      );

      // ajaxs请求我这里调试不成功,改为熟悉的axios-- by 周成杰
      // store.dispatch("login", {
      //   username: username.value,
      //   password: password.value,
      //   //传的参数必须和服务端的API相对应
      //   id: state.userid,
      //   pwd: state.password,

      //   success() {
      //     console.log("success");
      //     router.push({ name: "home" });
      //   },
      //   error() {
      //     console.log("fail");
      //     error_message.value = "用户名或密码错误";
      //   },
      // });
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
.card {
  padding: 2vh;
  height: 45vh;
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