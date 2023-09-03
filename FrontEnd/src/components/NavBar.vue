<!-- 导航栏组件 -->

<template>
  <nav class="navbar navbar-expand-lg fixed-top">
    <div class="container-fluid">
      <!-- logo与title -->
      <router-link class="navbar-brand" :to="{ name: 'home' }">
        <img
          src="../assets/logo.png"
          alt="Logo"
          width="30"
          class="d-inline-block align-text-top"
        />
        <span class="navbar-text">&emsp;共享花园</span>
      </router-link>

      <!-- 搜索框 -->
      <form
        class="d-flex justify-content-center"
        id="search-area"
        role="search"
        @submit.prevent
      >
        <!-- 输入框 -->
        <input
          class="form-control me-2"
          id="search-input"
          type="search"
          placeholder="搜索"
          aria-label="Search"
          v-model="state.searchTerm"
          @input="filterSearchHistory"
        />

        <!-- 搜索按钮 -->
        <button class="btn" id="search-btn" type="submit" @click="search">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            fill="currentColor"
            class="bi bi-search"
            viewBox="0 0 16 16"
          >
            <path
              d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"
            />
          </svg>
        </button>
      </form>

      <!-- 搜索历史记录下拉框 -->
      <li class="nav-item dropdown" id="history">
        <a
          class="nav-link dropdown-toggle"
          href="#"
          role="button"
          data-bs-toggle="dropdown"
          aria-expanded="false"
        >
          搜索历史
        </a>
        <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
          <ul class="list-group scrollable-list" ref="historyList">
            <li
              class="list-group-item"
              v-for="searchTerm in state.filteredSearchHistory"
              :key="searchTerm"
              @click="selectSearchTerm(searchTerm)"
            >
              {{ searchTerm }}
            </li>
            <li
              class="list-group-item text-danger"
              v-if="state.searchHistory.length > 0"
              @click="clearSearchHistory"
            >
              清空历史
            </li>
            <li
              class="list-group-item text-muted"
              v-if="state.searchHistory.length == 0"
              @click="clearSearchHistory"
            >
              没有历史记录
            </li>
          </ul>
        </ul>
      </li>

      <!-- 用户状态下拉菜单 -->
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item dropdown">
          <!-- 头像 -->
          <a
            class="nav-link dropdown-toggle"
            href="#"
            role="button"
            data-bs-toggle="dropdown"
            aria-expanded="false"
            style="color: white"
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="30"
              height="30"
              fill="currentColor"
              class="bi bi-person"
              viewBox="0 0 16 16"
            >
              <path
                d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6Zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0Zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4Zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10Z"
              />
            </svg>
          </a>

          <!-- 下拉菜单 -->
          <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
            <li>
              <router-link
                class="dropdown-item"
                v-if="!$store.state.user.is_login"
                :to="{ name: 'login' }"
                >登录</router-link
              >
            </li>

            <li>
              <router-link
                class="dropdown-item"
                v-if="$store.state.user.is_login"
                :to="{ name: 'personalInfo' }"
                >个人主页</router-link
              >
            </li>

            <li>
              <hr class="dropdown-divider" />
            </li>

            <li>
              <router-link
                class="dropdown-item"
                v-if="!$store.state.user.is_login"
                :to="{ name: 'register' }"
                >注册</router-link
              >
            </li>

            <li>
              <router-link
                class="dropdown-item"
                v-if="$store.state.user.is_login"
                :to="{ name: 'message' }"
                >消息通知</router-link
              >
            </li>

            <li>
              <hr class="dropdown-divider" />
            </li>

            <li>
              <router-link
                class="dropdown-item"
                :to="{ name: 'about' }"
                @click="scrollToTop"
                >关于我们</router-link
              >
            </li>

            <li>
              <hr class="dropdown-divider" />
            </li>

            <li>
              <router-link
                class="dropdown-item"
                :to="{ name: 'feedback' }"
                @click="scrollToTop"
                >反馈</router-link
              >
            </li>
          </ul>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
import { useStore } from "vuex";
import { reactive, onMounted } from "vue";
import router from "@/router";
import "../api/searchApi.js";
import { getSearchResults } from "../api/searchApi.js";

export default {
  name: "NavBar",

  setup() {
    const store = useStore();

    // 使用Vue 3的reactive函数创建响应式对象
    const state = reactive({
      searchHistory: JSON.parse(localStorage.getItem("searchHistory")) || [],
      searchTerm: "",
      filteredSearchHistory: [],

      //实际要用到的搜索结果，从后端数据库返回
      searchResults: [
        {
          type: "blog",
          data: [
            /* blog 搜索结果:
            {},-----这一个表示一个结果
            {},
            {} */
            {
              author: "作者1",
              avatar: require("../assets/author-avatar.jpg"),
              blogName: "博客名称1",
              partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
              fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
              showFullContent: false,
              isOpen: false,
              comments: [
                { user: "User1", content: "Comment 1" },
                { user: "User2", content: "Comment 2" },
                // Add more comments here
              ],
              liked: false, // 是否已点赞
              totalLikes: 114, // 总点赞次数
              showInput: false,
              comment: "",
            },
          ],
        },
        {
          type: "garden",
          data: [
            /* garden 搜索结果 */
            {
              imageUrl: require("../assets/Garden-e.jpg"),
              username: "Student1",
              gardenname: "Garden1",
              hot: "90",
            },
          ],
        },
        {
          type: "activity",
          data: [
            /* activity 搜索结果 */
            {
              author: "楚杰",
              title: "杰哥的安楼自习室",
              avatar: require("../assets/author-avatar.jpg"),
              imageurl: require("../assets/Garden.jpg"),
              time: "2020年1月1日",
              address: "安楼后面的小树林",
              detail: "给你看点好康的",
            },
          ],
        },
        {
          type: "volunteer",
          data: [
            /* volunteer 搜索结果 */
            {
              imageUrl: require("../assets/Garden-e.jpg"),
              dialogVisible: false, //是否出现弹窗
              username: "Student1",
              gardenname: "王浩的后宫1",
              location: "嘉定校区19号楼",
              describe: `诚邀您来维护本花园，主要工作如下：
                    首先，帮我把花园的土给翻了
                    然后，我的花园一盆花都没有，帮我全买了 
                    最后帮我浇水
                    谢谢你`,
            },
          ],
        },
      ],
    });

    // 监听搜索框的输入事件，过滤搜索记录,将相关的历史记录排序在前
    function filterSearchHistory() {
      // state.filteredSearchHistory = state.searchHistory.filter((searchTerm) =>
      //   searchTerm.toLowerCase().includes(state.searchTerm.toLowerCase())
      // );
      const searchTerm = this.state.searchTerm.toLowerCase();
      state.filteredSearchHistory = [...state.searchHistory]; // 创建副本以避免修改原始数据

      if (searchTerm.trim() !== "") {
        this.state.filteredSearchHistory.sort((a, b) => {
          const aMatch = a.toLowerCase().includes(searchTerm);
          const bMatch = b.toLowerCase().includes(searchTerm);

          if (aMatch && !bMatch) {
            return -1; // a 包含 searchTerm，b 不包含，将 a 排在前面
          } else if (!aMatch && bMatch) {
            return 1; // b 包含 searchTerm，a 不包含，将 b 排在前面
          } else {
            return 0; // a 和 b 都包含或都不包含 searchTerm，保持原始顺序
          }
        });
        console.log(this.state.filteredSearchHistory);
      }
    }

    onMounted(() => {
      state.filteredSearchHistory = [...state.searchHistory]; // 页面刷新时就赋值，避免未处理搜索框函数未调用时，历史记录不能正常显示
    });

    // 选择搜索记录，更新搜索框的值
    function selectSearchTerm(searchTerm) {
      state.searchTerm = searchTerm;
    }

    // 清空搜索历史记录
    function clearSearchHistory() {
      state.searchHistory = [];
      state.filteredSearchHistory = [];
      localStorage.removeItem("searchHistory");
    }

    //添加一个函数处理返回的搜索结果为前端所用的数据结构
    //将后端返回的数据格式改为前端使用的cards
    const toCard = (backendData) => {
      backendData.forEach((item) => {
        const type = item.type;
        const data = item.data;

        let formattedItem = {};

        if (type === "blog") {
          // 如果类型为博客(blog)
          const blogData = data.map((blog) => ({
            author: blog.author,
            avatar: require("../assets/author-avatar.jpg"), // 根据需要设置正确的路径
            blogName: blog.blogName,
            partialContent: blog.partialContent,
            fullContent: blog.fullContent,
            showFullContent: blog.showFullContent,
            isOpen: blog.isOpen,
            comments: blog.comments,
            liked: blog.liked,
            totalLikes: blog.totalLikes,
            showInput: blog.showInput,
            comment: blog.comment,
          }));

          formattedItem = {
            type: "blog",
            data: blogData,
          };
        } else if (type === "garden") {
          // 如果类型为花园(garden)
          const gardenData = data.map((garden) => ({
            imageUrl: require("../assets/Garden-e.jpg"), // 根据需要设置正确的路径
            username: garden.username,
            gardenname: garden.gardenname,
            hot: garden.hot,
          }));

          formattedItem = {
            type: "garden",
            data: gardenData,
          };
        } else if (type === "activity") {
          // 如果类型为活动(activity)
          // 这里可以根据需要设置物品数据的格式
          const activityData = data.map((activity) => ({
            author: activity.author,
            title: activity.title,
            avatar: require("../assets/author-avatar.jpg"), // 根据需要设置正确的路径
            imageurl: require("../assets/Garden.jpg"), // 根据需要设置正确的路径
            time: activity.time,
            address: activity.address,
            detail: activity.detail,
          }));
          formattedItem = {
            type: "activity",
            data: activityData,
          };
        } else if (type === "volunteer") {
          // 如果类型为志愿者(volunteer)
          const volunteerData = data.map((volunteer) => ({
            imageUrl: require("../assets/Garden-e.jpg"), // 根据需要设置正确的路径
            dialogVisible: volunteer.dialogVisible,
            username: volunteer.username,
            gardenname: volunteer.gardenname,
            location: volunteer.location,
            describe: volunteer.describe,
          }));

          formattedItem = {
            type: "volunteer",
            data: volunteerData,
          };
        }

        state.searchResults.push(formattedItem);
      });
    };

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
        state.filteredSearchHistory = [...state.searchHistory];
      }
      console.log("搜索成功");

      //通过API接口将搜索关键字传到后端，后端访问数据库给出处理并返回结果
      getSearchResults(state.searchTerm).then(
        function (res) {
          console.log("获取成功");
          //测试获得的内容
          console.log(res.data);
          //转换格式
          toCard(res.data);
        },
        function (err) {
          console.log("获取失败", err.data);
        }
      );

      const isSearchResultsEmpty = state.searchResults.every(
        (result) => result.data.length === 0
      );
      if (isSearchResultsEmpty) {
        // 搜索结果为空的处理逻辑
        alert("搜索结果为空！！！");
      } else {
        // 搜索结果不为空的处理逻辑
        router.push({
          name: "SearchResults",
          params: { results: JSON.stringify(state.searchResults) },
        });
      }
    }

    // 页面滚动到顶部
    function scrollToTop() {
      window.scrollTo({ top: 0, behavior: "smooth" });
    }

    return {
      store,
      state,
      onMounted,
      filterSearchHistory,
      search,
      selectSearchTerm,
      clearSearchHistory,
      toCard,
      scrollToTop,
    };
  },
};
</script>

<style scoped>
.navbar {
  background-color: rgb(53, 115, 90);
}

.navbar-brand {
  margin-left: 3vw;
}

.navbar-text {
  color: white;
}

#search-area {
  width: 53vw;
  flex-direction: row;
  align-items: center;
}

#search-input {
  margin-left: 15vw;
  border-radius: 20px;
  border: 1px solid #ccc;
  padding: 5px 10px;
}

#search-btn {
  border-width: 0vh;
  border-radius: 50%;

  background-color: white;
  color: rgb(12, 60, 38);
}

#history {
  margin-left: 1vw;
  margin-right: 15vw;
  list-style: none;
  color: white;
  font-size: 2.5vh;
}

.navbar-nav {
  margin-right: 5vw;
}

.scrollable-list {
  max-height: 400px; /* 设置最大高度 */
  overflow-y: auto; /* 添加垂直滚动条 */
}
</style>