<template>
  <el-row>
    <el-col :span="5">
      <el-row style="font-size: medium">
        <el-col :span="1" :offset="2">
          <el-icon style="margin-top: 5px"><user /></el-icon>
        </el-col>
        <el-col :span="2">楚杰</el-col>
        <el-col :span="2" :offset="2">杰哥的自习室</el-col>
        <el-col :span="1" :offset="2">
          <el-icon style="margin-top: 5px"><star /></el-icon>
        </el-col>
        <el-col :span="2">54</el-col>
      </el-row>
<!-- 静态随便写，动态用v-for -->
      <el-card style="margin-top: 20px; margin-left: 20px; margin-right: 20px">
        
        <h1>描述</h1>
        <div>给你看点好康的</div>
        <h1>
          地点
          <el-icon style="margin-top: 10px;"><position /></el-icon>
        </h1>
        <div>安楼后的小树林</div>
      </el-card>
    </el-col>
    <el-col :span="6"> 
        <h1> 花园榜单</h1>
    </el-col>
  </el-row>
</template>
  
  
  <style scoped>
.logo {
  border-radius: 50%;
  width: 50px;
}

.logo-text {
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
  
  