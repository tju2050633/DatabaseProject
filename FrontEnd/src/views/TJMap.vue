<template>
  <body class="mainmapbody">
    <!-- 导航栏 -->
    <NavBar />
    <br /><br /><br />
    <!-- 侧边栏 -->
    <el-row>
      <SideBar />
      <img class="tjimg" src="https://img1.imgtp.com/2023/08/09/QsXt6HjU.jpg" />
      <span class="TJMapHead">TongJI University</span>
    </el-row>
    <!--地图实例-->
    <CampusMap
      :latitude="this.$route.params.lat"
      :longtitude="this.$route.params.lng"
    />
  </body>
</template>
  
  <script>
export default {
  name: "TJMap",
};
</script>

<style scoped>
@import url("../css/map.css");
</style>