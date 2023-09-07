<template>
    <el-card class="report-card">
            <h2>
                <span class="spaninfohead">举报人ID: 用户123</span>
            </h2>
            <h4>
                <span class="spaninfohead">举报内容: 这是举报的详细内容，可以包括多行文字描述。</span>
            </h4>
            <h4>
                <span class="spaninfo">举报时间: 2023-09-08 14:30:00</span>
            </h4>
            <div class="button-container">
                <button style='margin: 1vh;' class="btn btn-success" @click="this.$router.push({name: 'garden'})">查看详情</button>
                <button style='margin: 1vh;' class="btn btn-success">回复</button>
            </div>
            <textarea placeholder="写下您的回复..."></textarea>
    </el-card>
</template>

<style>
.report-card {
  width: 800px;
  padding: 2vh;

  border-width: 0vh;
  border-radius: 2vh;

  box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
  background-color: rgb(244, 237, 228);

  margin-top: 6vh;
  margin-bottom: 6vh;

  animation: slide-in-from-bottom 2s;
}
.button-container {
  text-align: center;
}

button:hover {
  transform: scale(1.2);
  transition: 1000ms;
}
</style>