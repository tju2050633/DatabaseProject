<template>
  <!-- 导航栏 -->
  <NavBar />

  <body>
    <br />
    <br />
    <br />
    <div class="d-flex">
      <div class="row" style="width: 100%">
        <!-- 侧边栏 -->
        <div class="col-2">
          <SideBar />
        </div>

        <!-- 主体内容 -->
        <div class="col-10">
          <!-- 组件内容 -->
          <SearchResults :results="this.$route.params.results" />
        </div>
      </div>
    </div>
    <br />
    <br />
    <br />
  </body>
</template>
  
<script>
export default {
  name: "SearchResultView",
  props: ["results"], // 声明接收名为results的参数
};
</script>