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
                imageUrl: require("../assets/garden-1.jpg"),
                username: "考不上研不改名",
                gardenname: "不考研只种花",
                hot: "90",
            },
            {
                imageUrl: require("../assets/garden-2.jpg"),
                username: "花园的救赎",
                gardenname: "Garden2",
                hot: "80",
            },
            {
                imageUrl: require("../assets/garden-3.jpg"),
                username: "调参超人",
                gardenname: "调参之境",
                hot: "70",
            },
        ]);

        const blogs = reactive([
            {
                author: "云影同学",
                avatar: require("../assets/author-avatar.jpg"),
                blogName: "我与学业压力的对抗",
                partialContent: `大学生活充满了各种学业压力，期末考试、课程作业和学术压力常常让我们感到焦虑和疲惫。然而，在这个繁忙的学业生活中，我发现了一个独特而令人愉悦的逃离之道：共享花园。`,
                fullContent:
                    `大学生活充满了各种学业压力，期末考试、课程作业和学术压力常常让我们感到焦虑和疲惫。
                    然而，在这个繁忙的学业生活中，我发现了一个独特而令人愉悦的逃离之道：共享花园。

                    每当我走进校园花园，一股宁静和平和的氛围迎面而来。这里有鲜花盛开的花床、郁郁葱葱的绿植和清新的空气。
                    在花园中漫步，我仿佛进入了一个完全不同的世界，与学业的压力和担忧瞬间隔离开来。

                    在花园中，我能够放松身心，专注于与大自然的互动。我喜欢仔细观察花朵的细节、欣赏植物的生长过程以及聆听鸟儿的歌唱。
                    这种与自然的连接让我感到平静和放松，为我的思绪提供了一片宁静的空间。
                    
                    更重要的是，花园成为了我缓解学业压力的疗愈之地。当我忙碌的头脑需要一段时间的休息时，花园中的宁静和生机带给我内心的平静和舒缓。
                    我可以忘记繁重的任务和压力，专注于花园中的当下。这种专注和放松使我能够重新充电，回到学业中更有动力和精力。

                    共享花园是我逃离学业压力的庇护所，一个我可以疗愈身心的地方。我希望每个同学都能在忙碌的学业生活中寻找类似的避风港，
                    逃离学业压力，与大自然相融合，我们能够找到平衡、重新充能，并以更积极的心态面对学业的挑战。`,
                showFullContent: false,
                isOpen: false,
                comments: [
                    { user: "嘟嘟从不嘟嘴", content: "花园确实是一个逃离学业压力的好去处，我也喜欢在花园里放松身心。作者描述得很生动，让人仿佛能感受到花园的美丽和宁静。希望能有机会去探险花园，感受一下那种放松和平和的氛围。" },
                    { user: "猛男自我修养", content: "虽然我不太热衷于花园，但我能理解作者表达的意图。对我而言，解压的方式可能更多地与运动、音乐或阅读有关。不同的人有不同的喜好和方式来放松自己，这也是应对学业压力的多样性。不管是花园、运动还是其他活动，重要的是找到适合自己的方式，保持身心的平衡和健康。" },
                    // Add more comments here
                ],
                liked: false, // 是否已点赞
                totalLikes: 114, // 总点赞次数
                showInput: false,
                comment: "",
            },
            {
                author: "欢乐的西瓜头",
                avatar: require("../assets/author-avatar.jpg"),
                blogName: "创新的花园：激发灵感的源泉",
                partialContent: `在这个大学内部的共享花园网页应用中，我想与大家分享一个令人兴奋的主题：创新和灵感。作为学生，我们时刻追求着新的思考方式和创造力的发挥。而花园，作为我们校园内的绿色宝藏，不仅是一处美丽的景观，更是激发创新灵感的宝贵源泉。`,
                fullContent:
                    `在这个大学内部的共享花园网页应用中，我想与大家分享一个令人兴奋的主题：创新和灵感。
                    作为学生，我们时刻追求着新的思考方式和创造力的发挥。而花园，作为我们校园内的绿色宝藏，不仅是一处美丽的景观，更是激发创新灵感的宝贵源泉。
                    
                    在校园内的花园中，我们可以欣赏到各种各样的植物和景观设计。这些花卉和绿植的组合、布局和养护方式都是园艺师们的创意和创新的结果。
                    他们通过尝试不同的植物组合、布置花坛的方式，甚至使用新颖的园艺技术，打造出独特而美丽的花园景观。
                    这些创新的实践激发了我们对美的感知和审美的提升，也为我们提供了创造和创新的启示。
                    
                    其次，花园是一个充满灵感的场所。当我们漫步在花园中时，我们会被花朵的色彩、形状和香气所吸引。
                    我们会观察植物的生长方式、花苞的细节，甚至是昆虫和小动物在花园中的生态。这些细微的观察和感受有助于我们培养观察力和细致思考的能力。
                    在花园中，我们可以放松心情，凝视花朵的绽放，让大自然的美景与我们的想象力相互融合。这种灵感的碰撞和交融，能够激发我们独特的创新思维和创造力。
                    
                    最后，我想强调的是，创新和灵感是一种持续的过程。花园是一个不断变化的地方，我们可以在不同季节、不同天气条件下观察到不同的植物和景观。
                    因此，我们应该时刻保持对新事物的好奇心和开放的心态。在花园中寻找灵感，培养创新思维，需要我们持续地观察、思考和实践。
                    
                    在共享花园中，我们可以开阔思维、激发创造力，并在创新的道路上不断前行。让我们一起在这个美丽的花园中，探索和创造属于我们自己的创新之花！`,
                showFullContent: false,
                isOpen: false,
                comments: [
                    { user: "ECHK46", content: "我喜欢这篇博客中提到的利用花园进行创新的想法。作为一个对设计和建造感兴趣的学生，我想在花园中尝试建造一些小型园艺装置，展示我的创意和技能。希望能够在共享花园中与其他学生分享我的项目，互相学习和启发。" },
                    { user: "IT阿杰", content: "除了寻找灵感和培养创新思维，我觉得花园还可以作为一个放松和恢复精力的场所。在繁忙的大学生活中，走进花园，欣赏花朵的美丽和大自然的宁静，给我带来了心灵的平静和放松。" },
                    // Add more comments here
                ],
                liked: false, // 是否已点赞
                totalLikes: 514, // 总点赞次数
                showInput: false,
                comment: "",
            },
            {
                author: "天这么热开空调啊",
                avatar: require("../assets/author-avatar.jpg"),
                blogName: "共享花园：为环保事业注入新活力",
                partialContent: `共享花园不仅是我们欣赏自然之美的场所，也是我们探索环保理念并实践可持续生活方式的平台。在这片绿洲中，我们通过积极参与和分享，为创造一个更美好的环境贡献自己的力量。`,
                fullContent:
                    `共享花园不仅是我们欣赏自然之美的场所，也是我们探索环保理念并实践可持续生活方式的平台。
                    在这片绿洲中，我们通过积极参与和分享，为创造一个更美好的环境贡献自己的力量。
                    
                    共享花园作为一个开放的环境教育平台，为人们提供了学习和认识自然环境的机会。
                    在花园中，人们可以亲身参与种植、观察植物和生态系统的变化，并通过与他人交流分享知识和经验。
                    这种参与式的学习方式不仅提高了人们的环保意识，还培养了他们对自然世界的珍惜和保护意识。
                    
                    在城市中，开放空地常常被混凝土和钢筋所取代，生态系统遭受着破坏和压力。
                    而共享花园通过引入植物、提供栖息地和食物源，为各种生物提供了宝贵的栖息和繁衍环境。
                    这不仅有助于保护当地的生物多样性，还促进了城市生态系统的恢复和平衡。
                    
                    共享花园作为一个可持续发展的示范项目，向社区和其他人们展示了环保行为的重要性和可行性。
                    人们可以从中获得灵感，并将环保理念延伸到自己的生活和工作中，从而推动整个社会朝着更可持续的方向发展。`,
                showFullContent: false,
                isOpen: false,
                comments: [
                    { user: "彩虹果_Colorful", content: "这篇博客提醒了我城市化进程对生态系统的影响，共享花园的存在为城市提供了重要的绿色空间，我希望能有更多这样的项目出现。" },
                    { user: "戴夫指挥官", content: "共享花园是一个可持续发展的典范，它向我们展示了如何在日常生活中实践环保行为，我会积极参与其中，为创造可持续的未来贡献力量。" },
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