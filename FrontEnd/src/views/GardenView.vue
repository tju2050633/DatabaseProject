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
import { getGardenInfo,postComment,getImageList } from '@/api/gardenAPI';
import { mapGetters } from 'vuex';
export default {
  name: "app",
  data() {
    return {
      gardenInfo:{
        username:"楚杰",
        gardenname:"杰哥的花园",
        hot:"50",
        describe:`在这个梦幻般的A花园里，自然与人工的完美融合令人惊叹。踏入花园的瞬间，弥漫着清新的花香，让人心情为之一振。
      漫步其中，映入眼帘的是一片色彩斑斓的花海，各种绚丽多姿的花朵竞相绽放，彼此交织成一幅绚烂的画卷。
      沿着曲折的小径，脚下软软的绿草踏起来舒适宜人，仿佛走在大自然的怀抱中。这些小径通向不同的角落，让人好奇地探索着。
      林荫小道在夏日的阳光下，投下斑驳的树影，让人感受到阵阵清凉。在炎热的日子，这里是避暑的好去处。`,
      location:"安楼后的小树林",
      },
      comment: "", // 存储用户输入的评论内容
      imageList: [
        {
          imageUrl: require("../assets/Garden.jpg"),
        },
        {
          imageUrl: require("../assets/Garden.jpg"),
        },
        {
          imageUrl: require("../assets/Garden.jpg"),
        },
        {
          imageUrl: require("../assets/Garden.jpg"),
        },
      ],
    };
  },
  methods: {
    submitComment() {
      // 在此处添加提交评论的逻辑，例如将评论内容发送到后端服务器保存等
      console.log("提交评论")
      let result=postComment(this.comment)
      if(result==true){
        alert('信息修改成功！')
      }else{
        alert('修改失败，请稍后再试！')
      }
      // 清空输入框
      this.comment = "";
    },
    getUserInfo(){
      console.log('开始获取花园信息！')
      if(this.userId!=''){ //这样可以展示假数据
        this.imageList=getImageList(this.userId);
        this.gardenInfo=getGardenInfo(this.userId);
      }
    },
  },
  mounted(){
    this.getUserInfo()
  },
  computed:{
    ...mapGetters(['getUserId']),
    userId() {
      return this.getUserId;
    },
  },
  
};
</script>
  
  