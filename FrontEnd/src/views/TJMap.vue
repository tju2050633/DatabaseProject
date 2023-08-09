<template>
  <!-- 导航栏 -->
  <NavBar />
  <!-- 侧边栏 -->
  <SideBar />
  <!--地图实例-->
  <CampusMap
    :latitude="this.$route.params.lat"
    :longtitude="this.$route.params.lng"
  />
</template>
  
  <script>
export default {
  name: "TJMap",
};
</script>