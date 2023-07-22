<template>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="https://unpkg.com/element-ui/lib/theme-chalk/index.css">
    </head>
    <!-- 侧边栏 -->
    <el-row id="mainpart">
        <el-col :span="3">
            <el-menu>
                <el-sub-menu index="1">
                    <template #title>
                        <el-icon>
                            <user />
                        </el-icon>
                        <span>账号管理</span>
                    </template>
                    <el-menu-item index="1-1">我的主页</el-menu-item>
                    <el-menu-item index="1-2">登入/登出</el-menu-item>
                </el-sub-menu>
                <el-sub-menu index="2">
                    <template #title>
                        <el-icon>
                            <position />
                        </el-icon>
                        <span>校园地图</span>
                    </template>
                    <el-menu-item index="2-1">四平路校区</el-menu-item>
                    <el-menu-item index="2-2">嘉定校区</el-menu-item>
                    <el-menu-item index="2-3">沪西校区</el-menu-item>
                </el-sub-menu>
                <el-sub-menu index="3">
                    <template #title>
                        <el-icon>
                            <house />
                        </el-icon>
                        <span>花园管理</span>
                    </template>
                    <el-menu-item index="3-1" @click="this.$router.push('/display')">精选花园</el-menu-item>
                    <el-menu-item index="3-2">我的花园</el-menu-item>
                </el-sub-menu>
                <el-sub-menu index="4">
                    <template #title>
                        <el-icon>
                            <chatSquare />
                        </el-icon>
                        <span>博客论坛</span>
                    </template>
                    <el-menu-item index="4-1">精选博客</el-menu-item>
                    <el-menu-item index="4-2">我的发表</el-menu-item>
                </el-sub-menu>
            </el-menu>
        </el-col>

        <el-col :span="13">
            <el-container>
                <!-- 导航栏 -->
                <el-header>
                    <el-menu :default-active="activeTab" mode="horizontal" @select="handleMenuSelect">
                        <el-menu-item index="hot">热门</el-menu-item>
                        <el-menu-item index="new">最新</el-menu-item>
                        <el-menu-item index="mine">我的</el-menu-item>
                    </el-menu>
                </el-header>
                <!-- 图片展示区域 -->
                <el-main>
                    <div v-if="activeTab === 'hot'">
                        <!--这里实际项目中应该为数据库读取并展示-->
                        
                        <!-- 在activeTab为'hot'时，展示一系列图片 -->
                        <el-card v-for="(image, index) in hotImages" :key="index"
                            style="margin: 20px;box-shadow: 0 10px 18px rgba(0, 0, 0, 0.53);"
                            @click="this.$router.push('/personal/')">
                            <div style="text-align: center;">
                                <img :src="image.imageUrl" alt="花园图片" style="width: 60%">
                            </div>
                            <div style="display: flex; justify-content: space-between;">
                                <span style="flex: 1; text-align: left;"><el-icon style="margin-top: 5px">
                                        <user />
                                    </el-icon>{{ image.username }}</span>
                                <span style="flex: 1; text-align: center;">{{ image.gardenname }}</span>
                                <span style="flex: 1; text-align: right;"><el-icon style="margin-top: 5px">
                                        <star />
                                    </el-icon>{{ image.hot }}</span>
                            </div>
                        </el-card>
                    </div>
                    <div v-else-if="activeTab === 'new'">
                        <el-card v-for="(image, index) in newImages" :key="index"
                            style="margin: 10px;box-shadow: 0 10px 18px rgba(0, 0, 0, 0.53);"
                            @click="this.$router.push('/personal/')">
                            <div style="text-align: center;">
                                <img :src="image.imageUrl" alt="花园图片" style="width: 60%">
                            </div>
                            <div style="display: flex; justify-content: space-between;">
                                <span style="flex: 1; text-align: left;"><el-icon style="margin-top: 5px">
                                        <user />
                                    </el-icon>{{ image.username }}</span>
                                <span style="flex: 1; text-align: center;">{{ image.gardenname }}</span>
                                <span style="flex: 1; text-align: right;"><el-icon style="margin-top: 5px">
                                        <star />
                                    </el-icon>{{ image.hot }}</span>
                            </div>
                        </el-card>
                    </div>
                    <div v-else-if="activeTab === 'mine'">我的图片展示</div>
                </el-main>
            </el-container>
        </el-col>

        <el-col :span="8">
            <el-container>
                <br>
                <i class="el-icon-star-on"></i>
                <el-header>花园排行榜</el-header>
                <el-main>
                    <!-- 花园排行榜 -->
                    <el-row :gutter="20">
                        <el-col :span="9" v-for="(item, index) in displayedImageList" :key="index">
                            <el-card
                                style="margin-top: 10px;margin-left: 10px;margin-right: 10px;margin-bottom: 10px;box-shadow: 0 10px 18px rgba(0, 0, 0, 0.53);"
                                @click="this.$router.push('/personal/')">
                                <!-- 图片展示区域 -->
                                <img :src="item.imageUrl" alt="花园" style="width: 100%">
                                <!-- 图片描述 -->
                                <div style="text-align: center;">
                                    {{ item.description }}
                                </div>
                            </el-card>
                        </el-col>
                    </el-row>
                    <br>
                    <el-button @click="toggleShowMore" style="margin-top: 10px;">{{ showMore ? '收起' : '显示更多' }}</el-button>
                </el-main>
            </el-container>
        </el-col>
    </el-row>
</template>

<style></style>

<script>
export default ({
    el: '#mainpart',
    data() {
        return {
            activeTab: 'hot', // 默认选中热门板块
            showMore: false, // 控制是否显示更多图片
            displayedImageList: [], // 实际显示的图片列表
            maxDisplayCount: 4, // 默认显示的图片数量
            imageList: [
                {
                    imageUrl: require('../assets/example.png'),
                    description: 'TOP1 Garden',
                },
                {
                    imageUrl: require('../assets/example.png'),
                    description: 'TOP2 Garden',
                },
                {
                    imageUrl: require('../assets/example.png'),
                    description: 'TOP3 Garden',
                },
                {
                    imageUrl: require('../assets/example.png'),
                    description: 'TOP4 Garden',
                },
                {
                    imageUrl: require('../assets/example.png'),
                    description: 'TOP5 Garden',
                },
                {
                    imageUrl: require('../assets/example.png'),
                    description: 'TOP6 Garden',
                },
                {
                    imageUrl: require('../assets/example.png'),
                    description: 'TOP7 Garden',
                },
                {
                    imageUrl: require('../assets/example.png'),
                    description: 'TOP8 Garden',
                },
                {
                    imageUrl: require('../assets/example.png'),
                    description: 'TOP9 Garden',
                },
                {
                    imageUrl: require('../assets/example.png'),
                    description: 'TOP10 Garden',
                },
            ],
            hotImages: [
                {
                    imageUrl: require('../assets/Garden-e.jpg'),
                    username: 'Student1',
                    gardenname: 'Garden1',
                    hot: '90'
                },
                {
                    imageUrl: require('../assets/Garden-e.jpg'),
                    username: 'Student2',
                    gardenname: 'Garden2',
                    hot: '80'
                },
                {
                    imageUrl: require('../assets/Garden-e.jpg'),
                    username: 'Student3',
                    gardenname: 'Garden3',
                    hot: '70'
                },
                {
                    imageUrl: require('../assets/Garden-e.jpg'),
                    username: 'Student4',
                    gardenname: 'Garden4',
                    hot: '60'
                },
                {
                    imageUrl: require('../assets/Garden-e.jpg'),
                    username: 'Student5',
                    gardenname: 'Garden5',
                    hot: '50'
                },
            ],
            newImages: [
                {
                    imageUrl: require('../assets/Garden.jpg'),
                    username: 'Student6',
                    gardenname: 'Garden6',
                    hot: '10'
                },
                {
                    imageUrl: require('../assets/Garden.jpg'),
                    username: 'Student7',
                    gardenname: 'Garden7',
                    hot: '12'
                },
                {
                    imageUrl: require('../assets/Garden.jpg'),
                    username: 'Student8',
                    gardenname: 'Garden8',
                    hot: '14'
                },
                {
                    imageUrl: require('../assets/Garden.jpg'),
                    username: 'Student9',
                    gardenname: 'Garden9',
                    hot: '16'
                },
                {
                    imageUrl: require('../assets/Garden.jpg'),
                    username: 'Student10',
                    gardenname: 'Garden10',
                    hot: '18'
                },
            ]
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
    },
    created() {
        this.updateDisplayedImages(); // 初始化时根据showMore状态设置图片数量
    },
});
</script>