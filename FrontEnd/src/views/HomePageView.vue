<template>
  <div class="mainPage">
  <!-- 页面头 -->
  <el-header>
    <el-row :span="24">
      <el-col :offset="2" :span="1">
        <img src="../assets/logo.png" class="logo"/>
      </el-col>
      <el-col :span="2" class="logo-text">
        共享花园
      </el-col>
      <el-col :span="9" :offset="2">
        <el-input style="margin-top: 10px;" v-model="searchData"  @focus="searchListShow"
					@blur="searchListHide" class="search-input"
          :class="{'active': focusFlag}"
          type="search"
          value="" />
        <ul class="search-list" v-show="!hotsListFlag">
          <li class="list-item" v-for="(item, index) in searchHistory" :key="index">{{item}}</li>
        </ul>
      </el-col>
      <el-col :span="1">
        <el-button type="primary"  style="margin-top: 10px;"><el-icon><search/></el-icon></el-button>
      </el-col>
        <el-col :span="1" :offset="5">
          <el-dropdown>
          <el-avatar :size="size" :src="avatarUrl"></el-avatar>
            <template v-slot:dropdown>
            <el-dropdown-menu>
             <el-dropdown-item @click="this.$router.push()">个人主页</el-dropdown-item>
             <el-dropdown-item @click="this.$router.push()">消息通知</el-dropdown-item>
             <el-dropdown-item @click="this.$router.push()">关于我们</el-dropdown-item>
             <el-dropdown-item @click="this.$router.push()">反馈</el-dropdown-item>
          </el-dropdown-menu>
        </template>
        </el-dropdown>
        {{ UserInfo.name }}
        </el-col>
    </el-row>
  </el-header>

    <!-- 侧边栏 -->
  <el-row> 
    <el-col :span="3">
      <el-menu>
        <el-sub-menu index="1">
          <template #title>
            <el-icon><user /></el-icon>
            <span>账号管理</span>
          </template>
          <el-menu-item index="1-1">我的主页</el-menu-item>
          <el-menu-item index="1-2">登入/登出</el-menu-item>
        </el-sub-menu>
        <el-sub-menu index="2">
          <template #title>
            <el-icon><position /></el-icon>
            <span>校园地图</span>
          </template>
          <el-menu-item index="2-1">四平路校区</el-menu-item>
          <el-menu-item index="2-2">嘉定校区</el-menu-item>
          <el-menu-item index="2-3">沪西校区</el-menu-item>
        </el-sub-menu>
        <el-sub-menu index="3">
          <template #title>
            <el-icon><house /></el-icon>
            <span>花园管理</span>
          </template>
          <el-menu-item index="3-1" >精选花园</el-menu-item>
          <el-menu-item index="3-2" >我的花园</el-menu-item>
        </el-sub-menu>
        <el-sub-menu index="4">
          <template #title>
            <el-icon><chatSquare /></el-icon>
            <span>博客论坛</span>
          </template>
          <el-menu-item index="4-1">精选博客</el-menu-item>
          <el-menu-item index="4-2">我的发表</el-menu-item>
        </el-sub-menu>
      </el-menu>
    </el-col>

        <!-- 走马灯的主页图片 -->
    <el-col :span="21">
      <el-carousel indicator-position="outside">
         <el-carousel-item v-for="i in mainPageDem" :key="i">
         <img :src="i.src">
         nh
        </el-carousel-item>
      </el-carousel>
    </el-col>
  </el-row>
<div class="navigator">
  <el-row>
    <el-col></el-col>
  </el-row>
</div>  
<br><br><br><br>
<!-- 快速导航-->

<div class="navigator">
  
  <el-row>
    <el-col :offset="6" :span="3">
      <el-card shadow="hover">
        <el-icon><video-camera></video-camera></el-icon>
        <span :offset="1">花园展厅</span>
      </el-card>
    </el-col>
    <el-col :span="3">
      <el-card shadow="hover">
        <el-icon><video-camera></video-camera></el-icon>
        <span :offset="1">我的花园</span>
      </el-card>
    </el-col>
    <el-col :span="3">
      <el-card shadow="hover">
        <el-icon><video-camera></video-camera></el-icon>
        <span :offset="1">博客论坛</span>
      </el-card>
    </el-col>
    <el-col :span="3">
      <el-card shadow="hover">
        <el-icon><video-camera></video-camera></el-icon>
        <span :offset="1">当前热榜</span>
      </el-card>
    </el-col>
  </el-row>

  <el-row>
    <el-col :offset="6" :span="3">
      <el-card shadow="hover">
        <el-icon><video-camera></video-camera></el-icon>
        <span :offset="1">统计数据</span>
      </el-card>
    </el-col>
    <el-col :span="3">
      <el-card shadow="hover">
        <el-icon><video-camera></video-camera></el-icon>
        <span :offset="1">志愿者招募</span>
      </el-card>
    </el-col>
    <el-col :span="3">
      <el-card shadow="hover">
        <el-icon><video-camera></video-camera></el-icon>
        <span :offset="1">花园活动</span>
      </el-card>
    </el-col>
    <el-col :span="3">
      <el-card shadow="hover">
        <el-icon><video-camera></video-camera></el-icon>
        <span :offset="1">积分商城</span>
      </el-card>
    </el-col>
  </el-row>

</div>

  <!-- 详情展示-->
  <br><br><br><br>
<div class="item-block">
<el-row v-for="i in (blockData.length)" :key="i" :span=24>
  <el-col :span=6  v-for="o in 3" :key="o" :offset="o==0?3:1">
    <el-card shadow="hover" >
      <img src="https://img2.baidu.com/it/u=1903252484,200684433&fm=253&fmt=auto&app=138&f=JPEG?w=500&h=500" class="image">
      <div style="padding: 15px;">
        <span>同济大学共享花园</span>
        <div class="bottom clearfix">
          <time class="time">发布时间：{{ currentDate }}</time>
          <el-button type="text" class="button" icon="el-icon-warning">举报</el-button>
        </div>
      </div>
    </el-card>
  </el-col>
  <br>
  
</el-row>
</div>

<!--回到顶部-->
<el-backtop :bottom="50" :right="50">
  <div
      style="{
      height: 100%;
      width: 100%;
      border-radius: 50%;
      font-size: 13px;
      background-color: #f2f5f6;
      box-shadow: 0 0 6px rgba(0,0,0, .12);
      text-align: center;
      line-height: 20px;
      color: #1989fa;
      padding: 20px;
    }"
    >
      返回顶部
    </div>
 </el-backtop>


  <RouterView></RouterView>
</div>
</template>


<style scoped>

.logo{
  border-radius: 50%;
  width:50px;
}

.logo-text{
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
      clear: both
  }

</style>



<script>
export default {
  name: "HomePageView",
  data() {
    return {

      searchHistory: ['111','222', '333', '444', '555', '666', '777', '888', '999', '000'],
      hotsListFlag: true,
      focusFlag: false,
      
      UserInfo:{name:'未登录',accountId:'#',type:'#'},
      mainPageDem:[
        {description:'',src:'../assets/logo.png"'},
        {description:'',src:'../assets/mainpage.jpeg'},
        {description:'',src:'../assets/mainpage.jpeg'},
        {description:'',src:'../assets/mainpage.jpeg'}
      ],
      avatarUrl:"https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png",
      searchData: "",
      currentDate: new Date(),
      blockData:[0,1,2,3,4,5,6,7,8,9],
      len:10,
      channelList: [
        {value: '花园展厅', src: 'https://cdn.cnbj1.fds.api.mi-img.com/mi-mall/82abdba456e8caaea5848a0cddce03db.png?w=48&h=48', url: 'https://www.baidu.com'},
        {value: '我的花园', src: 'https://cdn.cnbj1.fds.api.mi-img.com/mi-mall/806f2dfb2d27978e33fe3815d3851fa3.png?w=48&h=48', url: 'https://www.baidu.com'},
        {value: '博客论坛', src: 'https://cdn.cnbj1.fds.api.mi-img.com/mi-mall/eded6fa3b897a058163e2485532c4f10.png?w=48&h=48', url: 'https://www.baidu.com'},
        {value: '当前热榜', src: 'https://cdn.cnbj1.fds.api.mi-img.com/mi-mall/43a3195efa6a3cc7662efed8e7abe8bf.png?w=48&h=48', url: 'https://www.baidu.com'},
        {value: '统计数据', src: 'https://cdn.cnbj1.fds.api.mi-img.com/mi-mall/f4846bca6010a0deb9f85464409862af.png?w=48&h=48', url: 'https://www.baidu.com'},
        {value: '志愿者招募', src: 'https://cdn.cnbj1.fds.api.mi-img.com/mi-mall/9a76d7636b08e0988efb4fc384ae497b.png?w=48&h=48', url: 'https://www.baidu.com'},
        {value: '花园活动', src: 'https://cdn.cnbj1.fds.api.mi-img.com/mi-mall/9a76d7636b08e0988efb4fc384ae497b.png?w=48&h=48', url: 'https://www.baidu.com'},
        {value: '积分商城', src: 'https://cdn.cnbj1.fds.api.mi-img.com/mi-mall/9a76d7636b08e0988efb4fc384ae497b.png?w=48&h=48', url: 'https://www.baidu.com'}

      ],
      promoList: [
        {value: 'photo', src: 'https://img2.baidu.com/it/u=515617864,988567067&fm=253&fmt=auto&app=138&f=JPEG?w=500&h=500', url: 'https://www.baidu.com'},
        {value: 'photo', src: 'https://img2.baidu.com/it/u=515617864,988567067&fm=253&fmt=auto&app=138&f=JPEG?w=500&h=500', url: 'https://www.baidu.com'},
      ],

    };
  },
  methods: {
 // 搜索框下拉列表
    searchListShow () {
      this.hotsListFlag = false;
      this.focusFlag = true;
    },
    searchListHide () {
      this.hotsListFlag = true;
      this.focusFlag = false;
    }

  },
  computed:{
  

  },
  components:{
  }
};
</script>

