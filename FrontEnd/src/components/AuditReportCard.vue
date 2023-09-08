<template>
    <el-card class="report-card">
            <h4>
                <span class="spaninfohead">举报人: {{ report.reporter }}</span>
            </h4>
            <h4>
                <span class="spaninfohead">举报内容: {{ report.reportContent }}</span>
            </h4>
            <h4>
                <span class="spaninfohead">举报类型: {{ report.reportType }}</span>
            </h4>
            <h4>
                <span class="spaninfo">举报时间: {{ report.reportTime }}</span>
            </h4>
            <div class="button-container">
                <button style='margin: 1vh;' class="btn btn-success" @click="check">查看详情</button>
                <button style='margin: 1vh;' class="btn btn-success" @click="reply">回复</button>
            </div>
            <textarea placeholder="写下您的回复..."></textarea>
    </el-card>
</template>

<script>
export default {
    name: "AuditReportCard",
    props: {
        report: {
            type: Object,
            required: true,
        },
  },
  created() {
    console.log("AuditReportCard created : ", this.report)
  },
  methods: {
    check() {
      // switch (this.report.reportTypeId) {
      //   case 0:
      //       this.$router.push({ path: `/blog/${this.report.reportContent}` });
      //   }
    },
    reply() {

    }
  }
};
</script>

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