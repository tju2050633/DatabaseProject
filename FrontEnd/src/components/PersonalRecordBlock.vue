<!-- 个人信息页面的工作记录模块 -->

<template>
  <div>
    <h2 class="spaninfohead">
      时间：
      <span>{{ Record.date }}</span>
    </h2>

    <h2 class="spaninfohead">
      地点：
      <span>{{ Record.location }}</span>
    </h2>

    <h2 class="spaninfohead">详情：</h2>

    <p v-if="!Record.showFullContent" class="spaninfo">
      {{ Record.partialContent }}
    </p>
    <p v-else class="spaninfo">
      {{ Record.fullContent }}
    </p>

    <button class="read-more-button" @click="toggleContent">
      {{ RecordData.showFullContent ? "收起" : "展开" }}
    </button>
  </div>
</template>

<script>
export default {
  props: ["Record"],
  data() {
    return {
      RecordData: null,
    };
  },
  created() {
    this.RecordData = this.Record;
  },
  methods: {
    toggleContent() {
      this.RecordData.showFullContent = !this.RecordData.showFullContent;
    },
  },
};
</script>

<style scoped>
@import url("../css/personalInfo.css");
</style>