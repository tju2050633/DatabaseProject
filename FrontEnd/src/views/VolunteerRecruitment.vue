<template>
  <body>
    <div class="container">
      <NavBar /> <!-- 导航栏 -->

      <el-row id="mainpart">
        <SideBar /> <!-- 侧边栏 -->

        <!-- 志愿者招募 -->
        <el-col :span="13">
          <el-container>

            <!-- 标题 -->
            <el-header class="heading-field">
              <h1 class="heading">
                <svg xmlns="http://www.w3.org/2000/svg" width="44" fill="currentColor" class="bi bi-person-lines-fill"
                  viewBox="0 0 16 16">
                  <path
                    d="M6 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm-5 6s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H1zM11 3.5a.5.5 0 0 1 .5-.5h4a.5.5 0 0 1 0 1h-4a.5.5 0 0 1-.5-.5zm.5 2.5a.5.5 0 0 0 0 1h4a.5.5 0 0 0 0-1h-4zm2 3a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1h-2zm0 3a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1h-2z" />
                </svg>
                &nbsp;志愿者招募
              </h1>
            </el-header>

            <!-- 志愿信息 -->
            <!--这里实际项目中应该为数据库读取并展示-->
            <div v-for="(content, index) in volunteerContent" :key="index">
              <VolunteerBlock :content="content" />

              <!--志愿问卷-->
              <div class="button-field">
                <button class="btn btn-outline-secondary" @click="volunteerDialog.dialogVisible = true">
                  {{ "我要报名" }}
                </button>
                <button class="btn btn-outline-secondary" @click="this.$router.push('/garden/')">
                  {{ "进入花园" }}
                </button>
              </div>

              <!--报名弹窗-->
              <el-dialog v-model="volunteerDialog.dialogVisible" title="报名表">
                <el-form :model="form">
                  <el-form-item label="你的名字" :label-width="formLabelWidth">
                    <el-input v-model="volunteerDialog.volunteername" style="width: 140px" autocomplete="off" />
                  </el-form-item>
                  <el-form-item label="电话号码" :label-width="formLabelWidth">
                    <el-input v-model="volunteerDialog.phonenumber" style="width: 200px" autocomplete="off" />
                  </el-form-item>
                  <el-form-item label="选择日期" :label-width="formLabelWidth">
                    <el-select v-model="volunteerDialog.dayOfWeek" class="m-2" placeholder="星期">
                      <el-option v-for="item in week" :key="item.value" :label="item.label" :value="item.value" />
                    </el-select>
                    <el-time-select v-model="volunteerDialog.time" start="08:30" step="00:15" end="18:30"
                      placeholder="选择时间" />
                  </el-form-item>
                  <el-form-item label="自我描述" :label-width="formLabelWidth">
                    <el-input v-model="volunteerDialog.describe" :autosize="{ minRows: 2, maxRows: 10 }" type="textarea"
                      placeholder="here" />
                    <div style="margin: 20px 0" />
                  </el-form-item>
                </el-form>
                <template #footer>
                  <span class="dialog-footer">
                    <el-button @click="volunteerDialog.dialogVisible = false">
                      Cancel
                    </el-button>
                    <el-button type="primary" @click="volunteerDialog.dialogVisible = false">
                      Confirm
                    </el-button>
                  </span>
                </template>
              </el-dialog>
            </div>

          </el-container>
        </el-col>

        <!-- 志愿工作榜 -->
        <el-col :span="8">
          <el-container>

            <!-- 标题 -->
            <el-header class="heading-field">
              <h1 class="heading">
                <svg xmlns="http://www.w3.org/2000/svg" width="44" fill="currentColor" class="bi bi-list-ul"
                  viewBox="0 0 16 16">
                  <path fill-rule="evenodd"
                    d="M5 11.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zm0-4a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zm0-4a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zm-3 1a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm0 4a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm0 4a1 1 0 1 0 0-2 1 1 0 0 0 0 2z" />
                </svg>
                &nbsp;志愿工作榜
              </h1>
            </el-header>

            <el-main>
              <el-col v-for="(item, index) in displayedImageList" :key="index">
                <div class="card volunteer-list" @click="this.$router.push('/personalInfo/')">
                  <span>
                    <h4 class="volunteer-list-text">
                      {{ item.description }}&ensp;
                      <el-icon style="margin-top: 20px">
                        <user />
                      </el-icon>
                      {{ item.username }}&ensp;
                      {{ item.myPoints }}
                    </h4>
                  </span>
                </div>
              </el-col>

              <br />

              <button class="btn btn-secondary" @click="toggleShowMore" style="margin-top: 10px">
                {{ showMore ? "收起" : "显示更多" }}</button>
            </el-main>

          </el-container>
        </el-col>

      </el-row>

    </div>
  </body>
</template>

<style scoped>
body {
  background-color: rgb(244, 237, 228);
  background-image: url("../assets/img-volunteer.jpg");
  background-size: 30vw;
  background-repeat: no-repeat;
  position: relative;
  background-position: 65vw 35vh;
  background-attachment: fixed;
}

.container {
  margin-top: 60px
}

.heading-field {
  margin-top: 6vh;
  margin-bottom: 3vh;
}

.heading {
  text-align: center;
  font-size: 6vh;
  font-weight: bold;
  color: rgb(12, 60, 38);

  animation: fade-in 2s;
}

@keyframes fade-in {
  0% {
    opacity: 0;
  }

  100% {
    opacity: 1;
  }
}

.button-field {
  text-align: center;
}

.btn {
  margin-top: 1vh;
  margin-bottom: 5vh;
  margin-left: 3vh;
  margin-right: 3vh;
}

.btn:hover {
  transform: scale(1.1);
  transition: 500ms;
}

.volunteer-list {
  padding: 2vh;
  margin-bottom: 1vh;

  border-width: 0vh;
  border-radius: 2vh;

  box-shadow: 4px 4px 8px rgba(0, 0, 0, 0.2);
  background-color: rgb(246, 243, 239);

}

.volunteer-list:hover {
  cursor: pointer;
  transform: scale(1.05);
  transition: 300ms;
}

.volunteer-list-text {
  font-size: 2.5vh;
  font-weight: bold;
  color: rgb(99, 110, 115);
}
</style>

<script>
import { getVolunteerList, getVolunteerContent, submitForm } from '../api/VolunteerAPI'
export default {
  el: "#mainpart",
  data() {
    return {
      showMore: false, // 控制是否显示更多
      displayedImageList: [], // 实际显示的列表
      maxDisplayCount: 3, // 默认显示的数量

      imageList: [
        {
          description: "TOP1 ",
          username: "王浩",
          myPoints: "256",
        },
        {
          description: "TOP2 ",
          username: "王浩二",
          myPoints: "246",
        },
        {
          description: "TOP3 ",
          username: "王浩三",
          myPoints: "240",
        },
        {
          description: "TOP4 ",
          username: "王浩四",
          myPoints: "235",
        },
        {
          description: "TOP5 ",
          username: "王浩五",
          myPoints: "230",
        },
        {
          description: "TOP6 ",
          username: "王浩六",
          myPoints: "226",
        },
        {
          description: "TOP7 ",
          username: "王浩七",
          myPoints: "210",
        },
        {
          description: "TOP8 ",
          username: "王浩八",
          myPoints: "200",
        },
        {
          description: "TOP9 ",
          username: "王浩九",
          myPoints: "156",
        },
        {
          description: "TOP10 ",
          username: "王浩十",
          myPoints: "56",
        },
      ],
      volunteerContent: [
        {
          imageUrl: require("../assets/Garden-e.jpg"),
          dialogVisible: false, //是否出现弹窗
          username: "Student1",
          gardenname: "王浩的后宫1",
          location: "嘉定校区19号楼",
          describe: `诚邀您来维护本花园，主要工作如下：
                    首先，帮我把花园的土给翻了
                    然后，我的花园一盆花都没有，帮我全买了 
                    最后帮我浇水
                    谢谢你`,
        },
        {
          imageUrl: require("../assets/Garden-e.jpg"),
          dialogVisible: false,
          username: "Student2",
          gardenname: "Garden2",
          location: "嘉定校区19号楼",
          describe: `诚邀您来维护本花园，主要工作如下：
                    首先，帮我把花园的土给翻了
                    然后，我的花园一盆花都没有，帮我全买了 
                    最后帮我浇水
                    谢谢你`,
        },
        {
          imageUrl: require("../assets/Garden-e.jpg"),
          dialogVisible: false,
          username: "Student3",
          gardenname: "Garden3",
          location: "嘉定校区19号楼",
          describe: `诚邀您来维护本花园，主要工作如下：
                    首先，帮我把花园的土给翻了
                    然后，我的花园一盆花都没有，帮我全买了 
                    最后帮我浇水
                    谢谢你`,
        },
        {
          imageUrl: require("../assets/Garden-e.jpg"),
          dialogVisible: false,
          username: "Student4",
          gardenname: "Garden4",
          location: "嘉定校区19号楼",
          describe: `诚邀您来维护本花园，主要工作如下：
                    首先，帮我把花园的土给翻了
                    然后，我的花园一盆花都没有，帮我全买了 
                    最后帮我浇水
                    谢谢你`,
        },
      ],
      volunteerDialog: [
        {
          dialogVisible: false, //是否出现弹窗
          ownername: "Student1",
          volunteername: "",
          phonenumber: "",
          time: "",
          dayOfWeek: "",
          describe: "",
        },
      ],
      week: [
        { value: "星期一", label: "星期一" },
        { value: "星期二", label: "星期二" },
        { value: "星期三", label: "星期三" },
        { value: "星期四", label: "星期四" },
        { value: "星期五", label: "星期五" },
        { value: "星期六", label: "星期六" },
        { value: "星期日", label: "星期日" },
      ],
    };
  },
  methods: {
    handleMenuSelect(index) {
      this.activeTab = index;
    },
    toggleShowMore() {
      this.showMore = !this.showMore;
      this.updateDisplayedImages();
    },
    updateDisplayedImages() {
      if (this.showMore) {
        this.displayedImageList = this.imageList; // 显示全部图片
      } else {
        this.displayedImageList = this.imageList.slice(0, this.maxDisplayCount); // 仅显示前maxDisplayCount张图片
      }
    },
    async getVolunteerContent() {
      try {
        const { username, gardenname, location, describe, imageUrl } = await getVolunteerContent();
        this.volunteerContent.username = username;
        this.volunteerContent.gardenname = gardenname;
        this.volunteerContent.location = location;
        this.volunteerContent.describe = describe;
        this.volunteerContent.imageUrl = imageUrl;
      }
      catch (error) {
        console.error('Error', error);
      }
    },
    async getVolunteerList() {
      try {
        const { username, Points } = await getVolunteerList();
        this.getVolunteerList.username = username;
        this.getVolunteerList.myPoints = Points;
      }
      catch (error) {
        console.error('Error', error);
      }
    },
    async submitForm() {
      try {
        const response = await submitForm();
        console.log('Data saved:', response.data);
        // 清空表单
        this.volunteerDialog.volunteername = '';
        this.formData.email = '';
      } catch (error) {
        console.error('Error', error);
      }
    }
  },
  created() {
    this.updateDisplayedImages(); // 初始化时根据showMore状态设置图片数量
  },
};
</script>
