<template>
  <div class="container" style="margin-top: 60px">

    <!-- 导航栏 -->
    <NavBar />

    <el-row>
      <!-- 侧边栏 -->
      <SideBar/>
      
      <!-- 走马灯的主页图片 -->
      <el-col :span="21">
        <el-carousel
          :interval="4000"
          type="card"
          height="300px"
          indicator-position="outside"
        >
          <el-carousel-item v-for="item in mainPageDem" :key="item">
            <img :src="item.src" style="max-width: 120%" />
          </el-carousel-item>
        </el-carousel>
      </el-col>
    </el-row>

    <!-- 八个矩形 快速导航-->

    <div class="navigator">
      <!-- 第一行 -->
      <el-row>
        <el-col :offset="2" :span="5">
          <el-card
            shadow="hover"
            body-style="height:100px"
            style="background-color: rgb(194, 241, 194)"
            @click="this.$router.push('/display/')"
          >
            <div class="navigator-card" style="text-align: center">
              <el-icon><video-camera></video-camera></el-icon>
              <el-text>花园展厅</el-text>
            </div>
          </el-card>
        </el-col>
        <el-col :span="5">
          <el-card
            shadow="hover"
            body-style="height:100px"
            @click="this.$router.push('/garden/')"
          >
            <div class="navigator-card" style="text-align: center">
              <el-icon><video-camera></video-camera></el-icon>
              <el-text>我的花园</el-text>
            </div>
          </el-card>
        </el-col>
        <el-col :span="5">
          <el-card
            shadow="hover"
            body-style="height:100px"
            style="background-color: rgb(194, 241, 194)"
            @click="this.$router.push('/BlogView/')"
          >
            <div class="navigator-card" style="text-align: center">
              <el-icon><video-camera></video-camera></el-icon>
              <el-text>博客论坛</el-text>
            </div>
          </el-card>
        </el-col>
        <el-col :span="5">
          <el-card
            shadow="hover"
            body-style="height:100px"
            @click="this.$router.push('/404/')"
          >
            <div class="navigator-card" style="text-align: center">
              <el-icon><video-camera></video-camera></el-icon>
              <el-text>当前热榜</el-text>
            </div>
          </el-card>
        </el-col>
      </el-row>
      <!-- 第二行 -->
      <el-row>
        <el-col :offset="2" :span="5">
            <el-card
              shadow="hover"
              body-style="height:100px"
              @click="this.$router.push('/404/')"
            >
              <div class="navigator-card" style="text-align: center">
                <el-icon><video-camera></video-camera></el-icon>
                <el-text>统计数据</el-text>
              </div>
            </el-card>
        </el-col>
        <el-col :span="5">
          <el-card
              shadow="hover"
              body-style="height:100px"
              style="background-color: rgb(174, 243, 197)"
              @click="this.$router.push('/404/')"
            >
              <div class="navigator-card" style="text-align: center">
                <el-icon><video-camera></video-camera></el-icon>
                <el-text>志愿者招募</el-text>
              </div>
            </el-card>
        </el-col>
        <el-col :span="5">
          <el-card
              shadow="hover"
              body-style="height:100px"
              @click="this.$router.push('/404/')"
            >
              <div class="navigator-card" style="text-align: center">
                <el-icon><video-camera></video-camera></el-icon>
                <el-text>花园活动</el-text>
              </div>
            </el-card>
        </el-col>
        <el-col :span="5">
          <el-card
              shadow="hover"
              body-style="height:100px"
              style="background-color: rgb(174, 243, 197)"
              @click="this.$router.push('/404/')"
            >
              <div class="navigator-card" style="text-align: center">
                <el-icon><video-camera></video-camera></el-icon>
                <el-text>积分商城</el-text>
              </div>
            </el-card>
        </el-col>
      </el-row>
    </div>

    <!-- 详情展示-->
    <div class="item-block">
      <el-row v-for="i in 3" :key="i" :span="24">
        <el-col :span="6" v-for="o in 3" :key="o" :offset="o == 0 ? 3 : 1">
          <ItemBlock/>
        </el-col>
        <br />
      </el-row>
    </div>

    <div class="item"></div>

    <!--回到顶部-->
    <el-backtop :bottom="50" :right="50">
      <div
        style="
           {
            height: 100%;
            width: 100%;
            border-radius: 50%;
            font-size: 13px;
            background-color: #f2f5f6;
            box-shadow: 0 0 6px rgba(0, 0, 0, 0.12);
            text-align: center;
            line-height: 20px;
            color: #1989fa;
            padding: 20px;
          }
        "
      >
        返回顶部
      </div>
    </el-backtop>
  </div>
</template>

<style scoped>
.logo {
  border-radius: 50%;
  width: 50px;
}

.logo-text {
  margin-top: 10px;
}
.time {
  font-size: 13px;
  color: #999;
}

.bottom {
  margin-top: 13px;
  line-height: 12px;
}

.button {
  padding: 0;
  float: right;
}

.image {
  width: 20%;
  display: flex;
}

.clearfix:before,
.clearfix:after {
  display: table;
  content: "";
}

.clearfix:after {
  clear: both;
}

.side-bar {
  position: fixed; /* 将 div 固定在屏幕上 */
  top: 0; /* 设置距离屏幕顶部的距离为 0，使其始终在屏幕最顶部 */
  left: 0; /* 设置距离屏幕左侧的距离为 0，使其始终在屏幕最左侧 */
  height: 100%; /* 占据整个屏幕的高度 */
  width: 200px; /* 设置 div 的宽度 */
  background-color: #f0f0f0; /* 设置背景颜色，这里仅作示例 */
  /* 这里可以添加其他样式，比如边框、内边距、内容等 */
}
</style>

<script>
export default {
  name: "HomePageView",
  data() {
    return {
      searchHistory: [
        "111",
        "222",
        "333",
        "444",
        "555",
        "666",
        "777",
        "888",
        "999",
        "000",
      ],
      hotsListFlag: true,
      focusFlag: false,

      UserInfo: { name: "未登录", accountId: "#", type: "#" },
      mainPageDem: [
        { description: "", src: require("../assets/logo.png") },
        { description: "", src: require("../assets/mainpage.jpeg") },
        { description: "", src: require("../assets/mainpage.jpeg") },
        { description: "", src: require("../assets/mainpage.jpeg") },
      ],
      avatarUrl:
        "https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png",
      searchData: "",
      currentDate: new Date(),
      blockData: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
      len: 10,
    };
  },
  methods: {},
  computed: {},
};
</script>

