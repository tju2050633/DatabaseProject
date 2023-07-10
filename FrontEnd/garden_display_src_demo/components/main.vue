<template>
  <el-header>
    <el-row :span="24">
      <el-col :offset="1" :span="1">
        <img src="" class="logo"/>
      </el-col>
      <el-col :span="2" class="logo-text">
        花园展厅
      </el-col>
      <el-col :span="9" :offset="2">
        <el-input style="margin-top: 10px;" v-model="searchData" />
      </el-col>
      <el-col :span="1">
        <el-button type="primary"  style="margin-top: 10px;"><el-icon><search/></el-icon></el-button>
      </el-col>
      <el-col>
          
      </el-col>
    </el-row>
  </el-header>
  <el-row> 
    <el-col :span="3">
      <el-menu>
        <el-sub-menu index="1">
          <template #title>
            <el-icon><user /></el-icon>
            <span>账号管理</span>
          </template>
          <el-menu-item index="1-1">item one</el-menu-item>
        </el-sub-menu>
        <el-sub-menu index="2">
          <template #title>
            <el-icon><position /></el-icon>
            <span>校园地图</span>
          </template>
          <el-menu-item index="2-1">item one</el-menu-item>
        </el-sub-menu>
        <el-sub-menu index="3">
          <template #title>
            <el-icon><house /></el-icon>
            <span>花园管理</span>
          </template>
          <el-menu-item index="3-1" @click="this.$router.push('GardenManage')">item one</el-menu-item>
        </el-sub-menu>
        <el-sub-menu index="4">
          <template #title>
            <el-icon><chatSquare /></el-icon>
            <span>博客论坛</span>
          </template>
          <el-menu-item index="4-1">item one</el-menu-item>
        </el-sub-menu>
      </el-menu>
    </el-col>
    <el-col :span="21">
      <RouterView></RouterView>
    </el-col>
  </el-row>
</template>


<style scoped>
.logo{
  border-radius: 50%;
  width:50px;
}

.logo-text{
  margin-top: 10px;
}
</style>


<script>
export default {
  name: "app",
  data() {
    return {
      searchData: "",
    };
  },
  methods: {},
};
</script>

