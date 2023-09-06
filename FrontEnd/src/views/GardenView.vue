<template>
  <body class="gardenBody">
    <div class="container" style="margin-top: 60px">
      <!-- 导航栏 -->
      <NavBar />

      <el-row id="mainpart">
        <!-- 侧边栏 -->
        <SideBar />

        <el-col :span="15">
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

          <el-card class="garden-detail">
            <el-carousel indicator-position="outside">
              <el-carousel-item v-for="(item, index) in imageList" :key="index">
                <img :src="item.imageUrl" alt="花园" style="width: 100%" />
              </el-carousel-item>
            </el-carousel>
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
            <h1 class="gardeninfohead">
              地点
              <el-icon style="margin-top: 10px">
                <position />
              </el-icon>
            </h1>
            <div class="info-detail">
              <br />{{gardenInfo.location}}<br /><br /><br />
            </div>

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
import { getGardenInfo, postComment } from '@/api/gardenAPI';
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
      imageList: [ ],
    };
  },

  ///// init

  async created() {
    this.initGardenInfo();
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
  
  