<!-- 花园展厅模块 hot new共用 参数为image对象 -->

<template>
  <div>
    <div style="text-align: center">
      <img :src="image.imageUrl" alt="花园图片" class="garden-img" style="height: 250px; margin: 3vh;" />
    </div>
    <div style="display: flex; justify-content: space-between">
      <span style="flex: 1; text-align: left" class="garden-info"
        ><el-icon style="margin-top: 5px"> <user /> </el-icon
        >{{ image.username }}</span
      >
      <span style="flex: 1; text-align: center" class="garden-info">{{
        image.gardenname
      }}</span>
      <span style="flex: 1; text-align: right" class="garden-info"
        ><el-icon style="margin-top: 5px"> <star /> </el-icon
        >{{ image.hot }}</span
      >
    </div>
  </div>
</template>

<script>
export default {
  name: "GardenBlock",
  props: {
    image: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style scoped>
@import url("../css/garden.css");
</style>