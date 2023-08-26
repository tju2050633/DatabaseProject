<template>
    <body>
        <div class="container">
            <NavBar /> <!-- 导航栏 -->

            <el-row>
                <SideBar /> <!-- 侧边栏 -->

                <el-col :span="14">
                    <br>

                    <!-- 标签栏 -->
                    <el-header>
                        <el-menu class="data-menu" :default-active="activeTab" mode="horizontal" @select="menuSelection">
                            <el-menu-item index="garden">花园热榜</el-menu-item>
                            <el-menu-item index="blog">博客热榜</el-menu-item>
                        </el-menu>
                    </el-header>

                    <!-- 展示区域 -->
                    <el-main>
                        <!-- 花园热榜 -->
                        <div v-if="activeTab === 'garden'">
                            <div class="col" v-for="(image, index) in hotImages" :key="index"
                                @click="this.$router.push('/garden/')">

                                <!-- 花园卡片 -->
                                <div class="card item-card">
                                    <GardenBlock :image="image" />
                                </div>

                            </div>
                            <!-- 加载更多 -->
                            <div>
                                <button class="btn btn-outline-success show-more-btn" @click="loadMoreGardens">加载更多</button>
                            </div>
                        </div>

                        <!-- 博客热榜 -->
                        <div v-else-if="activeTab === 'blog'">
                            <div class="col" v-for="(blog, index) in blogs" :key="index">

                                <!-- 博客卡片 -->
                                <div class="card item-card">
                                    <BlogBlock :card="blog" />
                                </div>

                            </div>
                            <!-- 加载更多 -->
                            <div>
                                <button class="btn btn-outline-success show-more-btn" @click="loadMoreBlogs">加载更多</button>
                            </div>
                        </div>
                    </el-main>

                </el-col>
            </el-row>

        </div>
    </body>
</template>

<style scoped>
body {
    background-color: rgb(244, 237, 228);
    background-image: url("../assets/img-hotlist.jpg");
    background-size: 60vh;
    background-repeat: no-repeat;
    position: relative;
    background-position: 66vw 40vh;
    background-attachment: fixed;
}

.container {
    margin-top: 60px;
}

.data-menu {
    padding: 1vh;
    margin-bottom: 3vh;

    font-weight: bold;

    border-width: 0vh;
    border-radius: 2vh;

    box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
    background-color: rgb(246, 243, 239);


    animation: slide-in-from-top 1s;
}

.item-card {
    padding: 1vh;

    border-width: 0vh;
    border-radius: 2vh;

    box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
    background-color: rgb(246, 243, 239);

    margin-top: 3vh;
    margin-bottom: 3vh;

    animation: fade-in 1.5s;
}

@keyframes slide-in-from-top {
    from {
        transform: translateY(-100%);
    }

    to {
        transform: translateY(0);
    }
}

@keyframes fade-in {
    0% {
        opacity: 0;
    }

    100% {
        opacity: 1;
    }
}

.show-more-btn {
    margin: 2vh auto 10vh 1vw;
}
</style>
  
<script>
import { reactive, ref, onMounted } from "vue";
import API from "@/api/basicApi.js";

export default {
    name: "CurrentHotList",

    setup() {
        let activeTab = ref("garden");


        const hotImages = reactive([
            {
                imageUrl: require("../assets/Garden-e.jpg"),
                username: "Student1",
                gardenname: "Garden1",
                hot: "90",
            },
            {
                imageUrl: require("../assets/Garden-e.jpg"),
                username: "Student2",
                gardenname: "Garden2",
                hot: "80",
            },
            {
                imageUrl: require("../assets/Garden-e.jpg"),
                username: "Student3",
                gardenname: "Garden3",
                hot: "70",
            },
        ]);

        const blogs = reactive([
            {
                author: "作者1",
                avatar: require("../assets/author-avatar.jpg"),
                blogName: "博客名称1",
                partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
                fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
                showFullContent: false,
                isOpen: false,
                comments: [
                    { user: "User1", content: "Comment 1" },
                    { user: "User2", content: "Comment 2" },
                    // Add more comments here
                ],
                liked: false, // 是否已点赞
                totalLikes: 114, // 总点赞次数
                showInput: false,
                comment: "",
            },
            {
                author: "作者2",
                avatar: require("../assets/author-avatar.jpg"),
                blogName: "博客名称2",
                partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
                fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
                showFullContent: false,
                isOpen: false,
                comments: [
                    { user: "User3", content: "Comment 3" },
                    { user: "User4", content: "Comment 4" },
                    // Add more comments here
                ],
                liked: false, // 是否已点赞
                totalLikes: 514, // 总点赞次数
                showInput: false,
                comment: "",
            },
            {
                author: "作者3",
                avatar: require("../assets/author-avatar.jpg"),
                blogName: "博客名称3",
                partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
                fullContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
                showFullContent: false,
                isOpen: false,
                comments: [
                    { user: "User5", content: "Comment 5" },
                    { user: "User6", content: "Comment 6" },
                    // Add more comments here
                ],
                liked: false, // 是否已点赞
                totalLikes: 19, // 总点赞次数
                showInput: false,
                comment: "",
            },
        ]);

        //定义读取要用的变量
        const state = reactive({
            currentGardenPage: 1, //当前的花园页面，用于花园分页与无限刷新
            gardens: [], //花园列表

            currentBlogPage: 1, //当前的博客页面，用于博客分页与无限刷新
            blogs: [], //博客列表

            pageSize: 10, //分页大小
        });

        //错误信息
        let errMessage = ref("");

        // 执行一些初始化逻辑
        onMounted(() => {
            // this.loadBlogs();测试已有接口不掉用该函数
            loadGardenUsingId();
            loadBlogUsingId();
        });

        //跳转到花园页面时获取初始的花园数据
        const loadGardens = () => {
            console.log("开始花园读取");
            API({
                url: "/Garden/",
                method: "get",
                params: {
                    page: state.currentGardenPage,
                    pagesize: state.pageSize,
                },
            }).then(
                function (res) {
                    console.log("获取成功");
                    state.gardens = res.data;
                },
                function (err) {
                    console.log("获取失败");
                    errMessage.value = err.data;
                }
            );
        };

        //加载更多的花园数据
        const loadMoreGardens = () => {
            console.log("开始花园读取");
            API({
                url: "/Garden/",
                method: "get",
                params: {
                    page: state.currentGardenPage,
                    pagesize: state.pageSize,
                },
            }).then(
                function (res) {
                    console.log("获取更多成功");
                    state.currentGardenPage++;
                    state.gardens.push(res.data);
                },
                function (err) {
                    console.log("获取更多失败");
                    errMessage.value = err.data;
                }
            );
        };

        //跳转到博客页面时获取初始的博客数据
        const loadBlogs = () => {
            console.log("开始博客读取");
            API({
                url: "/Blog/",
                method: "get",
                params: {
                    page: state.currentBlogPage,
                    pagesize: state.pageSize,
                },
            }).then(
                function (res) {
                    console.log("获取成功");
                    state.blogs = res.data;
                },
                function (err) {
                    console.log("获取失败");
                    errMessage.value = err.data;
                }
            );
        };

        //加载更多的博客数据
        const loadMoreBlogs = () => {
            console.log("开始博客读取");
            API({
                url: "/Blog/",
                method: "get",
                params: {
                    page: state.currentBlogPage,
                    pagesize: state.pageSize,
                },
            }).then(
                function (res) {
                    console.log("获取更多成功");
                    state.currentBlogPage++;
                    state.blogs.push(res.data);
                },
                function (err) {
                    console.log("获取更多失败");
                    errMessage.value = err.data;
                }
            );
        };

        //下面用于测试已有的接口
        //将后端返回的数据格式改为前端使用的cards
        const toGardenCard = (garden) => {
            console.log(garden.content);
            var card = {
                imageUrl: require("../assets/Garden-e.jpg"), //后端数据库没有
                username: garden.username,
                gardenname: garden.gardenname,
                hot: garden.hot,
            };
            return card;
        };

        const toBlogCard = (blog) => {
            console.log(blog.content);
            var card = {
                author: blog.blogId,
                avatar: require("../assets/author-avatar.jpg"), //后端数据库没有
                blogName: blog.title,
                partialContent: blog.content.substring(0, 100),
                fullContent: blog.content,
                showFullContent: false,
                isOpen: false,
                comments: [
                    //后端数据库没有
                    { user: "User7", content: "Comment 7" },
                    { user: "User8", content: "Comment 8" },
                    // Add more comments here
                ],
                liked: false, // 是否已点赞
                totalLikes: blog.agreeNum, // 总点赞次数
                showInput: false,
                comment: "",
            };
            return card;
        };

        const loadGardenUsingId = () => {
            console.log("开始花园读取测试");
            API({
                url: "/Garden/",
                method: "get",
                params: {
                    id: 2, //测试数据写死
                },
            }).then(
                function (res) {
                    console.log("测试成功");
                    //测试获得的内容
                    console.log(res.data);
                    state.gardens.push(res.data);
                    hotImages.push(toGardenCard(res.data));
                },
                function (err) {
                    console.log("测试失败");
                    errMessage.value = err.data;
                }
            );
        };

        const loadBlogUsingId = () => {
            console.log("开始博客读取测试");
            API({
                url: "/Blog/",
                method: "get",
                params: {
                    id: 2, //测试数据写死
                },
            }).then(
                function (res) {
                    console.log("测试成功");
                    //测试获得的内容
                    console.log(res.data);
                    state.blogs.push(res.data);
                    blogs.push(toBlogCard(res.data));
                },
                function (err) {
                    console.log("测试失败");
                    errMessage.value = err.data;
                }
            );
        };

        return {
            activeTab,

            hotImages,
            blogs,

            state,
            errMessage,

            loadGardens,
            loadMoreGardens,
            toGardenCard,
            loadGardenUsingId,

            loadBlogs,
            loadMoreBlogs,
            toBlogCard,
            loadBlogUsingId,
        };
    },

    methods: {
        menuSelection(index) {
            this.activeTab = index;
        }
    },
};
</script>