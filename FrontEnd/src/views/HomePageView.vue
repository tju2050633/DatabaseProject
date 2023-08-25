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
                <el-card class="navigator-item" @click="this.$router.push('/CurrentHotList/')">

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

          <div class="colored-line"></div> <!-- 分隔线 -->

          <!-- 花园详情展示-->
          <div class="garden-field">

            <!-- 两列布局 -->
            <div class="row row-cols-2">
              <div class="col" v-for="(image, index) in hotImages" :key="index" @click="this.$router.push('/garden/')">

                <!-- 花园卡片 -->
                <div class="card item-card">
                  <GardenBlock :image="image" />
                </div>

              </div>
            </div>

          </div>

          <!-- 加载更多 -->
          <div>
            <button class="btn btn-outline-success show-more-btn" @click="loadMoreGardens">加载更多</button>
          </div>

        </div>
      </div>

      <!--回到顶部-->
      <el-backtop :bottom="70" :right="60">
        <div class="back-to-top">
          <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-up-circle"
            viewBox="0 0 16 16">
            <path fill-rule="evenodd"
              d="M1 8a7 7 0 1 0 14 0A7 7 0 0 0 1 8zm15 0A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-7.5 3.5a.5.5 0 0 1-1 0V5.707L5.354 7.854a.5.5 0 1 1-.708-.708l3-3a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1-.708.708L8.5 5.707V11.5z" />
          </svg>
          返回顶部
        </div>
      </el-backtop>

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

.colored-line {
  height: 2px;
  background-color: rgb(12, 60, 38);
  margin-top: 3vh;
  margin-bottom: 3vh;
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

.row-cols-2 {
  margin-top: 3vh;
  margin-bottom: 3vh;
}

.item-card {
  padding: 1vh;

  border-width: 0vh;
  border-radius: 2vh;

  box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
  background-color: rgb(246, 243, 239);

  margin-top: 3vh;
  margin-bottom: 3vh;

  cursor: pointer;
}

.item-card:hover {
  transform: scale(1.05);
  transition: 300ms;
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

.show-more-btn {
  margin: 2vh auto 10vh 0vh;
}
</style>

<script>
import { reactive, ref, onMounted } from "vue";
import API from "@/api/basicApi.js";

export default {
  name: "HomePageView",
  setup() {
    const mainPageDem = reactive([
      { description: "", src: require("../assets/logo.png") },
      { description: "", src: require("../assets/mainpage.jpeg") },
      { description: "", src: require("../assets/mainpage.jpeg") },
      { description: "", src: require("../assets/mainpage.jpeg") },
    ]);

    const hotImages = reactive([
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
    ]);

    //定义花园读取要用的变量
    const state = reactive({
      currentPage: 1, //当前的花园页面，用于花园分页与无限刷新
      gardens: [], //花园列表
      pageSize: 10, //花园分页大小
    });

    //错误信息
    let errMessage = ref("");

    // 执行一些初始化逻辑
    onMounted(() => {
      // this.loadBlogs();测试已有接口不掉用该函数
      loadGardenUsingId();
    });

    //跳转到花园页面时获取初始的花园数据
    const loadGardens = () => {
      console.log("开始花园读取");
      API({
        url: "/Garden/",
        method: "get",
        params: {
          page: state.currentPage,
          pagesize: state.pageSize,
        },
      }).then(
        function (res) {
          console.log("获取成功");
          state.gardens = res.data;
        },
        function (err) {
          console.log("获取失败");
          errMessage.value = err.data;
        }
      );
    };

    //加载更多的花园数据
    const loadMoreGardens = () => {
      console.log("开始花园读取");
      API({
        url: "/Garden/",
        method: "get",
        params: {
          page: state.currentPage,
          pagesize: state.pageSize,
        },
      }).then(
        function (res) {
          console.log("获取更多成功");
          state.currentPage++;
          state.gardens.push(res.data);
        },
        function (err) {
          console.log("获取更多失败");
          errMessage.value = err.data;
        }
      );
    };

    //下面用于测试已有的接口
    //将后端返回的数据格式改为前端使用的cards
    const toCard = (garden) => {
      console.log(garden.content);
      var card = {
        imageUrl: require("../assets/Garden-e.jpg"), //后端数据库没有
        username: garden.username,
        gardenname: garden.gardenname,
        hot: garden.hot,
      };
      return card;
    };

    const loadGardenUsingId = () => {
      console.log("开始花园读取测试");
      API({
        url: "/Garden/",
        method: "get",
        params: {
          id: 2, //测试数据写死
        },
      }).then(
        function (res) {
          console.log("测试成功");
          //测试获得的内容
          console.log(res.data);
          state.gardens.push(res.data);
          hotImages.push(toCard(res.data));
        },
        function (err) {
          console.log("测试失败");
          errMessage.value = err.data;
        }
      );
    };

    return {
      mainPageDem,
      hotImages,
      state,
      errMessage,
      loadGardens,
      loadMoreGardens,
      toCard,
      loadGardenUsingId,
    };
  },
};
</script>

