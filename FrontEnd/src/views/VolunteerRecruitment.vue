<template>
  <body>
    <div class="container">
      <NavBar />
      <!-- 导航栏 -->

      <el-row id="mainpart">
        <SideBar />
        <!-- 侧边栏 -->

        <!-- 志愿者招募 -->
        <el-col :span="13">
          <el-container>
            <!-- 标题 -->
            <el-header class="heading-field">
              <h1 class="heading">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="44"
                  fill="currentColor"
                  class="bi bi-person-lines-fill"
                  viewBox="0 0 16 16"
                >
                  <path
                    d="M6 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm-5 6s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H1zM11 3.5a.5.5 0 0 1 .5-.5h4a.5.5 0 0 1 0 1h-4a.5.5 0 0 1-.5-.5zm.5 2.5a.5.5 0 0 0 0 1h4a.5.5 0 0 0 0-1h-4zm2 3a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1h-2zm0 3a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1h-2z"
                  />
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
                <!-- 报名按钮 -->
                <button
                  class="btn btn-outline-secondary"
                  @click="volunteerDialog.dialogVisible = true"
                >
                  {{ "我要报名" }}
                </button>
                <!-- 进入按钮 -->
                <button
                  class="btn btn-outline-secondary"
                  @click="this.$router.push({name: 'garden', params: { garden_id: content.garden_id }})"
                >
                  {{ "进入花园" }}
                </button>
              </div>

              <!--报名弹窗-->
              <el-dialog v-model="volunteerDialog.dialogVisible" title="报名表">
                <el-form :model="form">
                  <el-form-item label="你的学号" :label-width="formLabelWidth">
                    <el-input
                      v-model="volunteerDialog.volunteerid"
                      style="width: 140px"
                      autocomplete="off"
                    />
                  </el-form-item>
                  <el-form-item label="你的名字" :label-width="formLabelWidth">
                    <el-input
                      v-model="volunteerDialog.volunteername"
                      style="width: 140px"
                      autocomplete="off"
                    />
                  </el-form-item>
                  <el-form-item label="电话号码" :label-width="formLabelWidth">
                    <el-input
                      v-model="volunteerDialog.phonenumber"
                      style="width: 200px"
                      autocomplete="off"
                    />
                  </el-form-item>
                  <el-form-item label="选择日期" :label-width="formLabelWidth">
                    <el-select
                      v-model="volunteerDialog.dayOfWeek"
                      class="m-2"
                      placeholder="星期"
                    >
                      <el-option
                        v-for="item in week"
                        :key="item.value"
                        :label="item.label"
                        :value="item.value"
                      />
                    </el-select>
                    <el-time-select
                      v-model="volunteerDialog.time"
                      start="08:30"
                      step="00:15"
                      end="18:30"
                      placeholder="选择时间"
                    />
                  </el-form-item>
                  <el-form-item label="自我描述" :label-width="formLabelWidth">
                    <el-input
                      v-model="volunteerDialog.describe"
                      :autosize="{ minRows: 2, maxRows: 10 }"
                      type="textarea"
                      placeholder="here"
                    />
                    <div style="margin: 20px 0" />
                  </el-form-item>
                </el-form>
                <template #footer>
                  <span class="dialog-footer">
                    <el-button @click="volunteerDialog.dialogVisible = false">
                      Cancel
                    </el-button>
                    <el-button type="primary" @click="postApply">
                      Confirm
                    </el-button>
                  </span>
                </template>
              </el-dialog>
            </div>

            <!-- 加载更多、我要发布按钮 -->
            <div>
              <button @click="loadRecruits" class="btn btn-outline-success show-more-btn">
                加载更多
              </button>
              <button @click="this.$router.push('/VolunteerPost')" class="btn btn-outline-success show-more-btn">
                我要发布
              </button>
            </div>
          </el-container>
        </el-col>

        <!-- 志愿工作榜 -->
        <el-col :span="8">
          <el-container>
            <!-- 标题 -->
            <el-header class="heading-field">
              <h1 class="heading">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="44"
                  fill="currentColor"
                  class="bi bi-list-ul"
                  viewBox="0 0 16 16"
                >
                  <path
                    fill-rule="evenodd"
                    d="M5 11.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zm0-4a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zm0-4a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zm-3 1a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm0 4a1 1 0 1 0 0-2 1 1 0 0 0 0 2zm0 4a1 1 0 1 0 0-2 1 1 0 0 0 0 2z"
                  />
                </svg>
                &nbsp;志愿工作榜
              </h1>
            </el-header>

            <el-main>
              <el-col v-for="(item, index) in displayedImageList" :key="index">
                <div
                  class="card volunteer-list"
                  @click="
                    this.$router.push({
                      name: 'personalInfo',
                      params: { id: item.userId },
                    })
                  "
                >
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

              <button
                class="btn btn-secondary"
                @click="toggleShowMore"
                style="margin-top: 10px"
              >
                {{ showMore ? "收起" : "显示更多" }}
              </button>
            </el-main>
          </el-container>
        </el-col>
      </el-row>
    </div>
  </body>
</template>

<script>
import {
  getVolunteerList,
  getVolunteerContent,
  submitForm,
  getMoreRecruits,
  getTopPointsList,
} from "../api/VolunteerAPI";
import { getUserNameById, getUserAvatarById } from '@/api/accountApi';
import { getGardenInfo } from '@/api/gardenAPI';

export default {
  el: "#mainpart",
  created() {
    this.loadRecruits();
    this.GetTopPointsList();
    this.showMore = true;
    this.updateDisplayedImages(); // 初始化时根据showMore状态设置图片数量
  },
  data() {
    return {
      // 右侧 志愿工作榜
      showMore: false, // 控制是否显示更多
      displayedImageList: [], // 实际显示的列表
      maxDisplayCount: 3, // 默认显示的数量
      imageList: [],
      
      volunteerContent: [ ],
      volunteerDialog: [
        {
          dialogVisible: false, //是否出现弹窗
          ownername: "Student1",
          volunteerid: "",
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

      //新增的页面控制数据
      state: {
        startNum: 0,
        pageSize: 5,
      },
    };
  },
  methods: {
    async loadRecruits() {
      var that = this;
      getMoreRecruits(that.state.startNum, that.state.pageSize).then(
        function (res) {
          console.log("获取更多招募成功", res);
          that.state.startNum += that.state.pageSize;

          //处理data形式数据的更改异步问题
          const promises = res.map(async (recruit) => {
            const card = await that.toCard(recruit);
            return card;
          });

          Promise.all(promises).then((cards) => {
            that.volunteerContent.push(...cards);
            console.log("转换后：", that.volunteerContent);
          });
        },
        function (err) {
          console.log("获取更多招募失败", err);
        }
      );
    },

    async toCard(recruit) {
      const username = await getUserNameById(recruit.recruiterId);
      const avatar = await getUserAvatarById(recruit.recruiterId);
      const gardenInfo = await getGardenInfo(recruit.gardenId);
      const gardenImage = gardenInfo.pictures;
      const gardenName = gardenInfo.name;
      const gardenLocation = gardenInfo.position;
      var card = {
        dialogVisible: false,
        imageUrl: gardenImage,
        username: username, //返回花园的拥有者
        avatar: avatar,
        userid: recruit.recruiterId,
        garden_id: recruit.gardenId,
        gardenname: gardenName, //返回花园的名字
        gardenid: recruit.gardenId,
        location: gardenLocation, //这里应该返回花园的位置
        describe: recruit.recruitContent,
        recruittime: recruit.recruitTime,
      };
      return card;
    },

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
        const { username, gardenname, location, describe, imageUrl } =
          await getVolunteerContent();
        this.volunteerContent.username = username;
        this.volunteerContent.gardenname = gardenname;
        this.volunteerContent.location = location;
        this.volunteerContent.describe = describe;
        this.volunteerContent.imageUrl = imageUrl;
      } catch (error) {
        console.error("Error", error);
      }
    },
    async getVolunteerList() {
      const { username, Points } = await getVolunteerList();
      this.getVolunteerList.username = username;
      this.getVolunteerList.myPoints = Points;
    },
    
    //积分排名名单的card转换
    async toUserCard(user, topnum) {
      var card = {
        userId: user.accountId,
        description: "TOP" + topnum,
        username: user.accountName,
        myPoints: user.points,
      };
      return card;
    },

    //提交报名申请
    async postApply() {
      this.volunteerDialog.dialogVisible = false;

      var that = this;
      //前后端交互
      submitForm(
        that.volunteerDialog.volunteerid,
        that.volunteerDialog.describe
      ).then(
        function (res) {
          alert(res);
          console.log("申请成功");
        },
        function (err) {
          alert(err);
          console.log("申请失败");
        }
      );
    },

    //获取积分排名前十的函数
    async GetTopPointsList() {
      console.log("开始积分排名读取");
      var that = this;
      getTopPointsList().then(
        function (res) {
          //处理data形式数据的更改异步问题
          const promises = res.map(async (item, index) => {
            // 使用index + 1作为排名
            const card = await that.toUserCard(item, index + 1);
            return card;
          });

          Promise.all(promises).then((cards) => {
            that.imageList.push(...cards);
            console.log("转换后：", that.imageList);
          });

          console.log("获取排名成功", res);
        },
        function (err) {
          console.log("获取排名失败", err);
        }
      );
    },
  },
  
};
</script>


<style scoped>
body {
  background-color: rgb(245, 235, 226);
  background-image: url("../assets/img-volunteer.jpg");
  background-size: 30vw;
  background-repeat: no-repeat;
  position: relative;
  background-position: 65vw 35vh;
  background-attachment: fixed;
}

.container {
  margin-top: 60px;
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

.show-more-btn {
  margin: 2vh auto 10vh 0vh;
  margin-left: 3vh;
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
