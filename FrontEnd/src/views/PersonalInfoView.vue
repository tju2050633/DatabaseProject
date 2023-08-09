<template>
  <body>
    <div class="container" style="margin-top: 60px">
      <!-- 导航栏 -->
      <NavBar />

      <div class="common-layout">
        <el-container class="personalinfo" style="height: 100vw">
          <el-container>
            <!-- 侧边栏 -->
            <SideBar />

            <!-- 主体 -->
            <el-container class="info">
              <el-main>
                <!-- 头图 -->
                <el-row class="top-image" body-style="heigh:500px ">
                  <el-col :span="24">
                    <el-image
                      style="width: 100vw; height: 30vh"
                      :src="url"
                      :fit="fill"
                    />
                  </el-col>
                </el-row>

                <!-- 头像+自述+修改信息按钮 -->
                <el-row :gutter="20">
                  <el-col :span="4">
                    <el-avatar :size="250" :src="avaUrl" />
                    <span class="spaninfohead" style="margin-left: 100px">{{
                      UserInfo.name
                    }}</span>
                  </el-col>

                  <el-col :span="16"
                    ><br /><br /><br /><br /><br />
                    <span class="spaninfohead" style="margin-left: 100px"
                      >个人描述：</span
                    >
                    <el-row style="margin-left: 100px">
                      <span v-if="!change" style="text-align: center">{{
                        UserInfo.Description
                      }}</span>
                      <el-input
                        class="username-change"
                        style="font-size: large"
                        v-if="change"
                        v-model="UserInfo.Description"
                        @change="InfoHasChanged()"
                    /></el-row>
                  </el-col>
                  <el-col :span="4"
                    ><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><el-button
                      type="info"
                      @click="changeInfo"
                      >修改信息</el-button
                    ></el-col
                  >
                </el-row>
                <br />

                <!-- 个人信息 -->
                <el-card style="width=50vw">
                  <!-- 邮箱+注册时间 -->
                  <el-row :gutter="30">
                    <el-col :span="12"
                      ><span class="spaninfohead">邮箱：</span>
                      <el-row>
                        <span v-if="!change">{{ UserInfo.email }}</span>
                        <el-input
                          class="email-change"
                          v-if="change"
                          v-model="UserInfo.email"
                          @change="InfoHasChanged()"
                        />
                      </el-row>
                    </el-col>
                    <el-col :span="12"
                      ><span class="spaninfohead">注册时间：</span>
                      <el-row
                        ><span>{{ UserInfo.registerTime }}</span></el-row
                      >
                    </el-col>
                  </el-row>

                  <!-- 积分+手机号 -->
                  <el-row :gutter="30">
                    <el-col :span="12"
                      ><span class="spaninfohead">积分：</span>
                      <el-row
                        ><span>{{ UserInfo.points }}</span></el-row
                      >
                    </el-col>
                    <el-col :span="12">
                      <el-row>
                        <el-col :span="12"
                          ><el-button
                            type="info"
                            icon="Lock"
                            circle
                            size="medium"
                            @click="ifshowTel" /><span class="spaninfohead"
                            >手机号：</span
                          >
                          <el-row v-if="!change"
                            ><span v-if="showtel && !change">{{
                              UserInfo.tel
                            }}</span>
                            <span v-if="!showtel && !change">***</span></el-row
                          >
                          <el-input
                            class="tel-change"
                            v-if="change"
                            v-model="UserInfo.tel"
                            @change="InfoHasChanged()"
                        /></el-col>
                      </el-row>
                    </el-col>
                  </el-row>
                </el-card>

                <!-- 标签栏 -->

                <br /><br />

                <el-row :gutter="30">
                  <el-col :offset="0">
                    <el-breadcrumb separator="|">
                      <el-breadcrumb-item
                        :to="{}"
                        class="navtag"
                      ></el-breadcrumb-item>
                      <el-breadcrumb-item
                        :to="{}"
                        @click="refresh(1)"
                        :class="{ active: chooseComponent === 1 }"
                        class="navtag"
                        >互动</el-breadcrumb-item
                      >
                      <el-breadcrumb-item
                        :to="{}"
                        @click="refresh(2)"
                        :class="{ active: chooseComponent === 2 }"
                        class="navtag"
                        >博客</el-breadcrumb-item
                      >
                      <el-breadcrumb-item
                        :to="{}"
                        @click="refresh(3)"
                        :class="{ active: chooseComponent === 3 }"
                        class="navtag"
                        >花园</el-breadcrumb-item
                      >
                      <el-breadcrumb-item
                        :to="{}"
                        @click="refresh(4)"
                        :class="{ active: chooseComponent === 4 }"
                        class="navtag"
                        >工作记录</el-breadcrumb-item
                      >
                      <el-breadcrumb-item
                        :to="{}"
                        class="navtag"
                      ></el-breadcrumb-item>
                    </el-breadcrumb>
                  </el-col>
                </el-row>

                <!-- 功能页 -->
                <el-container class="functions">
                  <!-- 互动-->
                  <div
                    class="interact"
                    style="margin-left: 150px"
                    v-if="chooseComponent == 1"
                  >
                    <!-- 互动组件 -->
                    <el-card
                      v-for="(item, index) in GardenComment"
                      :key="index"
                      style="margin-top: 20px"
                    >
                      <h2>
                        <img
                          class="author-avatar-img"
                          :src="item.avatar"
                          @click="this.$router.push('/personalInfo/')"
                          alt="作者头像"
                        />
                        <span
                          class="spaninfohead"
                          @click="this.$router.push('/personal/')"
                          >{{ item.author }}</span
                        >
                      </h2>
                      <h4>
                        <span
                          class="spaninfohead"
                          @click="this.$router.push('/personal/')"
                          >{{ item.title }}</span
                        >
                      </h4>
                      <div @click="this.$router.push('/personal/')">
                        <img :src="item.imageurl" alt="花园" class="card-img" />
                      </div>
                      <h4 style="padding-top: 20px">
                        <el-icon style="user: 10px"><User /></el-icon>
                        <span class="spaninfo"
                          >{{ UserInfo.name }}:{{ item.comment }}</span
                        >
                      </h4>
                    </el-card>
                    <br />

                    <el-card
                      v-for="(item, index) in GardenLike"
                      :key="index"
                      style="margin-top: 20px"
                    >
                      <h4><span class="spaninfohead">点赞了花园</span></h4>
                      <h2>
                        <img
                          class="author-avatar-img"
                          :src="item.avatar"
                          @click="this.$router.push('/personalInfo/')"
                          alt="作者头像"
                        />
                        <span
                          class="spaninfohead"
                          @click="this.$router.push('/personal/')"
                          >{{ item.author }}</span
                        >
                      </h2>
                      <h4>
                        <span
                          class="spaninfohead"
                          @click="this.$router.push('/personal/')"
                          >{{ item.title }}</span
                        >
                      </h4>
                      <div @click="this.$router.push('/personal/')">
                        <img :src="item.imageurl" alt="花园" class="card-img" />
                      </div>
                    </el-card>
                    <br />

                    <el-card
                      v-for="(card, index) in BlogComment"
                      :key="index"
                      class="card"
                      style="width: 52vw"
                    >
                      <div class="spaninfohead">
                        <h1 class="spaninfohead">{{ card.blogName }}</h1>
                        <img
                          class="author-avatar-img"
                          :src="card.avatar"
                          @click="this.$router.push('/personalInfo/')"
                          alt="作者头像"
                        />
                        <h2
                          class="spaninfohead"
                          @click="this.$router.push('/personalInfo/')"
                        >
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
                        <button
                          class="read-more-button"
                          @click="toggleContentBlogCom(index)"
                        >
                          {{ card.showFullContent ? "收起" : "阅读全文" }}
                        </button>
                      </div>
                      <h3 class="spaninfohead">
                        <el-icon class="spaninfohead" style="star: 10px"
                          ><Star
                        /></el-icon>
                        {{ card.totalLikes }}
                        &ensp;&ensp;&ensp;
                        <el-icon class="spaninfohead" style="chat: 10px"
                          ><ChatLineSquare
                        /></el-icon>
                        {{ card.totalComment }}
                      </h3>
                      <h4 class="spaninfo">
                        <el-row>
                          <el-icon style="user: 10px"><User /></el-icon>
                          <span>{{ UserInfo.name }}:{{ card.comment }}</span>
                        </el-row>
                      </h4>
                    </el-card>
                    <br />

                    <el-card
                      v-for="(card, index) in BlogLike"
                      :key="index"
                      class="card"
                      style="width: 52vw"
                    >
                      <h4><span class="spaninfohead">点赞了博客</span></h4>
                      <div class="card-header">
                        <h1 class="spaninfohead">{{ card.blogName }}</h1>
                        <img
                          class="author-avatar-img"
                          :src="card.avatar"
                          @click="this.$router.push('/personalInfo/')"
                          alt="作者头像"
                        />
                        <h2
                          class="spaninfohead"
                          @click="this.$router.push('/personalInfo/')"
                        >
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
                        <button
                          class="read-more-button"
                          @click="toggleContentBlogLike(index)"
                        >
                          {{ card.showFullContent ? "收起" : "阅读全文" }}
                        </button>
                        <h3 class="spaninfohead">
                          <el-icon style="star: 10px"><Star /></el-icon>
                          {{ card.totalLikes }}
                          &ensp;&ensp;&ensp;
                          <el-icon style="chat: 10px"
                            ><ChatLineSquare
                          /></el-icon>
                          {{ card.totalComment }}
                        </h3>
                      </div>
                    </el-card>
                  </div>

                  <!-- 博客 -->
                  <div
                    class="blog"
                    style="margin-left: 150px"
                    v-if="chooseComponent == 2"
                  >
                    <br />
                    <el-card
                      v-for="(card, index) in BlogLike"
                      :key="index"
                      class="card"
                      style="width: 52vw"
                    >
                      <PersonalBlogBlock :card="card" />
                    </el-card>
                  </div>

                  <!-- 花园 -->
                  <div
                    class="garden"
                    style="margin-left: 150px"
                    v-if="chooseComponent == 3"
                  >
                    <br />
                    <el-card
                      v-for="(Garden, index) in Garden"
                      :key="index"
                      class="card"
                    >
                      <PersonalGardenBlock :Garden="Garden" />
                      <br />
                    </el-card>
                  </div>

                  <!-- 工作记录 -->
                  <div
                    class="record"
                    style="margin-left: 30px"
                    v-if="chooseComponent == 4"
                  >
                    <br />
                    <el-card
                      v-for="(Record, index) in Records"
                      :key="index"
                      class="card"
                    >
                      <PersonalRecordBlock :Record="Record" />
                      <br />
                    </el-card>
                  </div>
                </el-container>
              </el-main>
            </el-container>
          </el-container>
        </el-container>
      </div>
    </div>
  </body>
</template>

<script>
export default {
  name: "PersonalInfoPage",
  data() {
    return {
      ifInfoChanged: false,
      change: false,
      showtel: true,
      chooseComponent: 1,
      url: "https://img2.baidu.com/it/u=3194475248,8547823&fm=253&fmt=auto&app=138&f=JPEG?w=800&h=500",
      avaUrl: "",
      GardenComment: [
        {
          author: "王浩",
          title: "浩哥的后宫",
          avatar: require("../assets/author-avatar.jpg"),
          imageurl: require("../assets/Garden.jpg"),
          comment: "晚上就把浩哥撅了",
        },
      ],
      GardenLike: [
        {
          author: "王浩",
          avatar: require("../assets/author-avatar.jpg"),
          title: "浩哥的后宫",
          imageurl: require("../assets/Garden.jpg"),
        },
      ],
      BlogComment: [
        {
          author: "王浩",
          avatar: require("../assets/author-avatar.jpg"),
          blogName: "只因你太美",
          partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
          fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                  这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                  一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                  所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                  成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                  baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
          showFullContent: false,
          isOpen: false,
          totalLikes: 114,
          totalComment: 514,
          comment: "晚上就把浩哥撅了",
        },
      ],
      BlogLike: [
        {
          author: "王浩",
          avatar: require("../assets/author-avatar.jpg"),
          blogName: "只因你太美",
          partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
          fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                  这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                  一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                  所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                  成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                  baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
          showFullContent: false,
          isOpen: false,
          totalLikes: 114,
          totalComment: 514,
        },
      ],
      UserInfo: {
        name: "楚杰",
        Description: "我真的不卷。。。",
        email: "123@tongji.edu.cn",
        registerTime: "2020年1月",
        tel: "123456",
        points: "114",
        id: "1919810",
      },
      Garden: [
        {
          author: "楚杰",
          title: "安楼的花园",
          cover:
            "https://img2.baidu.com/it/u=3194475248,8547823&fm=253&fmt=auto&app=138&f=JPEG?w=800&h=500",
        },
        {
          author: "楚杰",
          title: "博楼的花园",
          cover:
            "https://img2.baidu.com/it/u=3194475248,8547823&fm=253&fmt=auto&app=138&f=JPEG?w=800&h=500",
        },
      ],
      Records: [
        {
          date: "2023.1.1",
          location: "19号楼",
          partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
          fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                  这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                  一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                  所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                  成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                  baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
          showFullContent: false,
          isOpen: false,
        },
        {
          date: "2023.1.2",
          location: "B楼",
          partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
          fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                  这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                  一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                  所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                  成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                  baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
          showFullContent: false,
          isOpen: false,
        },
      ],
    };
  },
  methods: {
    changeInfo() {
      this.change = !this.change;
    },
    ifshowTel() {
      this.showtel = !this.showtel;
    },
    refresh(index) {
      this.chooseComponent = index; //通过v-if 展示四个不同的组件 还没写
    },
    InfoHasChanged() {
      alert("信息改变！");
      //此处应该向后端发送请求修改数据
    },
    toggleContentBlogLike(index) {
      this.BlogLike[index].showFullContent =
        !this.BlogLike[index].showFullContent;
    },
    toggleContentBlogCom(index) {
      this.BlogComment[index].showFullContent =
        !this.BlogComment[index].showFullContent;
    },
    toggleContent(index) {
      this.Records[index].showFullContent =
        !this.Records[index].showFullContent;
    },
  },
};
</script>

<style scoped>
@import url("../css/personalInfo.css");
</style>
