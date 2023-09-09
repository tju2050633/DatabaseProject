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
              <el-carousel-item v-for="item in mainPageDem" :key="item" @click="this.$router.push({ name: item.target})">
                <img :src="item.src" style="max-width: 100%" />
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
                      d="M8 0a2 2 0 0 0-2 2c0 .552.224 1.052.586 1.414l-.002.002 2.828 2.828a2 2 0 1 0 2.828-2.828l2.828-2.828.002-.002A2 2 0 0 0 14 2a2 2 0 0 0-2-2zm0 3a1 1 0 1 1 0-2 1 1 0 0 1 0 2zm-2.586 2.414a1 1 0 0 1 0-1.414L2.172 2.172a1 1 0 1 1 1.414-1.414l2.828 2.828a1 1 0 0 1 0 1.414l-2.828 2.828a1 1 0 1 1-1.414-1.414l1.414-1.414zm5.172 0a1 1 0 0 1 0-1.414l1.414-1.414a1 1 0 1 1 1.414 1.414l-1.414 1.414a1 1 0 0 1-1.414 0z" />
                    </svg>
                    <el-text>花园展厅</el-text>
                  </div>

                </el-card>
              </div>

              <div class="col nav-col">
                <el-card class="navigator-item" @click="navigateToMyGarden">

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
                      <path d="M14 0H2C.9 0 0 .9 0 2v12c0 1.1.9 2 2 2h12c1.1 0 2-.9 2-2V2c0-1.1-.9-2-2-2zM3 12v-1h8v1H3zm0-3v-1h8v1H3zm0-3V5h8v1H3zm9 6H2V2h12v10z"/>
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
                      <path d="M7.5 2.5a.5.5 0 0 1 .5.5v3.793l1.854-1.853a.5.5 0 0 1 .707.707l-2.5 2.5a.5.5 0 0 1-.707 0l-2.5-2.5a.5.5 0 0 1 .707-.707L7 6.293V2a.5.5 0 0 1 .5-.5zm3.5 0a.5.5 0 0 1 .5.5v6.207l1.854-1.853a.5.5 0 0 1 .707.707l-2.5 2.5a.5.5 0 0 1-.707 0l-2.5-2.5a.5.5 0 0 1 .707-.707L11 9.707V3a.5.5 0 0 1 .5-.5z"/>                    </svg>
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
                      <path d="M12 1v14H4V1h8m0-1H4C2.9 0 2 .9 2 2v14c0 1.1.9 2 2 2h8c1.1 0 2-.9 2-2V2c0-1.1-.9-2-2-2zM6 14H4V6h2v8zm3 0H7V9h2v5zm3 0h-2V4h2v10z"/>                    </svg>
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
                      <path d="M12.5 0h-9C2.57 0 2 .57 2 1.5v13c0 .93.57 1.5 1.5 1.5h9c.93 0 1.5-.57 1.5-1.5v-13c0-.93-.57-1.5-1.5-1.5zM7 13.5c-1.93 0-3.5-1.57-3.5-3.5S5.07 6.5 7 6.5s3.5 1.57 3.5 3.5-1.57 3.5-3.5 3.5zm4-6.5h-2V5h2v2z"/>                    </svg>
                    <el-text>志愿者招募</el-text>
                  </div>

                </el-card>
              </div>

              <div class="col nav-col">
                <el-card class="navigator-item" @click="this.$router.push('/GardenActivities/')">

                  <div class="navigator-card">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" fill="currentColor" class="bi bi-cursor"
                      viewBox="0 0 16 16">
                      <path d="M14 2H2c-.55 0-1 .45-1 1v10c0 .55.45 1 1 1h12c.55 0 1-.45 1-1V3c0-.55-.45-1-1-1zM3 4h10v2H3V4zm0 4h10v2H3V8zm0 4h10v2H3v-2z"/>                    </svg>
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
                      <path d="M14 3H2c-.55 0-1 .45-1 1v1h14V4c0-.55-.45-1-1-1zM3 6h10v2H3V6zm-1 4h12v6c0 .55-.45 1-1 1H2c-.55 0-1-.45-1-1v-6h1zm1 1v4h10v-4H3z"/>                    </svg>
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
              <div class="col" v-for="(image, index) in hotImages" :key="index" 
                @click="this.$router.push({name: 'garden', params: { garden_id: image.gardenId }})">

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

  width: 12vw;

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
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
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
import { reactive} from "vue";
import { getGardenList } from "../api/gardenDisplayAPI.js";
import { getGardenIdByUserId } from "../api/gardenAPI.js";
import { getUserNameById } from '@/api/accountApi';
import { useStore } from 'vuex';

export default {
  name: "HomePageView",

  async created() {
    this.user_id = this.store.state.user.id;
    if(this.user_id == "")
      this.garden_id = "";
    else
      this.garden_id = await getGardenIdByUserId(this.user_id);

    this.initHotGardens();
  },

  methods: {
    navigateToMyGarden() {
      if (this.user_id == "")
        alert("请先登录！");
      else if (this.garden_id == "")
        alert("您还没有花园！");
      else
        this.$router.push({ name: "garden", params: { garden_id: this.garden_id } });
    },

    async initHotGardens() {
      const hotGardens = await getGardenList();

      for (let i = 0; i < 4; i++)
      {
        const username = await getUserNameById(hotGardens[i].ownerId);
        this.hotImages.push({
          gardenId: hotGardens[i].gardenId,
          imageUrl: hotGardens[i].pictures,
          username: username,
          gardenname: hotGardens[i].name,
          hot: hotGardens[i].stars
        })
      }
    },

    async loadMoreGardens() {
      const hotGardens = await getGardenList();
      let n = this.hotImages.length;
      for (let j = n; j < n + 4 && j < hotGardens.length; j++) {
        const username = await getUserNameById(hotGardens[j].ownerId);
        this.hotImages.push({
          gardenId: hotGardens[j].gardenId,
          imageUrl: hotGardens[j].pictures,
          username: username,
          gardenname: hotGardens[j].name,
          hot: hotGardens[j].stars
        })
      }
    }
  },
  
  setup() {
    const store = useStore();

    const mainPageDem = reactive([
      { description: "", src: require("../assets/mainpage1.jpeg"), target:"display" },
      { description: "", src: require("../assets/mainpage2.jpeg"), target:"BlogView" },
      { description: "", src: require("../assets/mainpage3.jpeg"), target: "PointMall" },
    ]);

    const hotImages = reactive([ ]);

    return {
      store,
      mainPageDem,
      hotImages,
    };
  },
};
</script>

