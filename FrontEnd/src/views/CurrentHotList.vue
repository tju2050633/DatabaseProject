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

                        </div>

                        <!-- 博客热榜 -->
                        <div v-else-if="activeTab === 'blog'">
                            <div class="col" v-for="(blog, index) in blogs" :key="index">

                                <!-- 博客卡片 -->
                                <div class="card item-card">
                                    <BlogBlock :card="blog" />
                                </div>

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
</style>
  
<script>
export default {
    name: "CurrentHotList",

    data() {
        return {
            activeTab: "garden",

            blogs: [
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
                {
                    author: "作者4",
                    avatar: require("../assets/author-avatar.jpg"),
                    blogName: "博客名称4",
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
                        { user: "User7", content: "Comment 7" },
                        { user: "User8", content: "Comment 8" },
                        // Add more comments here
                    ],
                    liked: false, // 是否已点赞
                    totalLikes: 19, // 总点赞次数
                    showInput: false,
                    comment: "",
                },
                {
                    author: "作者5",
                    avatar: require("../assets/author-avatar.jpg"),
                    blogName: "博客名称5",
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
                        { user: "User9", content: "Comment 9" },
                        { user: "User10", content: "Comment 10" },
                        // Add more comments here
                    ],
                    liked: false, // 是否已点赞
                    totalLikes: 810, // 总点赞次数
                    showInput: false,
                    comment: "",
                },
                // 添加更多卡片...
            ],

            hotImages: [
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
                {
                    imageUrl: require("../assets/Garden-e.jpg"),
                    username: "Student4",
                    gardenname: "Garden4",
                    hot: "60",
                },
                {
                    imageUrl: require("../assets/Garden-e.jpg"),
                    username: "Student5",
                    gardenname: "Garden5",
                    hot: "50",
                },
            ],
        }
    },
    methods: {
        menuSelection(index) {
            this.activeTab = index;
        }
    },
};
</script>