<template>
    <!-- 导航栏 -->
    <NavBar />

    <body>
        <br>
        <br>
        <br>
        <br>

        <!-- 整体布局 -->
        <div class="d-flex">
            <div class="row" style="width: 100%;">

                <!-- 侧边栏 -->
                <div class="col-2">
                    <SideBar />
                </div>

                <!-- 主体内容 -->
                <div class="col-10">

                    <!-- 标题卡片 -->
                    <div class="card heading-card">
                        <div class="card-body">
                            <!-- 图标 -->
                            <svg xmlns="http://www.w3.org/2000/svg" width="70" fill="currentColor" class="bi bi-balloon"
                                viewBox="0 0 16 16">
                                <path fill-rule="evenodd"
                                    d="M8 9.984C10.403 9.506 12 7.48 12 5a4 4 0 0 0-8 0c0 2.48 1.597 4.506 4 4.984ZM13 5c0 2.837-1.789 5.227-4.52 5.901l.244.487a.25.25 0 1 1-.448.224l-.008-.017c.008.11.02.202.037.29.054.27.161.488.419 1.003.288.578.235 1.15.076 1.629-.157.469-.422.867-.588 1.115l-.004.007a.25.25 0 1 1-.416-.278c.168-.252.4-.6.533-1.003.133-.396.163-.824-.049-1.246l-.013-.028c-.24-.48-.38-.758-.448-1.102a3.177 3.177 0 0 1-.052-.45l-.04.08a.25.25 0 1 1-.447-.224l.244-.487C4.789 10.227 3 7.837 3 5a5 5 0 0 1 10 0Zm-6.938-.495a2.003 2.003 0 0 1 1.443-1.443C7.773 2.994 8 2.776 8 2.5c0-.276-.226-.504-.498-.459a3.003 3.003 0 0 0-2.46 2.461c-.046.272.182.498.458.498s.494-.227.562-.495Z" />
                            </svg>

                            <!-- 图片 -->
                            &emsp;<img src="../assets/GardenAct-logo.png" style="display: inline-block; width: 20vw;">&emsp;

                            <!-- 图标 -->
                            <svg xmlns="http://www.w3.org/2000/svg" width="70" fill="currentColor" class="bi bi-balloon"
                                viewBox="0 0 16 16">
                                <path fill-rule="evenodd"
                                    d="M8 9.984C10.403 9.506 12 7.48 12 5a4 4 0 0 0-8 0c0 2.48 1.597 4.506 4 4.984ZM13 5c0 2.837-1.789 5.227-4.52 5.901l.244.487a.25.25 0 1 1-.448.224l-.008-.017c.008.11.02.202.037.29.054.27.161.488.419 1.003.288.578.235 1.15.076 1.629-.157.469-.422.867-.588 1.115l-.004.007a.25.25 0 1 1-.416-.278c.168-.252.4-.6.533-1.003.133-.396.163-.824-.049-1.246l-.013-.028c-.24-.48-.38-.758-.448-1.102a3.177 3.177 0 0 1-.052-.45l-.04.08a.25.25 0 1 1-.447-.224l.244-.487C4.789 10.227 3 7.837 3 5a5 5 0 0 1 10 0Zm-6.938-.495a2.003 2.003 0 0 1 1.443-1.443C7.773 2.994 8 2.776 8 2.5c0-.276-.226-.504-.498-.459a3.003 3.003 0 0 0-2.46 2.461c-.046.272.182.498.458.498s.494-.227.562-.495Z" />
                            </svg>
                        </div>
                    </div>

                    <!-- 活动卡片 -->
                    <div class="card activity-card" v-for="(item, index) in GardenAct" :key="index">
                        <div class="card-body">
                            <!-- 用户信息 -->
                            <h4 class="user-heading">
                                <!-- 头像 -->
                                <img class="author-avatar-img" :src="item.avatar"
                                    @click="this.$router.push('/personalInfo/')" alt="作者头像">
                                <!-- 用户名 -->
                                {{ item.author }}
                            </h4>

                            <div class="colored-line"></div> <!-- 分隔线 -->

                            <!-- 活动标题 -->
                            <div class="activity-heading" @click="this.$router.push('/personal/')">
                                <!-- 图标 -->
                                <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor"
                                    class="bi bi-bookmark-check" viewBox="0 0 16 16">
                                    <path fill-rule="evenodd"
                                        d="M10.854 5.146a.5.5 0 0 1 0 .708l-3 3a.5.5 0 0 1-.708 0l-1.5-1.5a.5.5 0 1 1 .708-.708L7.5 7.793l2.646-2.647a.5.5 0 0 1 .708 0z" />
                                    <path
                                        d="M2 2a2 2 0 0 1 2-2h8a2 2 0 0 1 2 2v13.5a.5.5 0 0 1-.777.416L8 13.101l-5.223 2.815A.5.5 0 0 1 2 15.5V2zm2-1a1 1 0 0 0-1 1v12.566l4.723-2.482a.5.5 0 0 1 .554 0L13 14.566V2a1 1 0 0 0-1-1H4z" />
                                </svg>
                                {{ item.title }}
                            </div>

                            <!-- 活动图片 -->
                            <!-- 网格布局 -->
                            <div class="container text-center">
                                <div class="row row-cols-2">
                                    <div class="col images-left-col">
                                        <img :src="item.imageurl" class="img-fluid" alt="花园"
                                            @click="this.$router.push('/personal/')">
                                    </div>
                                    <div class="col images-right-col">
                                        <img :src="item.imageurl" class="img-fluid" alt="花园"
                                            @click="this.$router.push('/personal/')">
                                    </div>
                                </div>
                            </div>

                            <!-- 具体信息 -->
                            <p class="activity-text">
                                <!-- 图标 -->
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor"
                                    class="bi bi-calendar-check" viewBox="0 0 16 16">
                                    <path
                                        d="M10.854 7.146a.5.5 0 0 1 0 .708l-3 3a.5.5 0 0 1-.708 0l-1.5-1.5a.5.5 0 1 1 .708-.708L7.5 9.793l2.646-2.647a.5.5 0 0 1 .708 0z" />
                                    <path
                                        d="M3.5 0a.5.5 0 0 1 .5.5V1h8V.5a.5.5 0 0 1 1 0V1h1a2 2 0 0 1 2 2v11a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V3a2 2 0 0 1 2-2h1V.5a.5.5 0 0 1 .5-.5zM1 4v10a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V4H1z" />
                                </svg>
                                &ensp;时间：{{ item.time }}
                            </p>
                            <p class="activity-text">
                                <!-- 图标 -->
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor"
                                    class="bi bi-geo-alt" viewBox="0 0 16 16">
                                    <path
                                        d="M12.166 8.94c-.524 1.062-1.234 2.12-1.96 3.07A31.493 31.493 0 0 1 8 14.58a31.481 31.481 0 0 1-2.206-2.57c-.726-.95-1.436-2.008-1.96-3.07C3.304 7.867 3 6.862 3 6a5 5 0 0 1 10 0c0 .862-.305 1.867-.834 2.94zM8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10z" />
                                    <path d="M8 8a2 2 0 1 1 0-4 2 2 0 0 1 0 4zm0 1a3 3 0 1 0 0-6 3 3 0 0 0 0 6z" />
                                </svg>
                                &ensp;地点：{{ item.address }}
                            </p>
                            <p class="activity-text">
                                <!-- 图标 -->
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor"
                                    class="bi bi-card-text" viewBox="0 0 16 16">
                                    <path
                                        d="M14.5 3a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-13a.5.5 0 0 1-.5-.5v-9a.5.5 0 0 1 .5-.5h13zm-13-1A1.5 1.5 0 0 0 0 3.5v9A1.5 1.5 0 0 0 1.5 14h13a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-13z" />
                                    <path
                                        d="M3 5.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zM3 8a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9A.5.5 0 0 1 3 8zm0 2.5a.5.5 0 0 1 .5-.5h6a.5.5 0 0 1 0 1h-6a.5.5 0 0 1-.5-.5z" />
                                </svg>
                                &ensp;细节：{{ item.detail }}
                            </p>

                            <div class="colored-line"></div> <!-- 分隔线 -->

                            <!-- 按钮 -->
                            <div class='button-container'>
                                <button class="btn btn-success" @click="this.$router.push('/garden/')">查看详情</button>
                                <button class="btn btn-success">报名参加</button>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>

        <br>
        <br>
        <br>
    </body>
</template>

<script>
export default {
    data() {
        return {
            GardenAct: [
                {
                    author: '楚杰',
                    title: '杰哥的安楼自习室',
                    avatar: require('../assets/author-avatar.jpg'),
                    imageurl: require('../assets/Garden.jpg'),
                    time: '2020年1月1日',
                    address: '安楼后面的小树林',
                    detail: '给你看点好康的'
                },
                {
                    author: '楚杰',
                    title: '杰哥的安楼自习室',
                    avatar: require('../assets/author-avatar.jpg'),
                    imageurl: require('../assets/Garden.jpg'),
                    time: '2020年1月1日',
                    address: '安楼后面的小树林',
                    detail: '给你看点好康的'
                },
                {
                    author: '楚杰',
                    title: '杰哥的安楼自习室',
                    avatar: require('../assets/author-avatar.jpg'),
                    imageurl: require('../assets/Garden.jpg'),
                    time: '2020年1月1日',
                    address: '安楼后面的小树林',
                    detail: '给你看点好康的'
                },
                {
                    author: '楚杰',
                    title: '杰哥的安楼自习室',
                    avatar: require('../assets/author-avatar.jpg'),
                    imageurl: require('../assets/Garden.jpg'),
                    time: '2020年1月1日',
                    address: '安楼后面的小树林',
                    detail: '给你看点好康的'
                },
                {
                    author: '楚杰',
                    title: '杰哥的安楼自习室',
                    avatar: require('../assets/author-avatar.jpg'),
                    imageurl: require('../assets/Garden.jpg'),
                    time: '2020年1月1日',
                    address: '安楼后面的小树林',
                    detail: '给你看点好康的'
                }
            ]
        }
    }
}
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

.d-flex {
    margin-left: 10vw;
    width: 65vw;
}

.heading-card {
    border-width: 0vh;
    border-radius: 5vh;

    background-color: rgb(228, 220, 220);
    box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);

    text-align: center;
    user-select: none;
    position: relative;

    animation: slide-in-from-top 2s;
}

.heading-card:hover {
    transform: scale(1.1);
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
    border-radius: 5vh;

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
    width: 3vw;
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