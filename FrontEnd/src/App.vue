<template>
  <div id="app">
    <NavBar />
    <!--导航栏-->
    <router-view />
    <!--路由组件-->
  </div>
</template>

<script>
import NavBar from "./components/NavBar";

export default {
  name: "App",
  components: {
    NavBar,
  },
};
</script>

<style scoped></style>