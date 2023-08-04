<!-- 导航栏组件 -->

<template>
  <nav class="navbar navbar-expand-lg fixed-top" style="background-color: rgb(12, 75, 51)">
    <div class="container-fluid">

      <!-- logo与title -->
      <router-link class="navbar-brand" :to="{ name: 'home' }" style="margin-left: 50px">
        <img src="../assets/logo.png" alt="Logo" width="30" class="d-inline-block align-text-top" />
        <span class="navbar-text" style="color: white;"> 共享花园 </span>
      </router-link>

      <!-- 搜索框 -->
      <form class="d-flex" role="search" style="min-width: 60%; margin-left: auto; margin-right: auto" @submit.prevent>
        <!-- 输入框 -->
        <input class="form-control me-2" type="search" placeholder="搜索" aria-label="Search" v-model="state.searchTerm"
          @input="filterSearchHistory" />

        <!-- 搜索按钮 -->
        <button class="btn btn-outline-success" type="submit" @click="search">
          <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search"
            viewBox="0 0 16 16">
            <path
              d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z" />
          </svg>
        </button>
      </form>

      <!-- 搜索历史记录下拉框 -->
      <li class="nav-item dropdown">
        <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
          搜索历史
        </a>
        <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
          <ul class="list-group">
            <li class="list-group-item" v-for="searchTerm in state.filteredSearchHistory" :key="searchTerm"
              @click="selectSearchTerm(searchTerm)">
              {{ searchTerm }}
            </li>
            <li class="list-group-item text-danger" v-if="state.searchHistory.length > 0" @click="clearSearchHistory">
              清空历史
            </li>
          </ul>
        </ul>
      </li>

      <!-- 用户状态下拉菜单 -->
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item dropdown">

          <!-- 头像 -->
          <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
            <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-person"
              viewBox="0 0 16 16">
              <path
                d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6Zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0Zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4Zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10Z" />
            </svg>
          </a>

          <!-- 下拉菜单 -->
          <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
            <li>
              <router-link class="dropdown-item" v-if="!$store.state.user.is_login" :to="{ name: 'login' }">
                登录
              </router-link>
            </li>

            <li>
              <router-link class="dropdown-item" v-if="$store.state.user.is_login" :to="{ name: 'personalInfo' }">
                个人主页
              </router-link>
            </li>

            <li>
              <hr class="dropdown-divider" />
            </li>

            <li>
              <router-link class="dropdown-item" v-if="!$store.state.user.is_login" :to="{ name: 'register' }">
                注册
              </router-link>
            </li>

            <li>
              <router-link class="dropdown-item" v-if="$store.state.user.is_login" :to="{ name: 'message' }">
                消息通知
              </router-link>
            </li>

            <li>
              <hr class="dropdown-divider" />
            </li>

            <li>
              <router-link class="dropdown-item" :to="{ name: 'about' }">
                关于我们
              </router-link>
            </li>

            <li>
              <hr class="dropdown-divider" />
            </li>

            <li>
              <router-link class="dropdown-item" :to="{ name: 'feedback' }">
                反馈
              </router-link>
            </li>

          </ul>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
import { useStore } from "vuex";
import { reactive } from "vue";

export default {
  name: "NavBar",

  setup() {
    const store = useStore();

    // 使用Vue 3的reactive函数创建响应式对象
    const state = reactive({
      searchHistory: JSON.parse(localStorage.getItem("searchHistory")) || [],
      searchTerm: "",
      filteredSearchHistory: [],
    });

    // 监听搜索框的输入事件，过滤搜索记录
    function filterSearchHistory() {
      state.filteredSearchHistory = state.searchHistory.filter((searchTerm) =>
        searchTerm.toLowerCase().includes(state.searchTerm.toLowerCase())
      );
    }

    // 选择搜索记录，更新搜索框的值
    function selectSearchTerm(searchTerm) {
      state.searchTerm = searchTerm;
    }

    // 清空搜索历史记录
    function clearSearchHistory() {
      state.searchHistory = [];
      localStorage.removeItem("searchHistory");
    }

    // 监听搜索表单的提交事件，保存新的搜索记录（这里实现正式的搜索算法）
    function search() {
      if (state.searchTerm.trim()) {
        console.log("正在储存");
        state.searchHistory.unshift(state.searchTerm.trim());
        localStorage.setItem(
          "searchHistory",
          JSON.stringify(state.searchHistory)
        );
        state.searchTerm = "";
      }
      console.log("搜索成功");
    }

    return {
      store,
      state,
      filterSearchHistory,
      search,
      selectSearchTerm,
      clearSearchHistory,
    };
  },
};
</script>

<style scoped></style>