<!-- 个人信息页面的花园模块 -->

<template>
  <div>
    <h2>
      <el-icon style="user: 10px"><User /></el-icon>
      <span class="spaninfohead">{{ Garden.author }}</span>
    </h2>
    <h1>
      <span class="spaninfohead">{{ Garden.title }}</span>
    </h1>
    <el-image class="card-img" :src="Garden.cover" :fit="fill" />
  </div>
</template>

<script>
export default {
  props: ["Garden"],
};
</script>

<style scoped>
@import url("../css/personalInfo.css");
</style>