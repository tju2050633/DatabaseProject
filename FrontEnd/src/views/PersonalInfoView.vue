<template>
  <body class="infomainbody">
    <div class="container" style="margin-top: 60px">
      <!-- 导航栏 -->
      <NavBar />

      <div class="common-layout">
        <el-container class="personalinfo" style="height: 100vw">
          <el-container>
            <!-- 侧边栏 -->
            <SideBar />

            <!-- 主体 -->
            <el-container class="info">
              <el-main>
                <!-- 头图 -->
                <el-row class="top-image" body-style="heigh:700px ">
                  <el-col :span="24">
                    <el-image
                      style="width: 100vw; height: 30vh"
                      :src="url"
                      :fit="fill"
                    />
                  </el-col>
                </el-row>

                <!-- 头像+自述+修改信息按钮 -->
                <el-row :gutter="20">
                  <el-col :span="4">
                    <el-avatar :size="250" :src="avaUrl" />
                    <span class="spaninfohead" style="margin-left: 100px">{{
                      UserInfo.name
                    }}</span>
                  </el-col>

                  <el-col :span="16"
                    ><br /><br /><br /><br /><br />
                    <span class="spaninfohead" style="margin-left: 100px"
                      >个人描述：</span
                    >
                    <el-row style="margin-left: 100px">
                      <span v-if="!change" style="text-align: center">{{
                        UserInfo.description
                      }}</span>
                      <el-input
                        class="username-change"
                        style="font-size: large"
                        v-if="change"
                        v-model="UserInfo.description"
                        @change="InfoHasChanged()"
                    /></el-row>
                  </el-col>
                  <el-col :span="4"
                    ><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><el-button
                      type="info"
                      @click="changeInfo"
                      >修改信息</el-button
                    ></el-col
                  >
                </el-row>
                <br />

                <!-- 个人信息 -->
                <el-card
                  style="width=50vw; background-color: rgb(244, 237, 228)"
                >
                  <!-- 邮箱+注册时间 -->
                  <el-row :gutter="30">
                    <el-col :span="12"
                      ><span class="spaninfohead">邮箱：</span>
                      <el-row>
                        <span v-if="!change">{{ UserInfo.email }}</span>
                        <el-input
                          class="email-change"
                          v-if="change"
                          v-model="UserInfo.email"
                          @change="InfoHasChanged()"
                        />
                      </el-row>
                    </el-col>
                    <el-col :span="12"
                      ><span class="spaninfohead">注册时间：</span>
                      <el-row
                        ><span>{{ UserInfo.registerTime }}</span></el-row
                      >
                    </el-col>
                  </el-row>

                  <!-- 积分+手机号 -->
                  <el-row :gutter="30">
                    <el-col :span="12"
                      ><span class="spaninfohead">积分：</span>
                      <el-row
                        ><span>{{ UserInfo.points }}</span></el-row
                      >
                    </el-col>
                    <el-col :span="12">
                      <el-row>
                        <el-col :span="12"
                          ><el-button
                            type="info"
                            icon="Lock"
                            circle
                            size="medium"
                            @click="ifshowTel" /><span class="spaninfohead"
                            >手机号：</span
                          >
                          <el-row v-if="!change"
                            ><span v-if="showtel && !change">{{
                              UserInfo.tel
                            }}</span>
                            <span v-if="!showtel && !change">***</span></el-row
                          >
                          <el-input
                            class="tel-change"
                            v-if="change"
                            v-model="UserInfo.tel"
                            @change="InfoHasChanged()"
                        /></el-col>
                      </el-row>
                    </el-col>
                  </el-row>
                </el-card>

                <!-- 标签栏 -->

                <br /><br />

                <el-row :gutter="30">
                  <el-col :offset="0">
                    <el-breadcrumb separator="|">
                      <el-breadcrumb-item
                        :to="{}"
                        class="navtag"
                      ></el-breadcrumb-item>
                      <el-breadcrumb-item
                        :to="{}"
                        @click="refresh(1)"
                        :class="{ active: chooseComponent === 1 }"
                        class="navtag"
                        >互动</el-breadcrumb-item
                      >
                      <el-breadcrumb-item
                        :to="{}"
                        @click="refresh(2)"
                        :class="{ active: chooseComponent === 2 }"
                        class="navtag"
                        >博客</el-breadcrumb-item
                      >
                      <el-breadcrumb-item
                        :to="{}"
                        @click="refresh(3)"
                        :class="{ active: chooseComponent === 3 }"
                        class="navtag"
                        >花园</el-breadcrumb-item
                      >
                      <el-breadcrumb-item
                        :to="{}"
                        @click="refresh(4)"
                        :class="{ active: chooseComponent === 4 }"
                        class="navtag"
                        >工作记录</el-breadcrumb-item
                      >
                      <el-breadcrumb-item
                        :to="{}"
                        class="navtag"
                      ></el-breadcrumb-item>
                    </el-breadcrumb>
                  </el-col>
                </el-row>

                <!-- 功能页 -->
                <el-container class="functions">
                  <!-- 互动-->
                  <div
                    class="interact"
                    style="margin-left: 100px"
                    v-if="chooseComponent == 1"
                  >
                    <!-- 互动组件 -->
                    <el-card
                      v-for="(item, index) in GardenComment"
                      :key="index"
                      class="info-card"
                    >
                      <h2>
                        <img
                          class="author-avatar-img"
                          :src="item.avatar"
                          @click="this.$router.push('/personalInfo/')"
                          alt="作者头像"
                        />
                        <span
                          class="spaninfohead"
                          @click="this.$router.push('/personal/')"
                          >{{ item.author }}</span
                        >
                      </h2>
                      <h4>
                        <span
                          class="spaninfohead"
                          @click="this.$router.push('/personal/')"
                          >{{ item.title }}</span
                        >
                      </h4>
                      <div @click="this.$router.push('/personal/')">
                        <img :src="item.imageurl" alt="花园" class="card-img" />
                      </div>
                      <h4 style="padding-top: 20px">
                        <el-icon style="user: 10px"><User /></el-icon>
                        <span class="spaninfo"
                          >{{ UserInfo.name }}:{{ item.comment }}</span
                        >
                      </h4>
                    </el-card>
                    <br />

                    <el-card
                      v-for="(item, index) in GardenLike"
                      :key="index"
                      class="info-card"
                    >
                      <h4>
                        <span class="spaninfohead"
                          >Stars: {{ item.stars }}</span
                        >
                      </h4>
                      <h2>
                        <img
                          class="author-avatar-img"
                          :src="item.avatar"
                          @click="this.$router.push('/personalInfo/')"
                          alt="作者头像"
                        />
                        <span
                          class="spaninfohead"
                          @click="this.$router.push('/personal/')"
                          >{{ item.author }}</span
                        >
                      </h2>
                      <h4>
                        <span
                          class="spaninfohead"
                          @click="this.$router.push('/personal/')"
                          >{{ item.title }}</span
                        >
                      </h4>
                      <div @click="this.$router.push('/personal/')">
                        <img :src="item.imageurl" alt="花园" class="card-img" />
                      </div>
                    </el-card>
                    <br />

                    <el-card
                      v-for="(card, index) in BlogComment"
                      :key="index"
                      class="info-card"
                    >
                      <div class="spaninfohead">
                        <h1 class="spaninfohead">{{ card.blogName }}</h1>
                        <img
                          class="author-avatar-img"
                          :src="card.avatar"
                          @click="this.$router.push('/personalInfo/')"
                          alt="作者头像"
                        />
                        <h2
                          class="spaninfohead"
                          @click="this.$router.push('/personalInfo/')"
                        >
                          {{ card.author }}
                        </h2>
                      </div>
                      <div class="spaninfo">
                        <p v-if="!card.showFullContent">
                          {{ card.partialContent }}
                        </p>
                        <p v-else>
                          {{ card.fullContent }}
                        </p>
                        <button
                          class="read-more-button"
                          @click="toggleContentBlogCom(index)"
                        >
                          {{ card.showFullContent ? "收起" : "阅读全文" }}
                        </button>
                      </div>
                      <h3 class="spaninfohead">
                        <el-icon class="spaninfohead" style="star: 10px"
                          ><Star
                        /></el-icon>
                        {{ card.totalLikes }}
                        &ensp;&ensp;&ensp;
                        <el-icon class="spaninfohead" style="chat: 10px"
                          ><ChatLineSquare
                        /></el-icon>
                        {{ card.totalComment }}
                      </h3>
                      <h4 class="spaninfo">
                        <el-row>
                          <el-icon style="user: 10px"><User /></el-icon>
                          <span>{{ UserInfo.name }}:{{ card.comment }}</span>
                        </el-row>
                      </h4>
                    </el-card>
                    <br />

                    <el-card
                      v-for="(card, index) in BlogLike"
                      :key="index"
                      class="info-card"
                    >
                      <h4><span class="spaninfohead">点赞了博客</span></h4>
                      <div class="card-header">
                        <h1 class="spaninfohead">{{ card.blogName }}</h1>
                        <img
                          class="author-avatar-img"
                          :src="card.avatar"
                          @click="this.$router.push('/personalInfo/')"
                          alt="作者头像"
                        />
                        <h2
                          class="spaninfohead"
                          @click="this.$router.push('/personalInfo/')"
                        >
                          {{ card.author }}
                        </h2>
                      </div>
                      <div class="spaninfo">
                        <p v-if="!card.showFullContent">
                          {{ card.partialContent }}
                        </p>
                        <p v-else>
                          {{ card.fullContent }}
                        </p>
                        <button
                          class="read-more-button"
                          @click="toggleContentBlogLike(index)"
                        >
                          {{ card.showFullContent ? "收起" : "阅读全文" }}
                        </button>
                        <h3 class="spaninfohead">
                          <el-icon style="star: 10px"><Star /></el-icon>
                          {{ card.totalLikes }}
                          &ensp;&ensp;&ensp;
                          <el-icon style="chat: 10px"
                            ><ChatLineSquare
                          /></el-icon>
                          {{ card.totalComment }}
                        </h3>
                      </div>
                    </el-card>
                  </div>

                  <!-- 博客 -->
                  <div
                    class="blog"
                    style="margin-left: 100px"
                    v-if="chooseComponent == 2"
                  >
                    <br />
                    <el-card
                      v-for="(card, index) in BlogLike"
                      :key="index"
                      class="info-card"
                    >
                      <PersonalBlogBlock :card="card" />
                    </el-card>
                  </div>

                  <!-- 花园 -->
                  <div
                    class="garden"
                    style="margin-left: 100px"
                    v-if="chooseComponent == 3"
                  >
                    <br />
                    <el-card
                      v-for="(Garden, index) in Garden"
                      :key="index"
                      @click="
                        this.$router.push({
                          name: 'garden',
                          params: { garden_id: Garden.gardenId },
                        })
                      "
                      class="info-card"
                    >
                      <PersonalGardenBlock :Garden="Garden" />
                      <br />
                    </el-card>
                  </div>

                  <!-- 工作记录 -->
                  <div
                    class="record"
                    style="margin-left: 30px"
                    v-if="chooseComponent == 4"
                  >
                    <br />
                    <el-card
                      v-for="(Record, index) in Records"
                      :key="index"
                      class="info-card"
                    >
                      <PersonalRecordBlock :Record="Record" />
                      <br />
                    </el-card>
                  </div>
                </el-container>
              </el-main>
            </el-container>
          </el-container>
        </el-container>
      </div>
    </div>
  </body>
</template>

<script>
import {
  getAllUserInfo,
  getBlogComment,
  getGardenComment,
  getUserGardenInfo,
  getRecords,
  postAllUserInfo,
} from "@/api/personalPageAPI";
import { getGardenInfo } from "@/api/gardenAPI";

import { mapGetters } from "vuex";

export default {
  name: "PersonalInfoPage",
  props: ["id"], // 声明接收名为id的参数,这里用于根据用户id访问数据库获取个人信息构建页面
  data() {
    return {
      //个人主页的用户ID
      account_id: "",

      //功能性变量
      ifInfoChanged: false,
      change: false,
      showtel: true,
      chooseComponent: 1,
      url: "https://img1.imgtp.com/2023/09/08/sUHsllBJ.jpg",
      avaUrl: "",

      // 以下是用户的数据 通过api获取 假数据先保留以备展示（已处理假数据问题）

      //用户信息
      UserInfo: {},

      //互动：花园评论
      GardenComment: [],

      //互动：花园点赞
      GardenLike: [],

      //博客：博客评论
      BlogComment: [],

      //博客：博客点赞
      BlogLike: [],

      //花园：花园信息
      Garden: [],

      //工作记录：工作记录
      Records: [],
    };
  },
  methods: {
    changeInfo() {
      this.change = !this.change;
    },
    ifshowTel() {
      this.showtel = !this.showtel;
    },
    refresh(index) {
      this.chooseComponent = index; //通过v-if
    },
    InfoHasChanged() {
      console.log("信息改变");
      //此处应该向后端发送请求修改数据

      if (this.userId != "") {
        let result = postAllUserInfo(this.UserInfo);
        if (result == true) {
          alert("信息修改成功！");
        } else {
          alert("修改失败，请稍后再试！");
          this.UserInfo = this.getUserInfo(this.userId);
        }
      }
    },
    toggleContentBlogLike(index) {
      this.BlogLike[index].showFullContent =
        !this.BlogLike[index].showFullContent;
    },
    toggleContentBlogCom(index) {
      this.BlogComment[index].showFullContent =
        !this.BlogComment[index].showFullContent;
    },
    toggleContent(index) {
      this.Records[index].showFullContent =
        !this.Records[index].showFullContent;
    },

    //前后端数据转换
    //转换userinfo
    toUserInfoCard(User) {
      var card = {
        name: User.accountName,
        description: User.bio,
        email: User.email,
        registerTime: User.joinTime,
        tel: User.phone,
        points: User.points,
        id: User.accountId,
      };
      this.avaUrl = User.portrait; //补上主页用户头像
      return card;
    },

    //转换gardenComments
    async toGdCommentsCard(comment) {
      const gardeninfo = await getGardenInfo(comment.gardenId);
      const gardenowner = await getAllUserInfo(comment.ownerId);

      var card = {
        author: gardenowner.accountName,
        title: gardeninfo.name, //应该填评论对应的花园的花园名
        avatar: gardenowner.portrait, //用户头像，待补入
        imageurl: gardeninfo.pictures, //应该填评论对应的花园的图片
        comment: comment.content,
      };
      return card;
    },

    //转换gardenlike
    async toGdStarsCard(garden) {
      var card = {
        author: this.UserInfo.name,
        avatar: this.avaUrl, //用户头像，待补入
        stars: 0,
        title: garden.name,
        imageurl: garden.pictures,
      };
      return card;
    },

    //转换BlogLike
    async toBlogLikeCard(blog) {
      var card = {
        author: blog.author,
        avatar: blog.avatar,
        blogName: blog.blogName,
        partialContent: blog.fullContent.substring(0, 100),
        fullContent: blog.fullContent,
        showFullContent: false,
        isOpen: false,
        totalLikes: blog.totalLikes,
        totalComment: blog.totalComment,
      };
      return card;
    },

    //转换为ganden
    async toGardenCard(garden) {
      var card = {
        author: this.UserInfo.name,
        title: garden.name,
        cover: garden.pictures,
        gardenId: garden.gardenId,
      };
      return card;
    },

    //转化为Records
    async toRecordCard(record) {
      var card = {
        date: record.maintenanceTime,
        location: record.location,
        fullContent: record.description,
      };
      return card;
    },

    //有关api获取
    async PageInit() {
      this.account_id = this.$route.params.id; //获取用户id

      var that = this;
      //获取用户信息
      // console.log("开始获取用户信息！", this.account_id, "%");
      getAllUserInfo(this.account_id)
        .then((userInfo) => {
          that.UserInfo = that.toUserInfoCard(userInfo);
          // console.log(that.UserInfo);
        })
        .catch((error) => {
          console.error("获取用户信息失败！", error);
        });

      //获取互动信息:花园评论
      getGardenComment(parseInt(this.account_id)).then(
        function (res) {
          //处理data形式数据的更改异步问题
          console.log("互动返回：", res);
          const promises = res?.map(async (comment) => {
            const card = await that.toGdCommentsCard(comment);
            return card;
          });

          Promise.all(promises).then((cards) => {
            that.GardenComment.push(...cards);
            console.log("转换后：", that.GardenComment);
          });
        },

        function (error) {
          console.error("获取花园评论失败！", error);
        }
      );

      //获取互动信息：花园的星;花园信息
      getUserGardenInfo(parseInt(this.account_id)).then(
        function (res) {
          //处理data形式数据的更改异步问题
          console.log("星数返回：", res);
          const promises = res?.map(async (garden) => {
            const card = await that.toGdStarsCard(garden);
            return card;
          });
          Promise.all(promises).then((cards) => {
            that.GardenLike.push(...cards);
            console.log("转换后：", that.GardenLike);
          });

          //garden卡片
          const promises2 = res?.map(async (garden) => {
            const card = await that.toGardenCard(garden);
            return card;
          });
          Promise.all(promises2).then((cards) => {
            that.Garden.push(...cards);
          });
        },

        function (error) {
          console.error("获取花园星失败！", error);
        }
      );

      //获取blog信息:comments和like
      getBlogComment(parseInt(this.account_id)).then(
        function (res) {
          //处理data形式数据的更改异步问题
          console.log("blog返回:", res);
          const promises = res?.map(async (comment) => {
            const card = comment;
            return card;
          });
          Promise.all(promises).then((cards) => {
            that.BlogComment.push(...cards);
            console.log("转换后1:", that.BlogComment);
          });

          //blogLike******
          const promises2 = res?.map(async (comment) => {
            const card = that.toBlogLikeCard(comment);
            return card;
          });
          Promise.all(promises2).then((cards) => {
            that.BlogLike.push(...cards);
            console.log("转换后2:", that.BlogLike);
          });
        },

        function (error) {
          console.error("获取博客信息失败！", error);
        }
      );

      //获取花园维护信息
      getRecords(parseInt(this.account_id)).then(
        function (res) {
          //处理data形式数据的更改异步问题
          console.log("记录返回:", res);
          const promises = res?.map(async (item) => {
            const card = that.toRecordCard(item);
            return card;
          });
          Promise.all(promises).then((cards) => {
            that.Records.push(...cards);
            console.log("转换后1:", that.Records);
          });
        },

        function (error) {
          console.error("获取博客信息失败！", error);
        }
      );
    },
  },
  mounted() {
    this.PageInit();
  },
  computed: {
    ...mapGetters(["getUserId"]),
    userId() {
      return this.getUserId;
    },
    partialText(text) {
      var length = text.length;
      var cut = 50 >= length / 2 ? 50 : length / 2;
      return text.substring(0, cut);
    },
  },
  watch: {
    chooseComponent(oldValue, newValue) {
      console.log(`chooseComponent 变化！ ${oldValue} -> ${newValue}`);

        
      }
    },
};
</script>

<style scoped>
@import url("../css/personalInfo.css");
</style>
