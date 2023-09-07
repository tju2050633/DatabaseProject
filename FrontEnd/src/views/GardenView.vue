<template>
  <body class="gardenBody">
    <div class="container" style="margin-top: 60px">
      <!-- 导航栏 -->
      <NavBar />

      <el-row id="mainpart">
        <!-- 侧边栏 -->
        <SideBar />

        <el-col :span="15">

          <!-- head -->

          <el-card class="garden-bfinstru">
            <el-row style="font-size: x-large">
              <el-col :span="1" :offset="4">
                <el-icon style="margin-top: 5px" class="gardeninfohead">
                  <user />
                </el-icon>
              </el-col>
              <el-col :span="2" class="gardeninfohead">
                {{gardenInfo.username}}
              </el-col>
              <el-col :span="6" :offset="2" class="gardeninfohead">
                {{gardenInfo.gardenname}}
              </el-col>
              <el-col :span="1" :offset="2" class="gardeninfohead">
                <el-icon style="margin-top: 5px" class="gardeninfohead">
                  <star />
                </el-icon>
              </el-col>
              <el-col :span="2" class="gardeninfohead">
                {{gardenInfo.hot}}
              </el-col>
              <el-button
                @click="this.$router.push('/display')"
                class="backButton"
                >返回展厅</el-button
              >
            </el-row>
          </el-card>

          <!-- body -->

          <el-card class="garden-detail">

            <!-- 轮播图 -->
            <el-carousel indicator-position="outside">
              <el-carousel-item v-for="(item, index) in imageList" :key="index">
                <img :src="item.imageUrl" alt="花园" style="width: 100%" />
              </el-carousel-item>
            </el-carousel>

            <!-- 描述 -->
            <h1 class="gardeninfohead">
              描述
              <el-icon style="margin-top: 10px">
                <house />
              </el-icon>
            </h1>

            <div class="info-detail">
              <br />
              &nbsp;&nbsp;&nbsp;&nbsp;
              {{gardenInfo.describe}}
              <br />
            </div>

            <!-- 地点 -->
            <h1 class="gardeninfohead">
              地点
              <el-icon style="margin-top: 10px">
                <position />
              </el-icon>
            </h1>

            <div class="info-detail">
              <br />{{gardenInfo.location}}<br /><br /><br />
            </div>

            <!-- 评论 -->
            <h1 class="gardeninfohead">
              评论
              <el-icon style="margin-top: 10px">
                <comment />
              </el-icon>
            </h1>

            <div class="comment-list">
              <div v-for="(comment, index) in commentList" :key="index" class="comment-item">
                <div class="comment-header">
                  <span class="comment-owner">{{ comment.owner }}</span>
                  <span class="comment-time">{{ comment.time }}</span>
                </div>
                <div class="comment-content">{{ comment.content }}</div>
              </div>
            </div>

            <!-- 提交评论 -->
            <div class="comment-box">
              <textarea
                v-model="comment"
                placeholder="写下您的评论..."
              ></textarea>
              <button class="commentButton" @click="submitComment">
                提交评论
              </button>
            </div>

          </el-card>

        </el-col>
      </el-row>
    </div>
  </body>
</template>
  
  
<style scoped>
@import url("../css/garden.css");
</style>
  
  
<script>
import { getGardenInfo, getComments, postComment } from '@/api/gardenAPI';
import { getUserNameById } from '@/api/accountApi';
import { mapGetters } from 'vuex';
export default {

  ///// data

  name: "app",
  props: ['garden_id'],
  data() {
    return {
      gardenInfo:{
        username:"",
        gardenname:"",
        hot:"",
        describe:``,
        location:"",
      },
      comment: "", // 存储用户输入的评论内容
      imageList: [],
      commentList: [
        {
          owner: "Alice",
          time: "2021-06-01",
          content: "abcde"
        },
        {
          owner: "Bob",
          time: "2023-04-08",
          content: "ABCDE"
        },
      ],
    };
  },

  ///// init

  async created() {
    this.initGardenInfo();
    this.initComments();
  },

  computed:{
    ...mapGetters(['getUserId']),
    userId() {
      return this.getUserId;
    },
  },

  ///// methods

  methods: {

    // init garden info

    async initGardenInfo() {
      const gardenInfo = await getGardenInfo(this.garden_id);
      const username = await getUserNameById(gardenInfo.ownerId);
      this.gardenInfo.username = username;
      this.gardenInfo.gardenname = gardenInfo.name;
      this.gardenInfo.hot = gardenInfo.stars;
      this.gardenInfo.describe = gardenInfo.description;
      this.gardenInfo.location = gardenInfo.position;
      this.comment = "";
      this.imageList.push({ imageUrl: gardenInfo.pictures });
    },

    // init comments

    async initComments() {
      const comments = getComments(this.garden_id);
      console.log("initComments : ", comments);

      for(let i = 0; i < comments.length; i++)
      {
        const username = await getUserNameById(comments[i].ownerId);
        this.commentList.push({
          owner: username,
          time: comments[i].time,
          content: comments[i].content
        });
      }
    },

    // submit comment

    submitComment() {
      let result = postComment(this.comment);
      if (result.success)
      {
          alert(result.message)
      }
      else
      {
          alert(result.message)
      }
      // 清空输入框
      this.comment = "";
    },

  },

};
</script>
  
  