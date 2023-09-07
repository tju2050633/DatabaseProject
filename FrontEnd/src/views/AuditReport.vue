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
          <AuditReportCard />
        </div>
      </div>
    </body>
  </template>

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