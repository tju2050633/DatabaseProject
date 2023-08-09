<template>
  <body class="maingardendis">
    <div class="container" style="margin-top: 60px">
      <!-- 导航栏 -->
      <NavBar />

      <el-row id="mainpart">
        <!-- 侧边栏 -->
        <SideBar />
        <!-- 主体 -->
        <el-col :span="13">
          <el-container>
            <!-- 标签栏 -->
            <el-header>
              <el-menu
                :default-active="activeTab"
                mode="horizontal"
                @select="handleMenuSelect"
                class="menuheader"
              >
                <el-menu-item index="hot" class="infohead">热门</el-menu-item>
                <el-menu-item index="new" class="infohead">最新</el-menu-item>
                <el-menu-item index="mine" class="infohead">我的</el-menu-item>
              </el-menu>
            </el-header>

            <!-- 图片展示区域 -->
            <el-main>
              <!-- hot -->
              <div v-if="activeTab === 'hot'">
                <!--这里实际项目中应该为数据库读取并展示-->
                <el-card
                  v-for="(image, index) in hotImages"
                  :key="index"
                  @click="this.$router.push('/garden/')"
                  class="garden-card"
                >
                  <GardenBlock :image="image" />
                </el-card>
              </div>

              <!-- new -->
              <div v-else-if="activeTab === 'new'">
                <el-card
                  v-for="(image, index) in newImages"
                  :key="index"
                  @click="this.$router.push('/garden/')"
                  class="garden-card"
                >
                  <GardenBlock :image="image" />
                </el-card>
              </div>

              <!-- 我的 -->
              <div v-else-if="activeTab === 'mine'">我的图片展示</div>
            </el-main>
          </el-container>
        </el-col>

        <!-- 花园排行榜 -->
        <el-col :span="8">
          <el-container>
            <br />
            <i class="el-icon-star-on"></i>
            <el-header class="infohead">花园排行榜</el-header>
            <el-main>
              <el-row :gutter="20">
                <el-col
                  :span="9"
                  v-for="(item, index) in displayedImageList"
                  :key="index"
                >
                  <el-card
                    class="garden-rank"
                    @click="this.$router.push('/garden/')"
                  >
                    <!-- 图片展示区域 -->
                    <img :src="item.imageUrl" alt="花园" style="width: 100%" />
                    <!-- 图片描述 -->
                    <div style="text-align: center" class="garden-info">
                      {{ item.description }}
                    </div>
                  </el-card>
                </el-col>
              </el-row>
              <br />
              <el-button
                @click="toggleShowMore"
                style="margin-top: 10px"
                class="showMorebutton"
                >{{ showMore ? "收起" : "显示更多" }}</el-button
              >
            </el-main>
          </el-container>
        </el-col>
      </el-row>
    </div>
  </body>
</template>

<style scoped>
@import url("../css/gardenDisplay.css");
</style>

<script>
export default {
  el: "#mainpart",
  data() {
    return {
      activeTab: "hot", // 默认选中热门板块
      showMore: false, // 控制是否显示更多图片
      displayedImageList: [], // 实际显示的图片列表
      maxDisplayCount: 4, // 默认显示的图片数量
      imageList: [
        {
          imageUrl: require("../assets/example.png"),
          description: "TOP1 Garden",
        },
        {
          imageUrl: require("../assets/example.png"),
          description: "TOP2 Garden",
        },
        {
          imageUrl: require("../assets/example.png"),
          description: "TOP3 Garden",
        },
        {
          imageUrl: require("../assets/example.png"),
          description: "TOP4 Garden",
        },
        {
          imageUrl: require("../assets/example.png"),
          description: "TOP5 Garden",
        },
        {
          imageUrl: require("../assets/example.png"),
          description: "TOP6 Garden",
        },
        {
          imageUrl: require("../assets/example.png"),
          description: "TOP7 Garden",
        },
        {
          imageUrl: require("../assets/example.png"),
          description: "TOP8 Garden",
        },
        {
          imageUrl: require("../assets/example.png"),
          description: "TOP9 Garden",
        },
        {
          imageUrl: require("../assets/example.png"),
          description: "TOP10 Garden",
        },
      ],
      hotImages: [
        {
          imageUrl: require("../assets/Garden-e.jpg"),
          username: "Student1",
          gardenname: "Garden1",
          hot: "90",
        },
        {
          imageUrl: require("../assets/Garden-e.jpg"),
          username: "Student2",
          gardenname: "Garden2",
          hot: "80",
        },
        {
          imageUrl: require("../assets/Garden-e.jpg"),
          username: "Student3",
          gardenname: "Garden3",
          hot: "70",
        },
        {
          imageUrl: require("../assets/Garden-e.jpg"),
          username: "Student4",
          gardenname: "Garden4",
          hot: "60",
        },
        {
          imageUrl: require("../assets/Garden-e.jpg"),
          username: "Student5",
          gardenname: "Garden5",
          hot: "50",
        },
      ],
      newImages: [
        {
          imageUrl: require("../assets/Garden.jpg"),
          username: "Student6",
          gardenname: "Garden6",
          hot: "10",
        },
        {
          imageUrl: require("../assets/Garden.jpg"),
          username: "Student7",
          gardenname: "Garden7",
          hot: "12",
        },
        {
          imageUrl: require("../assets/Garden.jpg"),
          username: "Student8",
          gardenname: "Garden8",
          hot: "14",
        },
        {
          imageUrl: require("../assets/Garden.jpg"),
          username: "Student9",
          gardenname: "Garden9",
          hot: "16",
        },
        {
          imageUrl: require("../assets/Garden.jpg"),
          username: "Student10",
          gardenname: "Garden10",
          hot: "18",
        },
      ],
    };
  },
  methods: {
    handleMenuSelect(index) {
      this.activeTab = index;
    },
    toggleShowMore() {
      this.showMore = !this.showMore;
      this.updateDisplayedImages();
    },
    updateDisplayedImages() {
      if (this.showMore) {
        this.displayedImageList = this.imageList; // 显示全部图片
      } else {
        this.displayedImageList = this.imageList.slice(0, this.maxDisplayCount); // 仅显示前maxDisplayCount张图片
      }
    },
  },
  created() {
    this.updateDisplayedImages(); // 初始化时根据showMore状态设置图片数量
  },
};
</script>