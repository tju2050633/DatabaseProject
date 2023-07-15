<template>
  <div id='app'>
    <NavBar /> <!--导航栏-->
    <RouterView></RouterView>
    <router-view /> <!--路由组件-->
  </div>
</template>

<script>
import NavBar from './components/NavBar';

export default {
  name: "App",
  components: {
    NavBar,
  }
}
</script>

<style></style>