<template>
    <div class="container" style="margin-top: 60px;">
      <nav-bar></nav-bar>
      <el-row>
        <side-bar></side-bar>

        <el-col :span="16" :offset="1">
          <el-container>
            <!-- 标签栏 -->
            <el-header>
                <el-menu :default-active="activeTab" mode="horizontal" @select="menuSelection">
                    <el-menu-item index="user">平台用户数据</el-menu-item>
                    <el-menu-item index="grade">用户年级分布</el-menu-item>
                    <el-menu-item index="garden">花园发布数据</el-menu-item>
                    <el-menu-item index="blog">博客发布数据</el-menu-item>
                </el-menu>


                <div v-if="activeTab === 'user'">
                  <!--这里实际项目中应该为数据库读取并展示-->
                  <el-card>
                    <active-users></active-users>
                  </el-card>
                </div>

                <div v-if="activeTab === 'grade'">
                  <!--这里实际项目中应该为数据库读取并展示-->
                  <el-card>
                    <grade-distribution></grade-distribution>
                  </el-card>
                </div>

                <div v-if="activeTab === 'garden'">
                  <!--这里实际项目中应该为数据库读取并展示-->
                  <el-card>
                    <garden-distribution></garden-distribution>
                  </el-card>
                </div>

                <div v-if="activeTab === 'blog'">
                  <!--这里实际项目中应该为数据库读取并展示-->
                  <el-card>
                    <blog-distribution></blog-distribution>
                  </el-card>
                </div>

            </el-header>
          

          </el-container>
        </el-col>


      </el-row>
    </div>

</template>

<script>
export default {
  name: "DataVisualization",
  data() {
    return {
      activeTab:1,
    }
  },
  methods: {
    menuSelection(index){
      this.activeTab = index;
    }
  },
  computed: {},
};

</script>


<style scoped>
</style>