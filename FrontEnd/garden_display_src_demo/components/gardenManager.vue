<template>
  <el-row>
    <el-col :span="18">
      <el-row style="font-size: x-large">
        <el-col :span="1" :offset="4">
          <el-icon style="margin-top: 5px"><user /></el-icon>
        </el-col>
        <el-col :span="2">楚杰</el-col>
        <el-col :span="6" :offset="2">杰哥的自习室</el-col>
        <el-col :span="1" :offset="2">
          <el-icon style="margin-top: 5px"><star /></el-icon>
        </el-col>
        <el-col :span="2">54</el-col>
      </el-row>
      <el-card style="margin-top: 20px; margin-left: 20px; margin-right: 20px">
        <el-carousel indicator-position="outside">
          <el-carousel-item v-for="item in 4" :key="item">
            <h3 text="2xl" justify="center">{{ item }}</h3>
          </el-carousel-item>
        </el-carousel>
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
  
  