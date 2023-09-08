<template>
  <body>
    <div class="container">
      <NavBar />
      <!-- 导航栏 -->

      <div class="row" style="width: 100%">
        <!-- 侧边栏 -->
        <div class="col-2">
          <SideBar />
        </div>

        <!-- 展示多个 AuditReportCard 组件 -->
        <div class="col-10">
          <div v-if="reports.length === 0">暂无举报</div>
          <div v-else>
            <div v-for="(report, index) in reports" :key="index">
              <AuditReportCard :report="report" />
            </div>
          </div>
        </div>

      </div>
    </div>
  </body>
</template>

<script>
import AuditReportCard from "@/components/AuditReportCard.vue";
import { getReports } from '@/api/auditApi';
import { getUserNameById } from '@/api/accountApi';

export default ({
  components: {
    AuditReportCard,
  },
  data() {
    return {
      reports: [],
      reportTypes: { 0: "博客", 1: "博客评论", 2: "花园", 3: "花园评论", 4: "花园活动" },
    };
  },
  async mounted() {
    const reports = await getReports();

    for (let i = 0; i < reports.length; i++) {
      const reporter = await getUserNameById(reports[i].reporterId);
      const reportType = this.reportTypes[reports[i].reportType];
      const report = {
        reporter: reporter,
        reportContent: reports[i].reportedContentId,
        reportTypeId: reports[i].reportType,
        reportType: reportType,
        reportTime: new Date(reports[i].reportTime).toLocaleDateString("zh-CN")
      };
      this.reports.push(report);
    }
  },

})
</script>


<style scoped>
body {
  background-color: rgb(244, 237, 228);
  background-size: 25vw;
  background-repeat: no-repeat;
  position: relative;
  background-position: right;
  background-attachment: fixed;
}

.container {
  margin-top: 60px;
}
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
</style>