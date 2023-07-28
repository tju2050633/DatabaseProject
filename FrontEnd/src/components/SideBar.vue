<!-- 侧边栏组件-->

<template>
  <el-col :span="3">
    <el-menu>
      <el-sub-menu index="1">
        <template #title>
          <el-icon><user /></el-icon>
          <span>账号管理</span>
        </template>
        <el-menu-item index="1-1" @click="this.$router.push('/personalInfo/')">我的主页</el-menu-item>
        <el-menu-item index="1-2" @click="this.$router.push('/login/')">登入/登出</el-menu-item>
      </el-sub-menu>
      <el-sub-menu index="2">
        <template #title>
          <el-icon><position /></el-icon>
          <span>校园地图</span>
        </template>
        <el-menu-item index="2-1" @click="this.$router.push('/map/SiPing')">四平路校区</el-menu-item>
        <el-menu-item index="2-2" @click="this.$router.push('/map/JiaDing')">嘉定校区</el-menu-item>
        <el-menu-item index="2-3" @click="this.$router.push('/map/HuXi')">沪西校区</el-menu-item>
      </el-sub-menu>
      <el-sub-menu index="3">
        <template #title>
          <el-icon><house /></el-icon>
          <span>花园管理</span>
        </template>
        <el-menu-item index="3-1" @click="this.$router.push('/display/')">精选花园</el-menu-item>
        <el-menu-item index="3-2" @click="this.$router.push('/garden/')">我的花园</el-menu-item>
      </el-sub-menu>
      <el-sub-menu index="4">
        <template #title>
          <el-icon><chatSquare /></el-icon>
          <span>博客论坛</span>
        </template>
        <el-menu-item index="4-1" @click="this.$router.push('/BlogView/')">精选博客</el-menu-item>
        <el-menu-item index="4-2" @click="this.$router.push('/BlogView/')">我的发表</el-menu-item>
      </el-sub-menu>
    </el-menu>
  </el-col>
</template>

<script>
export default {
    name: "SideBar",
}

</script>
