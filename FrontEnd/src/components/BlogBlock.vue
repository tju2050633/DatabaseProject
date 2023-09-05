<!-- 博客模块 -->

<template>
  <div>
    <!-- 头部：博客标题、作者头像和用户名 -->
    <div class="card-header">
      <h1 class="blog-name">{{ localCard.blogName }}</h1>
      <img
        class="author-avatar-img"
        :src="localCard.avatar"
        @click="this.$router.push('/PersonalInfo/')"
        alt="作者头像"
      />
      <h2 class="author-name" @click="this.$router.push('/PersonalInfo/')">
        {{ localCard.author }}
      </h2>
    </div>

    <!-- 主体： 博客内容，折叠按钮-->
    <div class="card-content">
      <p v-if="!localCard.showFullContent">
        {{ localCard.partialContent }}
      </p>
      <p v-else>
        {{ localCard.fullContent }}
      </p>
      <button class="read-more-button" @click="toggleContent()">
        {{ localCard.showFullContent ? "收起" : "阅读全文" }}
      </button>
    </div>

    <!-- 底部：评论、点赞 -->
    <div class="card-footer">
      <el-row>
        <el-col span="3">
          <el-button
            @click="toggleCollapse()"
            style="display: flex; align-items: center"
          >
            <span v-if="localCard.isOpen" style="margin-right: 5px">▲</span>
            <span v-else style="margin-right: 5px">▼</span>
            <span style="flex: 1; text-align: center"
              >{{ localCard.isOpen ? "收起评论区" : "展开评论区" }} ({{
                localCard.comments.length
              }})</span
            >
          </el-button>
        </el-col>
        <el-col span="3">
          <el-button
            @click="handleLike()"
            style="display: flex; align-items: center"
          >
            <transition
              name="star-on-transition"
              mode="out-in"
              @after-leave="handleAfterLeave"
            >
              <i class="el-icon-star-off" v-if="!localCard.liked"></i>
              <i class="el-icon-star-on" v-else></i>
            </transition>
            {{ localCard.liked ? "取消点赞" : "点赞" }}
            {{ "(" + localCard.totalLikes + ")" }}
          </el-button>
        </el-col>
        <el-col span="3">
          <el-button
            @click="toggleInput()"
            style="display: flex; align-items: center"
            >撰写评论</el-button
          >
        </el-col>
      </el-row>
      <el-row>
        <el-collapse v-model="localCard.isOpen" v-if="localCard.isOpen">
          <div
            class="comment-container"
            v-for="(commentData, commentIndex) in localCard.comments"
            :key="commentIndex"
          >
            <div>{{ commentData.user }} : {{ commentData.content }}</div>
          </div>
        </el-collapse>
        <div v-if="localCard.showInput">
          <el-input
            class="custom-input"
            v-model="localCard.comment"
            placeholder="输入你的想法..."
          ></el-input>
          <el-button
            @click="submitComment()"
            type="primary"
            size="small"
            style="display: flex; align-items: center"
            >提交</el-button
          >
        </div>
      </el-row>
    </div>
  </div>
</template>

<style scoped>
@import url("../css/blog.css");
</style>

<script>
import {
  getBlogComments,
  postBlogComment,
  handleAgreeNum,
} from "@/api/blogApi.js";

export default {
  props: ["card"],

  data() {
    return {
      localCard: { ...this.card },
    };
  },

  methods: {
    handleAfterLeave() {
      // 过渡结束后立即隐藏退出的图标，优化用户体验
      this.$nextTick(() => {
        this.liked = !this.liked;
      });
    },
    toggleContent() {
      this.localCard.showFullContent = !this.localCard.showFullContent;
    },

    //选择是否展开评论区
    toggleCollapse() {
      this.localCard.isOpen = !this.localCard.isOpen;
      //申请评论数据
      console.log(this.localCard.blogid, "&");
      getBlogComments(this.localCard.blogid).then(
        function (res) {
          console.log("获取评论成功");
          this.localCard.comments = res;
        },
        function (err) {
          console.log("获取评论失败", err);
        }
      );
    },

    handleLike() {
      if (!this.localCard.liked) {
        this.localCard.totalLikes++;
      } else {
        this.localCard.totalLikes--;
      }
      this.localCard.liked = !this.localCard.liked;
      //更新点赞数
      handleAgreeNum(this.localCard.totalLikes);
    },
    toggleInput() {
      this.localCard.showInput = !this.localCard.showInput;
      this.localCard.comment = "";
    },

    submitComment() {
      if (this.localCard.comment.trim() === "") {
        return;
      }
      //申请接口连接
      postBlogComment(
        this.localCard.blogid,
        this.localCard.author,
        this.localCard.comment
      ).then(
        function (res) {
          window.alert(res);
          this.toggleInput();
        },
        function (err) {
          console.log(err);
        }
      );
    },
  },
};
</script>