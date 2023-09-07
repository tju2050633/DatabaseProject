<template>
  <div>
    <div class="card-body">
      <!-- 用户信息 -->
      <h4 class="user-heading">
        <!-- 头像 -->
        <img
          class="author-avatar-img"
          :src="item.avatar"
          @click="this.$router.push({name: 'personalInfo', params: { id: item.holder_id }})"
          alt="作者头像"
        />
        <!-- 用户名 -->
        {{ item.author }}
      </h4>

      <!-- 分隔线 -->
      <div class="colored-line"></div>

      <!-- 活动标题 -->
      <div class="activity-heading" @click="this.$router.push({name: 'garden', params: { garden_id: item.garden_id }})">
        <!-- 图标 -->
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="30"
          height="30"
          fill="currentColor"
          class="bi bi-bookmark-check"
          viewBox="0 0 16 16"
        >
          <path
            fill-rule="evenodd"
            d="M10.854 5.146a.5.5 0 0 1 0 .708l-3 3a.5.5 0 0 1-.708 0l-1.5-1.5a.5.5 0 1 1 .708-.708L7.5 7.793l2.646-2.647a.5.5 0 0 1 .708 0z"
          />
          <path
            d="M2 2a2 2 0 0 1 2-2h8a2 2 0 0 1 2 2v13.5a.5.5 0 0 1-.777.416L8 13.101l-5.223 2.815A.5.5 0 0 1 2 15.5V2zm2-1a1 1 0 0 0-1 1v12.566l4.723-2.482a.5.5 0 0 1 .554 0L13 14.566V2a1 1 0 0 0-1-1H4z"
          />
        </svg>
        {{ item.title }}
      </div>

      <!-- 活动图片 -->
      <div class="container text-center">
        <img
          :src="item.imageurl"
          class="img-fluid"
          alt="花园"
          @click="this.$router.push({name: 'garden', params: { garden_id: item.garden_id }})"
        />
      </div>

      <!-- 具体信息 -->
      <p class="activity-text">
        <!-- 图标 -->
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="20"
          height="20"
          fill="currentColor"
          class="bi bi-calendar-check"
          viewBox="0 0 16 16"
        >
          <path
            d="M10.854 7.146a.5.5 0 0 1 0 .708l-3 3a.5.5 0 0 1-.708 0l-1.5-1.5a.5.5 0 1 1 .708-.708L7.5 9.793l2.646-2.647a.5.5 0 0 1 .708 0z"
          />
          <path
            d="M3.5 0a.5.5 0 0 1 .5.5V1h8V.5a.5.5 0 0 1 1 0V1h1a2 2 0 0 1 2 2v11a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V3a2 2 0 0 1 2-2h1V.5a.5.5 0 0 1 .5-.5zM1 4v10a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V4H1z"
          />
        </svg>
        &ensp;时间：{{ item.time }}
      </p>
      <p class="activity-text">
        <!-- 图标 -->
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="20"
          height="20"
          fill="currentColor"
          class="bi bi-geo-alt"
          viewBox="0 0 16 16"
        >
          <path
            d="M12.166 8.94c-.524 1.062-1.234 2.12-1.96 3.07A31.493 31.493 0 0 1 8 14.58a31.481 31.481 0 0 1-2.206-2.57c-.726-.95-1.436-2.008-1.96-3.07C3.304 7.867 3 6.862 3 6a5 5 0 0 1 10 0c0 .862-.305 1.867-.834 2.94zM8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10z"
          />
          <path
            d="M8 8a2 2 0 1 1 0-4 2 2 0 0 1 0 4zm0 1a3 3 0 1 0 0-6 3 3 0 0 0 0 6z"
          />
        </svg>
        &ensp;地点：{{ item.address }}
      </p>
      <p class="activity-text">
        <!-- 图标 -->
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="20"
          height="20"
          fill="currentColor"
          class="bi bi-card-text"
          viewBox="0 0 16 16"
        >
          <path
            d="M14.5 3a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-13a.5.5 0 0 1-.5-.5v-9a.5.5 0 0 1 .5-.5h13zm-13-1A1.5 1.5 0 0 0 0 3.5v9A1.5 1.5 0 0 0 1.5 14h13a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-13z"
          />
          <path
            d="M3 5.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zM3 8a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9A.5.5 0 0 1 3 8zm0 2.5a.5.5 0 0 1 .5-.5h6a.5.5 0 0 1 0 1h-6a.5.5 0 0 1-.5-.5z"
          />
        </svg>
        &ensp;细节：{{ item.detail }}
      </p>

      <!-- 分隔线 -->
      <div class="colored-line"></div>

      <!-- 按钮 -->
      <div class="button-container">
        <button class="btn btn-success" @click="this.$router.push({name: 'garden', params: { garden_id: item.garden_id }})">
          查看详情
        </button>
        <button class="btn btn-success">
          报名参加
        </button>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  props: ["card"],

  data() {
    return {
      item: { ...this.card },
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