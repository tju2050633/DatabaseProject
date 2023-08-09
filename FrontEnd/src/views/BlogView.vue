<template>
  <body class="blogBody">
    <div class="container" style="margin-top: 60px">
      <!-- 导航栏 -->
      <NavBar />

      <el-row id="mainpart" class="blogmainpart">
        <!-- 侧边栏 -->
        <SideBar />

        <el-col :span="14">
          <div id="app">
            <el-card class="blog-card">
              <el-row>
                <img class="head-img" src="../assets/blog-logo.png" />
              </el-row>
            </el-card>
            <el-card
              v-for="(card, index) in cards"
              :key="index"
              class="blog-card"
            >
              <BlogBlock :card="card" />
            </el-card>
            <div>
              <button @click="loadMoreBlogs">加载更多</button>
            </div>
          </div>
        </el-col>
      </el-row>
    </div>
  </body>
</template>

<style scoped>
@import url("../css/blog.css");
</style>

<script>
import { reactive, ref, onMounted } from "vue";
import API from "@/api/basicApi.js";

export default {
  el: "#app",
  name: "BlogView",
  setup() {
    const cards = reactive([
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
    ]);
    const showInput = reactive(false);
    const comment = reactive("");

    //定义博客读取要用的变量
    const state = reactive({
      currentPage: 1, //当前的博客页面，用于博客分页与无限刷新
      blogs: [], //博客列表
      pageSize: 10, //博客分页大小
    });
    //错误信息
    let errMessage = ref("");

    // 执行一些初始化逻辑
    onMounted(() => {
      // this.loadBlogs();测试已有接口不掉用该函数
      loadBlogUsingId();
    });

    //跳转到博客页面时获取初始的博客数据
    const loadBlogs = () => {
      console.log("开始博客读取");
      API({
        url: "/Blog/",
        method: "get",
        params: {
          page: state.currentPage,
          pagesize: state.pageSize,
        },
      }).then(
        function (res) {
          console.log("获取成功");
          state.blogs = res.data;
        },
        function (err) {
          console.log("获取失败");
          errMessage.value = err.data;
        }
      );
    };
    //加载更多的博客数据
    const loadMoreBlogs = () => {
      console.log("开始博客读取");
      API({
        url: "/Blog/",
        method: "get",
        params: {
          page: state.currentPage,
          pagesize: state.pageSize,
        },
      }).then(
        function (res) {
          console.log("获取更多成功");
          state.currentPage++;
          state.blogs.push(res.data);
        },
        function (err) {
          console.log("获取更多失败");
          errMessage.value = err.data;
        }
      );
    };

    //下面用于测试已有的接口
    //将后端返回的数据格式改为前端使用的cards
    const toCard = (blog) => {
      console.log(blog.content);
      var card = {
        author: blog.blogId,
        avatar: require("../assets/author-avatar.jpg"), //后端数据库没有
        blogName: blog.title,
        partialContent: blog.content.substring(0, 100),
        fullContent: blog.content,
        showFullContent: false,
        isOpen: false,
        comments: [
          //后端数据库没有
          { user: "User7", content: "Comment 7" },
          { user: "User8", content: "Comment 8" },
          // Add more comments here
        ],
        liked: false, // 是否已点赞
        totalLikes: blog.agreeNum, // 总点赞次数
        showInput: false,
        comment: "",
      };
      return card;
    };
    const loadBlogUsingId = () => {
      console.log("开始博客读取测试");
      API({
        url: "/Blog/",
        method: "get",
        params: {
          id: 2, //测试数据写死
        },
      }).then(
        function (res) {
          console.log("测试成功");
          //测试获得的内容
          console.log(res.data);
          state.blogs.push(res.data);
          cards.push(toCard(res.data));
        },
        function (err) {
          console.log("测试失败");
          errMessage.value = err.data;
        }
      );
    };

    return {
      cards,
      state,
      showInput,
      comment,
      errMessage,
      loadBlogs,
      loadMoreBlogs,
      toCard,
      loadBlogUsingId,
    };
  },
};
</script>
