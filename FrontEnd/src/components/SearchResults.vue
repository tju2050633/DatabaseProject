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
    <br />
    <br />
    <br />
    <div>
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
    <br />
    <br />
    <br />
    <div>
      <el-row>
        <el-col :span="14" :offset="2">
          <div>
            <img class="all-img-head" src="../assets/volunteer-header.png" />
          </div>
          <el-card
            v-for="(content, index) in volunteerResults"
            :key="index"
            class="gardenResults"
          >
            <VolunteerBlock :content="content" />
          </el-card>
          <div>
            <button @click="loadMore('VolunteerRecruitment')">查看更多</button>
          </div>
        </el-col>
      </el-row>
    </div>
    <br />
    <br />
    <br />
    <div class="item-field">
      <el-row>
        <el-col :span="14" :offset="2">
          <div>
            <img class="all-img-head" src="../assets/item-header.png" />
          </div>
          <div class="row" v-for="i in 2" :key="i">
            <ItemBlock />
          </div>
          <div>
            <button @click="loadMore('home')">查看更多</button>
          </div>
        </el-col>
      </el-row>
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

export default {
  name: "searchResults",
  props: {
    results: Array,
  },
  setup(props) {
    const results = JSON.parse(props.results);
    // 访问 "blog" 类型的搜索结果数据
    const blogResults = results?.find((result) => result.type === "blog")?.data;
    // 访问 "garden" 类型的搜索结果数据
    const gardenResults = results?.find(
      (result) => result.type === "garden"
    )?.data;
    // 访问 "item" 类型的搜索结果数据
    const itemResults = results?.find((result) => result.type === "item")?.data;
    // 访问 "volunteer" 类型的搜索结果数据
    const volunteerResults = results?.find(
      (result) => result.type === "volunteer"
    )?.data;

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

    return {
      blogResults,
      gardenResults,
      itemResults,
      volunteerResults,
      scrollToTop,
      loadMore,
    };
  },
};
</script>

<style>
@import url("../css/search-results.css");
</style>