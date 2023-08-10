<!-- 主页底部板块，博客、花园等 -->

<template>
  <div class="card">
    <div class="card-body">

      <img src="https://img1.baidu.com/it/u=4038661611,1664572164&fm=253&fmt=auto&app=138&f=JPEG?w=500&h=502">

      <h5 class="title">同济大学共享花园</h5>

      <div class="time">{{ currentDate }}</div>

      <button class="btn btn-outline-success">举报</button>

    </div>
  </div>
</template>
    
<style scoped>
.card {
  padding: 2vh;
  width: 20vw;
  height: 60vh;

  border-width: 0vh;
  border-radius: 3vh;

  box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
  background-color: rgb(244, 237, 228);

  margin-top: 3vh;
  margin-bottom: 3vh;
}

img {
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 90%;
}

.title {
  text-align: center;
  margin: 2vh;
  font-size: 3vh;
  font-weight: bold;
  color: rgb(12, 60, 38);
}

.time {
  text-align: center;
  font-size: 2vh;
  color: rgb(99, 110, 115);
}

.btn {
  display: block;
  float: right;
  margin: 3vh;
}
</style>
    
<script>
export default {
  name: "ItemBlock",
  data() {
    return {
      currentDate: new Date()
    };
  }
}
</script>