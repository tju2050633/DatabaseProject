<template>
  <body>

    <div class="container">
      <NavBar /> <!-- 导航栏 -->

      <el-row>
        <SideBar /> <!-- 侧边栏 -->

        <el-col :span="14" :offset="1">
          <br>
          <el-container>

            <!-- 标签栏 -->
            <el-header>
              <el-menu class="data-menu" :default-active="activeTab" mode="horizontal" @select="menuSelection">
                <el-menu-item index="user">平台用户数据</el-menu-item>
                <el-menu-item index="grade">用户年级分布</el-menu-item>
                <el-menu-item index="garden">花园发布数据</el-menu-item>
                <el-menu-item index="blog">博客发布数据</el-menu-item>
              </el-menu>


              <div class="data-card" v-if="activeTab === 'user'">
                <!--这里实际项目中应该为数据库读取并展示-->
                <active-users></active-users>
              </div>

              <div class="data-card" v-if="activeTab === 'grade'">
                <!--这里实际项目中应该为数据库读取并展示-->
                <grade-distribution></grade-distribution>
              </div>

              <div class="data-card" v-if="activeTab === 'garden'">
                <!--这里实际项目中应该为数据库读取并展示-->
                <garden-distribution></garden-distribution>
              </div>

              <div class="data-card" v-if="activeTab === 'blog'">
                <!--这里实际项目中应该为数据库读取并展示-->
                <blog-distribution></blog-distribution>
              </div>

            </el-header>

          </el-container>
        </el-col>

      </el-row>

    </div>

  </body>
</template>

<script>
export default {
  name: "DataVisualization",
  data() {
    return {
      activeTab: 1,
    }
  },
  methods: {
    menuSelection(index) {
      this.activeTab = index;
    }
  },
  computed: {},
};

</script>


<style scoped>
body {
  height: 95vh;
  background-color: rgb(244, 237, 228);
  background-image: url("../assets/img-datavisualization.jpg");
  background-size: auto;
  background-repeat: no-repeat;
  position: relative;
  background-position: right;
  background-attachment: fixed;
}

.container {
  margin-top: 60px;
}

.data-menu {
  padding: 1vh;

  border-width: 0vh;
  border-radius: 2vh;

  box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
  background-color: rgb(246, 243, 239);

  margin-bottom: 3vh;
}

.data-card {
  padding: 1vh;

  border-width: 0vh;
  border-radius: 2vh;

  box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
  background-color: rgb(246, 243, 239);

  margin-bottom: 3vh;
}
</style>