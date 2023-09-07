<!-- 侧边栏组件-->

<template>
  <el-col :span="3">
    <el-menu>
      <el-sub-menu index="1">
        <template #title>
          <el-icon>
            <user />
          </el-icon>
          <span>账号管理</span>
        </template>

        <el-menu-item index="1-1" @click="this.$router.push('/personalInfo/')"
          >我的主页</el-menu-item
        >
        <el-menu-item index="1-2" @click="this.$router.push('/login/')"
          >登入/登出</el-menu-item
        >
      </el-sub-menu>

      <el-sub-menu index="2">
        <template #title>
          <el-icon>
            <position />
          </el-icon>
          <span>校园地图</span>
        </template>

        <el-menu-item
          index="2-1"
          @click="
            this.$router
              .push({
                name: 'TJMap',
                params: { lng: 121.505829, lat: 31.285099 },
              })
              .then(() => {
                // 手动触发页面刷新,仅改变传参未改变路由，router不自动更改页面内容===>此处修复地图页面不能更改其他校区页面的bug
                refreshPage();
              })
          "
        >
          四平路校区
        </el-menu-item>
        <el-menu-item
          index="2-1"
          @click="
            this.$router
              .push({
                name: 'TJMap',
                params: { lng: 121.220631, lat: 31.291873 },
              })
              .then(() => {
                // 手动触发页面刷新,仅改变传参未改变路由，router不自动更改页面内容
                refreshPage();
              })
          "
        >
          嘉定校区
        </el-menu-item>
        <el-menu-item
          index="2-1"
          @click="
            this.$router
              .push({
                name: 'TJMap',
                params: { lng: 121.397398, lat: 31.277339 },
              })
              .then(() => {
                // 手动触发页面刷新,仅改变传参未改变路由，router不自动更改页面内容
                refreshPage();
              })
          "
        >
          沪西校区
        </el-menu-item>
      </el-sub-menu>

      <el-sub-menu index="3">
        <template #title>
          <el-icon>
            <house />
          </el-icon>
          <span>花园管理</span>
        </template>
        <el-menu-item index="3-1" @click="this.$router.push('/display/')"
          >精选花园</el-menu-item
        >
        <el-menu-item index="3-2" @click="this.$router.push('/garden/')"
          >我的花园</el-menu-item
        >
      </el-sub-menu>

      <el-sub-menu index="4">
        <template #title>
          <el-icon>
            <chatSquare />
          </el-icon>
          <span>博客论坛</span>
        </template>
        <el-menu-item index="4-1" @click="this.$router.push('/BlogView/')"
          >精选博客</el-menu-item
        >
        <el-menu-item index="4-2" @click="this.$router.push('/BlogPost/')"
          >发表博客</el-menu-item
        >
      </el-sub-menu>
    </el-menu>
  </el-col>
</template>

<style scoped>
.el-menu {
  padding: 1vh;

  border-width: 0vh;
  border-radius: 2vh;

  box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
  background-color: rgb(244, 237, 228);

  margin-top: 3vh;
  margin-bottom: 3vh;

  position: fixed;

  height: 85vh;
  width: 10vw;

  color: rgb(12, 60, 38);
}

.el-menu-item {
  background-color: rgb(244, 237, 228);
}
</style>

<script>
export default {
  name: "SideBar",
  methods: {
    refreshPage() {
      location.reload();
    },
  },
};
</script>
