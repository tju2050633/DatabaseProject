<template>
  <body>
    <div class="container">
      <NavBar /> <!-- 导航栏 -->

      <div class="row" style="width: 100%;">

        <!-- 侧边栏 -->
        <div class="col-2">
          <SideBar />
        </div>

        <!-- 主体内容 -->
        <div class="col-10">

          <!-- 走马灯的主页图片 -->
          <div class="images-field">
            <el-carousel :interval="4000" type="card" height="250px" indicator-position="outside">
              <el-carousel-item v-for="item in mainPageDem" :key="item">
                <img :src="item.src" style="max-width: 120%" />
              </el-carousel-item>
            </el-carousel>
          </div>

          <!-- 八个矩形 快速导航-->
          <div class="navigator-field">
            <!-- 第一行 -->
            <div class="row">

              <div class="col nav-col">
                <el-card class="navigator-item" style="background-color: rgb(194, 241, 194)"
                  @click="this.$router.push('/display/')">

                  <div class="navigator-card">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" fill="currentColor" class="bi bi-cursor"
                      viewBox="0 0 16 16">
                      <path
                        d="M14.082 2.182a.5.5 0 0 1 .103.557L8.528 15.467a.5.5 0 0 1-.917-.007L5.57 10.694.803 8.652a.5.5 0 0 1-.006-.916l12.728-5.657a.5.5 0 0 1 .556.103zM2.25 8.184l3.897 1.67a.5.5 0 0 1 .262.263l1.67 3.897L12.743 3.52 2.25 8.184z" />
                    </svg>
                    <el-text>花园展厅</el-text>
                  </div>

                </el-card>
              </div>

              <div class="col nav-col">
                <el-card class="navigator-item" @click="this.$router.push('/garden/')">

                  <div class="navigator-card">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" fill="currentColor" class="bi bi-cursor"
                      viewBox="0 0 16 16">
                      <path
                        d="M14.082 2.182a.5.5 0 0 1 .103.557L8.528 15.467a.5.5 0 0 1-.917-.007L5.57 10.694.803 8.652a.5.5 0 0 1-.006-.916l12.728-5.657a.5.5 0 0 1 .556.103zM2.25 8.184l3.897 1.67a.5.5 0 0 1 .262.263l1.67 3.897L12.743 3.52 2.25 8.184z" />
                    </svg>
                    <el-text>我的花园</el-text>
                  </div>

                </el-card>
              </div>

              <div class="col nav-col">
                <el-card class="navigator-item" style="background-color: rgb(194, 241, 194)"
                  @click="this.$router.push('/BlogView/')">

                  <div class="navigator-card">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" fill="currentColor" class="bi bi-cursor"
                      viewBox="0 0 16 16">
                      <path
                        d="M14.082 2.182a.5.5 0 0 1 .103.557L8.528 15.467a.5.5 0 0 1-.917-.007L5.57 10.694.803 8.652a.5.5 0 0 1-.006-.916l12.728-5.657a.5.5 0 0 1 .556.103zM2.25 8.184l3.897 1.67a.5.5 0 0 1 .262.263l1.67 3.897L12.743 3.52 2.25 8.184z" />
                    </svg>
                    <el-text>博客论坛</el-text>
                  </div>

                </el-card>
              </div>

              <div class="col nav-col">
                <el-card class="navigator-item" @click="this.$router.push('/404/')">

                  <div class="navigator-card">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" fill="currentColor" class="bi bi-cursor"
                      viewBox="0 0 16 16">
                      <path
                        d="M14.082 2.182a.5.5 0 0 1 .103.557L8.528 15.467a.5.5 0 0 1-.917-.007L5.57 10.694.803 8.652a.5.5 0 0 1-.006-.916l12.728-5.657a.5.5 0 0 1 .556.103zM2.25 8.184l3.897 1.67a.5.5 0 0 1 .262.263l1.67 3.897L12.743 3.52 2.25 8.184z" />
                    </svg>
                    <el-text>当前热榜</el-text>
                  </div>

                </el-card>
              </div>

              <div class="col nav-col"></div>

            </div>
            <!-- 第二行 -->
            <div class="row">

              <div class="col nav-col">
                <el-card class="navigator-item" @click="this.$router.push('/DataVisualization/')">

                  <div class="navigator-card">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" fill="currentColor" class="bi bi-cursor"
                      viewBox="0 0 16 16">
                      <path
                        d="M14.082 2.182a.5.5 0 0 1 .103.557L8.528 15.467a.5.5 0 0 1-.917-.007L5.57 10.694.803 8.652a.5.5 0 0 1-.006-.916l12.728-5.657a.5.5 0 0 1 .556.103zM2.25 8.184l3.897 1.67a.5.5 0 0 1 .262.263l1.67 3.897L12.743 3.52 2.25 8.184z" />
                    </svg>
                    <el-text>统计数据</el-text>
                  </div>

                </el-card>
              </div>

              <div class="col nav-col">
                <el-card class="navigator-item" style="background-color: rgb(174, 243, 197)"
                  @click="this.$router.push('/VolunteerRecruitment/')">

                  <div class="navigator-card">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" fill="currentColor" class="bi bi-cursor"
                      viewBox="0 0 16 16">
                      <path
                        d="M14.082 2.182a.5.5 0 0 1 .103.557L8.528 15.467a.5.5 0 0 1-.917-.007L5.57 10.694.803 8.652a.5.5 0 0 1-.006-.916l12.728-5.657a.5.5 0 0 1 .556.103zM2.25 8.184l3.897 1.67a.5.5 0 0 1 .262.263l1.67 3.897L12.743 3.52 2.25 8.184z" />
                    </svg>
                    <el-text>志愿者招募</el-text>
                  </div>

                </el-card>
              </div>

              <div class="col nav-col">
                <el-card class="navigator-item" @click="this.$router.push('/GardenActivities/')">

                  <div class="navigator-card">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" fill="currentColor" class="bi bi-cursor"
                      viewBox="0 0 16 16">
                      <path
                        d="M14.082 2.182a.5.5 0 0 1 .103.557L8.528 15.467a.5.5 0 0 1-.917-.007L5.57 10.694.803 8.652a.5.5 0 0 1-.006-.916l12.728-5.657a.5.5 0 0 1 .556.103zM2.25 8.184l3.897 1.67a.5.5 0 0 1 .262.263l1.67 3.897L12.743 3.52 2.25 8.184z" />
                    </svg>
                    <el-text>花园活动</el-text>
                  </div>

                </el-card>
              </div>

              <div class="col nav-col">
                <el-card class="navigator-item" style="background-color: rgb(174, 243, 197)"
                  @click="this.$router.push('/PointMall/')">

                  <div class="navigator-card">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" fill="currentColor" class="bi bi-cursor"
                      viewBox="0 0 16 16">
                      <path
                        d="M14.082 2.182a.5.5 0 0 1 .103.557L8.528 15.467a.5.5 0 0 1-.917-.007L5.57 10.694.803 8.652a.5.5 0 0 1-.006-.916l12.728-5.657a.5.5 0 0 1 .556.103zM2.25 8.184l3.897 1.67a.5.5 0 0 1 .262.263l1.67 3.897L12.743 3.52 2.25 8.184z" />
                    </svg>
                    <el-text>积分商城</el-text>
                  </div>

                </el-card>
              </div>

              <div class="col nav-col"></div>

            </div>
          </div>

          <!-- 详情展示-->
          <div class="item-field">
            <div class="row" v-for="i in 3" :key="i">
              <div class="col item-col" v-for="o in 3" :key="o">
                <ItemBlock />
              </div>
            </div>
          </div>

          <!--回到顶部-->
          <el-backtop :bottom="70" :right="60">
            <div class="back-to-top">
              <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                class="bi bi-arrow-up-circle" viewBox="0 0 16 16">
                <path fill-rule="evenodd"
                  d="M1 8a7 7 0 1 0 14 0A7 7 0 0 0 1 8zm15 0A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-7.5 3.5a.5.5 0 0 1-1 0V5.707L5.354 7.854a.5.5 0 1 1-.708-.708l3-3a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1-.708.708L8.5 5.707V11.5z" />
              </svg>
              返回顶部
            </div>
          </el-backtop>

        </div>

      </div>

    </div>
  </body>
</template>

<style scoped>
body {
  background-color: rgb(244, 237, 228);
}

.container {
  margin-top: 60px;
}

.images-field {
  margin-top: 3vh;
  margin-bottom: 3vh;

  padding: 2vh;

  border-width: 0vh;
  border-radius: 3vh;

  background-color: rgb(228, 220, 220);
  box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
}

.navigator-field {
  background-image: url("../assets/img-all-kinds-of-teams.png");
  background-size: 15vw;
  background-repeat: no-repeat;
  background-position: right center;
}

.nav-col {
  padding: 0vh;
  margin: 0vh;
}

.navigator-item {
  margin: 2vh;
  padding: 2vh;

  width: 11vw;

  border-width: 0vh;
  border-radius: 3vh;

  background-color: rgb(244, 237, 228);
  box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
}

.navigator-item:hover {
  cursor: pointer;
  transform: scale(1.2);
  transition: 1000ms;
}

.navigator-card {
  text-align: center;
  font-weight: bold;
  font-size: 5vh;
}

.item-col {
  margin: 0vh;
}

.back-to-top {
  height: 20vh;

  border-radius: 5vh;

  text-align: center;
  font-size: 2vh;
  color: rgb(12, 60, 38);

  background-color: rgb(239, 234, 227);
  box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);

  padding: 2vh;
}

/* .logo {
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
} */

.side-bar {
  position: fixed;
  /* 将 div 固定在屏幕上 */
  top: 0;
  /* 设置距离屏幕顶部的距离为 0，使其始终在屏幕最顶部 */
  left: 0;
  /* 设置距离屏幕左侧的距离为 0，使其始终在屏幕最左侧 */
  height: 100%;
  /* 占据整个屏幕的高度 */
  width: 200px;
  /* 设置 div 的宽度 */
  background-color: #f0f0f0;
  /* 设置背景颜色，这里仅作示例 */
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

