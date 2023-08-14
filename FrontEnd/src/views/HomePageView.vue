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

          <!-- 博客详情展示-->
          <div class="blog-field">

            <!-- 两列布局 -->
            <div class="row row-cols-2">
              <div class="col" v-for="(blog, index) in blogs" :key="index">

                <!-- 博客卡片 -->
                <div class="card item-card">
                  <BlogBlock :card="blog" />
                </div>

              </div>
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

      blogs: [
        {
          author: "作者1",
          avatar: require("../assets/author-avatar.jpg"),
          blogName: "博客名称1",
          partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
          fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
          showFullContent: false,
          isOpen: false,
          comments: [
            { user: "User1", content: "Comment 1" },
            { user: "User2", content: "Comment 2" },
            // Add more comments here
          ],
          liked: false, // 是否已点赞
          totalLikes: 114, // 总点赞次数
          showInput: false,
          comment: "",
        },
        {
          author: "作者2",
          avatar: require("../assets/author-avatar.jpg"),
          blogName: "博客名称2",
          partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
          fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
          showFullContent: false,
          isOpen: false,
          comments: [
            { user: "User3", content: "Comment 3" },
            { user: "User4", content: "Comment 4" },
            // Add more comments here
          ],
          liked: false, // 是否已点赞
          totalLikes: 514, // 总点赞次数
          showInput: false,
          comment: "",
        },
        {
          author: "作者3",
          avatar: require("../assets/author-avatar.jpg"),
          blogName: "博客名称3",
          partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
          fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
          showFullContent: false,
          isOpen: false,
          comments: [
            { user: "User5", content: "Comment 5" },
            { user: "User6", content: "Comment 6" },
            // Add more comments here
          ],
          liked: false, // 是否已点赞
          totalLikes: 19, // 总点赞次数
          showInput: false,
          comment: "",
        },
        {
          author: "作者4",
          avatar: require("../assets/author-avatar.jpg"),
          blogName: "博客名称4",
          partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
          fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
          showFullContent: false,
          isOpen: false,
          comments: [
            { user: "User7", content: "Comment 7" },
            { user: "User8", content: "Comment 8" },
            // Add more comments here
          ],
          liked: false, // 是否已点赞
          totalLikes: 19, // 总点赞次数
          showInput: false,
          comment: "",
        },
        {
          author: "作者5",
          avatar: require("../assets/author-avatar.jpg"),
          blogName: "博客名称5",
          partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
          fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
          showFullContent: false,
          isOpen: false,
          comments: [
            { user: "User9", content: "Comment 9" },
            { user: "User10", content: "Comment 10" },
            // Add more comments here
          ],
          liked: false, // 是否已点赞
          totalLikes: 810, // 总点赞次数
          showInput: false,
          comment: "",
        },
        // 添加更多卡片...
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

