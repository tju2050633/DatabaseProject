<template>
  <body class="result-body">
    <div>
      <el-col :span="14">
        <el-card class="result-header">
          <img
            style="width: 950px; height: 250px"
            src="../assets/searchResults.png"
          /> </el-card
      ></el-col>

      <!-- 标签栏 -->

      <br /><br />

      <el-row :gutter="30">
        <el-col :offset="0">
          <el-breadcrumb separator="|">
            <el-breadcrumb-item :to="{}" class="navtag"></el-breadcrumb-item>
            <el-breadcrumb-item
              :to="{}"
              @click="refresh(1)"
              :class="{ active: chooseComponent === 1 }"
              class="navtag"
              >博客</el-breadcrumb-item
            >
            <el-breadcrumb-item
              :to="{}"
              @click="refresh(2)"
              :class="{ active: chooseComponent === 2 }"
              class="navtag"
              >花园</el-breadcrumb-item
            >
            <el-breadcrumb-item
              :to="{}"
              @click="refresh(3)"
              :class="{ active: chooseComponent === 3 }"
              class="navtag"
              >志愿</el-breadcrumb-item
            >
            <el-breadcrumb-item
              :to="{}"
              @click="refresh(4)"
              :class="{ active: chooseComponent === 4 }"
              class="navtag"
              >活动</el-breadcrumb-item
            >
            <el-breadcrumb-item :to="{}" class="navtag"></el-breadcrumb-item>
          </el-breadcrumb>
        </el-col>
      </el-row>

      <!-- 功能页 -->
      <el-container class="functions">
        <!-- 博客 -->
        <div
          class="blog"
          style="margin-left: 100px"
          v-if="chooseComponent == 1"
        >
          <br />
          <el-row class="d-flex">
            <el-col :span="14" :offset="2">
              <div>
                <img class="all-img-head" src="../assets/blog-header.png" />
              </div>
              <el-card
                v-for="(card, index) in blogResults"
                :key="index"
                class="blogResults"
              >
                <BlogBlock :card="card" />
              </el-card>
              <div>
                <button @click="loadMore('BlogView')">查看更多</button>
              </div>
            </el-col>
          </el-row>
        </div>

        <!-- 花园 -->
        <div
          class="garden"
          style="margin-left: 100px"
          v-if="chooseComponent == 2"
        >
          <br />
          <el-row>
            <el-col :span="14" :offset="2">
              <div>
                <img class="all-img-head" src="../assets/garden-header.png" />
              </div>
              <el-card
                v-for="(image, index) in gardenResults"
                :key="index"
                class="gardenResults"
              >
                <GardenBlock :image="image" />
              </el-card>
              <div>
                <button @click="loadMore('display')">查看更多</button>
              </div>
            </el-col>
          </el-row>
        </div>

        <!-- 志愿 -->
        <div
          class="volunteer"
          style="margin-left: 100px"
          v-if="chooseComponent == 3"
        >
          <br />
          <el-row>
            <el-col :span="14" :offset="2">
              <div>
                <img
                  class="all-img-head"
                  src="../assets/volunteer-header.png"
                />
              </div>
              <el-card
                v-for="(content, index) in volunteerResults"
                :key="index"
                class="volunteerResults"
              >
                <VolunteerBlock :content="content" />
              </el-card>
              <div>
                <button @click="loadMore('VolunteerRecruitment')">
                  查看更多
                </button>
              </div>
            </el-col>
          </el-row>
        </div>

        <!-- 活动 -->
        <div
          class="others"
          style="margin-left: 100px"
          v-if="chooseComponent == 4"
        >
          <br />
          <el-row>
            <el-col :span="14" :offset="2">
              <div>
                <img class="all-img-head" src="../assets/activity-header.png" />
              </div>
              <el-card v-for="(card, index) in itemResults" :key="index">
                <GardenActivityBlock :card="card" />
              </el-card>
              <div>
                <button @click="loadMore('GardenActivities')">查看更多</button>
              </div>
            </el-col>
          </el-row>
        </div>
      </el-container>
    </div>

    <!--回到顶部-->
    <el-backtop :bottom="70" :right="60">
      <div class="back-to-top">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="16"
          height="16"
          fill="currentColor"
          class="bi bi-arrow-up-circle"
          viewBox="0 0 16 16"
        >
          <path
            fill-rule="evenodd"
            d="M1 8a7 7 0 1 0 14 0A7 7 0 0 0 1 8zm15 0A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-7.5 3.5a.5.5 0 0 1-1 0V5.707L5.354 7.854a.5.5 0 1 1-.708-.708l3-3a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1-.708.708L8.5 5.707V11.5z"
          />
        </svg>
        返回顶部
      </div>
    </el-backtop>
  </body>
</template>

<script>
import router from "@/router/index";
import { ref } from "vue";

export default {
  name: "searchResults",
  props: {
    results: Array,
  },
  setup(props) {
    const results = JSON.parse(props.results);
    console.log("搜索结果处理：", results);
    // 访问 "blog" 类型的搜索结果数据
    const blogResults = results?.find((result) => result.type === "blog")?.data;
    // 访问 "garden" 类型的搜索结果数据
    const gardenResults = results?.find(
      (result) => result.type === "garden"
    )?.data;
    // 访问 "item" 类型的搜索结果数据（改为活动类）
    const activityResults = results?.find(
      (result) => result.type === "activity"
    )?.data;
    // 访问 "volunteer" 类型的搜索结果数据
    const volunteerResults = results?.find(
      (result) => result.type === "volunteer"
    )?.data;

    console.log("博客类型结果：", blogResults);
    console.log("花园类型结果：", gardenResults);
    console.log("活动类型结果：", activityResults);
    console.log("志愿类型结果：", volunteerResults);

    //标签选项
    const chooseComponent = ref(1);

    // 页面滚动到顶部
    function scrollToTop() {
      window.scrollTo({ top: 0, behavior: "smooth" });
    }

    //跳转到对应的主页的按钮
    function loadMore(pagename) {
      scrollToTop();
      router.push({
        name: pagename,
      });
    }

    //通过v-if 展示四个不同的组件
    function refresh(index) {
      chooseComponent.value = index;
      console.log(chooseComponent);
    }

    return {
      blogResults,
      gardenResults,
      activityResults,
      volunteerResults,
      chooseComponent,
      scrollToTop,
      loadMore,
      refresh,
    };
  },
};
</script>

<style>
@import url("../css/search-results.css");
</style>