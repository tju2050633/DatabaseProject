<!--
 * @Author: Jialin Lu
 * @GitHub: https://github.com/tju2050633
 * @Date: 2023-08-09 15:24:49
 * @FilePath: /SharingGardenProject/FrontEnd/src/components/PersonalBlogBlock.vue
 * @Description: 
 * 
 * Copyright (c) 2023 by 1640889387@qq.com, All Rights Reserved. 
-->
<!-- 个人信息页面的博客模块 -->

<template>
  <div>
    <div class="card-header">
      <h1 class="spaninfohead">{{ card.blogName }}</h1>
      <img
        class="author-avatar-img"
        :src="card.avatar"
        alt="作者头像"
      />
      <h2 class="spaninfohead" >
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
      <button class="read-more-button" @click="toggleContentBlogLike()">
        {{ cardData.showFullContent ? "收起" : "阅读全文" }}
      </button>
      <h3 class="spaninfohead">
        <el-icon style="star: 10px"><Star /></el-icon>
        {{ card.totalLikes }}
        &ensp;&ensp;&ensp;
        <el-icon style="chat: 10px"><ChatLineSquare /></el-icon>
        {{ card.totalComment }}
      </h3>
    </div>
  </div>
</template>

<script>
export default {
  props: ["card"],
  data() {
    return {
      cardData: null,
    };
  },
  created() {
    this.cardData = this.card;
  },
  methods: {
    toggleContentBlogLike() {
      this.cardData.showFullContent = !this.cardData.showFullContent;
    },
  },
};
</script>

<style scoped>
@import url("../css/personalInfo.css");
</style>