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
                            <div class="col" v-for="(image, index) in hotGardens" :key="index"
                            @click="this.$router.push({name: 'garden', params: { garden_id: image.gardenId }})">

                                <!-- 花园卡片 -->
                                <div class="card item-card">
                                    <GardenBlock :image="image" />
                                </div>

                            </div>
                            <!-- 加载更多 -->
                            <div>
                                <button class="btn btn-outline-success show-more-btn" @click="loadHotGardens">加载更多</button>
                            </div>
                        </div>

                        <!-- 博客热榜 -->
                        <div v-else-if="activeTab === 'blog'">
                            <div class="col" v-for="(blog, index) in hotBlogs" :key="index">

                                <!-- 博客卡片 -->
                                <div class="card item-card">
                                    <BlogBlock :card="blog" />
                                </div>

                            </div>
                            <!-- 加载更多 -->
                            <div>
                                <button class="btn btn-outline-success show-more-btn" @click="loadHotBlogs">加载更多</button>
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
import { getHotGardens, getHotBlogs } from '@/api/hotListApi';
import { getUserNameById, getUserAvatarById } from '@/api/accountApi';
import { reactive, ref } from "vue";

export default {
    name: "CurrentHotList",
    async created() {
        this.loadHotGardens();
        this.loadHotBlogs();
    },
    data() {
        return {
            activeTab: ref("garden"),
            hotGardens: reactive([]),
            hotBlogs: reactive([]),

            state: reactive({
                currentGardenPage: 1, //当前的花园页面，用于花园分页与无限刷新
                gardens: [], //花园列表

                currentBlogPage: 1, //当前的博客页面，用于博客分页与无限刷新
                blogs: [], //博客列表

                pageSize: 10, //分页大小
            }),
        };
    },
    methods: {
        menuSelection(index) {
            this.activeTab = index;
        },
        async loadHotGardens() {
            const cur_num = this.hotGardens.length;

            const gardens = await getHotGardens(cur_num, 3);
            console.log("View gardens : ", gardens);

            for (let i = 0; i < gardens.length;i++)
            {
                const username = await getUserNameById(gardens[i].ownerId);
                let garden = {
                    gardenId: gardens[i].gardenId,
                    imageUrl: gardens[i].pictures,
                    username: username,
                    gardenname: gardens[i].name,
                    hot: gardens[i].stars
                }
                this.hotGardens.push(garden);
            }

        },
        async loadHotBlogs() {
            const cur_num = this.hotBlogs.length;

            const blogs = await getHotBlogs(cur_num, 3);
            console.log("View blogs : ", blogs);

            for (let i = 0; i < blogs.length;i++)
            {
                const author = await getUserNameById(blogs[i].ownerId);
                const avatar = await getUserAvatarById(blogs[i].ownerId);
                let blog = {
                    author: author,
                    ownerId: blogs[i].ownerId,
                    blogid: blogs[i].blogId,
                    avatar: avatar,
                    blogName: blogs[i].title,
                    partialContent: blogs[i].content,
                    fullContent: blogs[i].content,
                    showFullContent: false,
                    isOpen: false,
                    comments: [],
                    liked: false, // 是否已点赞
                    totalLikes: blogs[i].agreeNum, // 总点赞次数
                    showInput: false,
                    comment: "",
                };
                this.hotBlogs.push(blog);
            }
        },
    },
};
</script>