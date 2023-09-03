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

        <!-- 主体内容 -->
        <div class="col-8">
          <!-- 标题卡片 -->
          <div class="card heading-card">
            <div class="card-body">
              <!-- 图标 -->
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="70"
                fill="currentColor"
                class="bi bi-balloon"
                viewBox="0 0 16 16"
              >
                <path
                  fill-rule="evenodd"
                  d="M8 9.984C10.403 9.506 12 7.48 12 5a4 4 0 0 0-8 0c0 2.48 1.597 4.506 4 4.984ZM13 5c0 2.837-1.789 5.227-4.52 5.901l.244.487a.25.25 0 1 1-.448.224l-.008-.017c.008.11.02.202.037.29.054.27.161.488.419 1.003.288.578.235 1.15.076 1.629-.157.469-.422.867-.588 1.115l-.004.007a.25.25 0 1 1-.416-.278c.168-.252.4-.6.533-1.003.133-.396.163-.824-.049-1.246l-.013-.028c-.24-.48-.38-.758-.448-1.102a3.177 3.177 0 0 1-.052-.45l-.04.08a.25.25 0 1 1-.447-.224l.244-.487C4.789 10.227 3 7.837 3 5a5 5 0 0 1 10 0Zm-6.938-.495a2.003 2.003 0 0 1 1.443-1.443C7.773 2.994 8 2.776 8 2.5c0-.276-.226-.504-.498-.459a3.003 3.003 0 0 0-2.46 2.461c-.046.272.182.498.458.498s.494-.227.562-.495Z"
                />
              </svg>

              <!-- 图片 -->
              &emsp;<img
                src="../assets/GardenAct-logo.png"
                style="display: inline-block; width: 20vw"
              />&emsp;

              <!-- 图标 -->
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="70"
                fill="currentColor"
                class="bi bi-balloon"
                viewBox="0 0 16 16"
              >
                <path
                  fill-rule="evenodd"
                  d="M8 9.984C10.403 9.506 12 7.48 12 5a4 4 0 0 0-8 0c0 2.48 1.597 4.506 4 4.984ZM13 5c0 2.837-1.789 5.227-4.52 5.901l.244.487a.25.25 0 1 1-.448.224l-.008-.017c.008.11.02.202.037.29.054.27.161.488.419 1.003.288.578.235 1.15.076 1.629-.157.469-.422.867-.588 1.115l-.004.007a.25.25 0 1 1-.416-.278c.168-.252.4-.6.533-1.003.133-.396.163-.824-.049-1.246l-.013-.028c-.24-.48-.38-.758-.448-1.102a3.177 3.177 0 0 1-.052-.45l-.04.08a.25.25 0 1 1-.447-.224l.244-.487C4.789 10.227 3 7.837 3 5a5 5 0 0 1 10 0Zm-6.938-.495a2.003 2.003 0 0 1 1.443-1.443C7.773 2.994 8 2.776 8 2.5c0-.276-.226-.504-.498-.459a3.003 3.003 0 0 0-2.46 2.461c-.046.272.182.498.458.498s.494-.227.562-.495Z"
                />
              </svg>
            </div>
          </div>

          <!-- 活动卡片 -->
          <div
            class="card activity-card"
            v-for="(card, index) in GardenAct"
            :key="index"
          >
            <GardenActivityBlock :card="card" />
          </div>
        </div>
      </div>
    </div>
  </body>
</template>

<script>
export default {
  data() {
    return {
      GardenAct: [
        {
          author: "楚杰",
          title: "杰哥的安楼自习室",
          avatar: require("../assets/author-avatar.jpg"),
          imageurl: require("../assets/Garden.jpg"),
          time: "2020年1月1日",
          address: "安楼后面的小树林",
          detail: "给你看点好康的",
        },
        {
          author: "楚杰",
          title: "杰哥的安楼自习室",
          avatar: require("../assets/author-avatar.jpg"),
          imageurl: require("../assets/Garden.jpg"),
          time: "2020年1月1日",
          address: "安楼后面的小树林",
          detail: "给你看点好康的",
        },
        {
          author: "楚杰",
          title: "杰哥的安楼自习室",
          avatar: require("../assets/author-avatar.jpg"),
          imageurl: require("../assets/Garden.jpg"),
          time: "2020年1月1日",
          address: "安楼后面的小树林",
          detail: "给你看点好康的",
        },
        {
          author: "楚杰",
          title: "杰哥的安楼自习室",
          avatar: require("../assets/author-avatar.jpg"),
          imageurl: require("../assets/Garden.jpg"),
          time: "2020年1月1日",
          address: "安楼后面的小树林",
          detail: "给你看点好康的",
        },
        {
          author: "楚杰",
          title: "杰哥的安楼自习室",
          avatar: require("../assets/author-avatar.jpg"),
          imageurl: require("../assets/Garden.jpg"),
          time: "2020年1月1日",
          address: "安楼后面的小树林",
          detail: "给你看点好康的",
        },
      ],
    };
  },
};
</script>

<style scoped>
body {
  background-color: rgb(244, 237, 228);
  background-image: url("../assets/img-activity.jpg");
  background-size: 25vw;
  background-repeat: no-repeat;
  position: relative;
  background-position: right;
  background-attachment: fixed;
}

.container {
  margin-top: 60px;
}

.col-8 {
  padding: 3vh;
}

.heading-card {
  /* background-color: rgb(228, 220, 220); */
  border-width: 0vh;
  border-radius: 2vh;

  margin-bottom: 3vh;

  color: rgb(4, 145, 59);
  background-color: rgb(244, 237, 228);
  box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);

  text-align: center;
  user-select: none;
  position: relative;

  animation: slide-in-from-top 1s;
}

.heading-card:hover {
  transform: scale(1.02);
  transition: 1000ms;
}

@keyframes slide-in-from-top {
  from {
    transform: translateY(-100%);
  }

  to {
    transform: translateY(0);
  }
}

.activity-card {
  padding: 2vh;

  border-width: 0vh;
  border-radius: 2vh;

  box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
  background-color: rgb(244, 237, 228);

  margin-top: 6vh;
  margin-bottom: 6vh;

  animation: slide-in-from-bottom 2s;
}

@keyframes slide-in-from-bottom {
  from {
    transform: translateY(100%);
  }

  to {
    transform: translateY(0);
  }
}

.user-heading {
  font-size: 3vh;
  font-weight: bold;
  color: rgb(12, 60, 38);
}

.author-avatar-img {
  cursor: pointer;
  width: 50px;
  height: 50px;
  border-radius: 50%;
  object-fit: cover;
}

.author-avatar-img:hover {
  transform: scale(1.2);
  transition: 1000ms;
}

.colored-line {
  height: 1px;
  background-color: rgb(12, 60, 38);
  margin-top: 2vh;
  margin-bottom: 2vh;
}

.activity-heading {
  font-size: 3vh;
  font-weight: bold;
  color: rgb(12, 60, 38);
  cursor: pointer;
}

.images-left-col {
  padding-top: 2vh;
  padding-bottom: 2vh;
  padding-left: 0vw;
  padding-right: 0.5vw;
}

.images-right-col {
  padding-top: 2vh;
  padding-bottom: 2vh;
  padding-right: 0vw;
  padding-left: 0.5vw;
}

.img-fluid {
  padding: 0vh;
  width: 100%;
  cursor: pointer;
}

.activity-text {
  font-size: 2vh;
  font-weight: bold;
  color: rgb(99, 110, 115);
  margin-top: 2vh;
  margin-bottom: 2vh;
}

.button-container {
  text-align: center;
}

button {
  margin: 1vh;
}

button:hover {
  transform: scale(1.2);
  transition: 1000ms;
}
</style>