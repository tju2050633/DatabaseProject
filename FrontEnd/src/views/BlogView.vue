<template>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="https://unpkg.com/element-ui/lib/theme-chalk/index.css">
    </head>
    <div class="container" style="margin-top: 60px;">
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
                    <el-menu-item index="1-1" @click="this.$router.push('/personal/')">我的主页</el-menu-item>
                    <el-menu-item index="1-2" @click="this.$router.push('/login/')">登入/登出</el-menu-item>
                </el-sub-menu>
                <el-sub-menu index="2">
                    <template #title>
                        <el-icon>
                            <position />
                        </el-icon>
                        <span>校园地图</span>
                    </template>
                    <el-menu-item index="2-1" @click="this.$router.push('/login/')">四平路校区</el-menu-item>
                    <el-menu-item index="2-2" @click="this.$router.push('/login/')">嘉定校区</el-menu-item>
                    <el-menu-item index="2-3" @click="this.$router.push('/login/')">沪西校区</el-menu-item>
                </el-sub-menu>
                <el-sub-menu index="3">
                    <template #title>
                        <el-icon>
                            <house />
                        </el-icon>
                        <span>花园管理</span>
                    </template>
                    <el-menu-item index="3-1" @click="this.$router.push('/display/')">精选花园</el-menu-item>
                    <el-menu-item index="3-2" @click="this.$router.push('/login/')">我的花园</el-menu-item>
                </el-sub-menu>
                <el-sub-menu index="4">
                    <template #title>
                        <el-icon>
                            <chatSquare />
                        </el-icon>
                        <span>博客论坛</span>
                    </template>
                    <el-menu-item index="4-1" @click="this.$router.push('/blog/')">精选博客</el-menu-item>
                    <el-menu-item index="4-2" @click="this.$router.push('/login/')">我的发表</el-menu-item>
                </el-sub-menu>
            </el-menu>
        </el-col>

        <el-col :span="14">
            <div id="app">
                <el-card class="card">
                    <img src="../assets/blog-logo.png">
                </el-card>
                <el-card v-for="(card, index) in cards" :key="index" class="card">
                    <div class="card-header">
                        <h1 class="blog-name">{{ card.blogName }}</h1>
                        <img class="author-avatar-img" :src="card.avatar" @click="this.$router.push('/PersonalInfo/')"
                            alt="作者头像">
                        <h2 class="author-name" @click="this.$router.push('/PersonalInfo/')">{{ card.author }}</h2>
                    </div>
                    <div class="card-content">
                        <p v-if="!card.showFullContent">
                            {{ card.partialContent }}
                        </p>
                        <p v-else>
                            {{ card.fullContent }}
                        </p>
                        <button class="read-more-button" @click="toggleContent(index)">
                            {{ card.showFullContent ? '收起' : '阅读全文' }}
                        </button>
                    </div>
                    <div class="card-footer">
                        <el-row>
                            <el-col span="3">
                                <el-button @click="toggleCollapse(index)" style="display: flex; align-items: center;">
                                    <span v-if="card.isOpen" style="margin-right: 5px;">▲</span>
                                    <span v-else style="margin-right: 5px;">▼</span>
                                    <span style="flex: 1; text-align: center;">{{ card.isOpen ? '收起评论区' : '展开评论区' }} ({{
                                        card.comments.length }})</span>
                                </el-button>
                            </el-col>
                            <el-col span="3">
                                <el-button @click="handleLike(index)" style="display: flex; align-items: center;">
                                    <transition name="star-on-transition" mode="out-in" @after-leave="handleAfterLeave">
                                        <i class="el-icon-star-off" v-if="!card.liked"></i>
                                        <i class="el-icon-star-on" v-else></i>
                                    </transition>
                                    {{ card.liked ? '取消点赞' : '点赞' }}
                                    {{ '(' + card.totalLikes + ')' }}
                                </el-button>
                            </el-col>
                            <el-col span="3">
                                <el-button @click="toggleInput(index)"
                                    style="display: flex; align-items: center;">撰写评论</el-button>
                            </el-col>
                        </el-row>
                        <el-row>
                            <el-collapse v-model="card.isOpen" v-if="card.isOpen">
                                <div class="comment-container" v-for="(commentData, commentIndex) in card.comments"
                                    :key="commentIndex">
                                    <div>
                                        {{ commentData.user }} : {{ commentData.content }}
                                    </div>
                                </div>
                            </el-collapse>
                            <div v-if="card.showInput">
                                <el-input class="custom-input" v-model="card.comment" placeholder="输入你的想法..."></el-input>
                                <el-button @click="submitComment(index)" type="primary" size="small"
                                    style="display: flex; align-items: center;">提交</el-button>
                            </div>
                        </el-row>
                    </div>
                </el-card>
            </div>

        </el-col>
    </el-row>
    </div>
</template>

<style>
/* 定义过渡效果 */
.star-on-transition-enter-active,
.star-on-transition-leave-active {
    transition: transform 0.2s;
}

.star-on-transition-enter,
.star-on-transition-leave-to

/* .star-on-transition-leave-active in <2.1.8 */
    {
    transform: scale(1);
    /* 初始状态和离开状态设置为正常大小 */
}

.star-on-transition-enter-to,
.star-on-transition-leave

/* .star-on-transition-enter-active in <2.1.8 */
    {
    transform: scale(2);
    /* 进入状态和离开后状态设置为放大两倍 */
}

body {
    font-family: Arial, sans-serif;
}

.card {
    width: 800px;
    border: 1px solid #ccc;
    padding: 10px;
    margin: 20px auto;
    border-radius: 5px;
}

.card-header {
    display: flex;
    align-items: center;
}

.author-avatar-img {
    cursor: pointer;
    width: 80px;
    height: 80px;
    border-radius: 50%;
    object-fit: cover;
}

.author-name {
    cursor: pointer;
    font-size: 30px;
    margin-left: 10px;
}

.blog-name {
    width: 60%;
    font-size: 35px;
    text-align: left;
}

.card-content {
    margin-top: 20px;
}

.read-more-button {
    display: block;
    margin: 10px auto;
    width: 20%;
    height: 50%;
    line-height: 40px;
    text-align: center;
    font-size: 16px;
    color: white;
    background-color: rgb(0, 110, 255);
    border: 0px;
    border-radius: 5px;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

.read-more-button:hover {
    background-color: #2403f9;
    color: white;
}

.expanded-content {
    display: none;
}

.card-footer {
    margin-top: 20px;
    display: flex;
    flex-direction: column;
}

.comment-container {
    width: 700px;
    background-color: white;
}

.custom-input .el-input__inner {
    width: 500px;
    /* 自定义宽度 */
    height: 40px;
    /* 自定义高度 */
}

.custom-input .el-input__inner {
    font-size: 16px;
    /* 自定义字体大小 */
}
</style>

<script>

export default ({
    el: '#app',
    data() {
        return {
            cards: [
                {
                    author: '作者1',
                    avatar: require('../assets/author-avatar.jpg'),
                    blogName: '博客名称1',
                    partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
                    fullContent:
                        `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
                    showFullContent: false,
                    isOpen: false,
                    comments: [
                        { user: 'User1', content: 'Comment 1' },
                        { user: 'User2', content: 'Comment 2' },
                        // Add more comments here
                    ],
                    liked: false,  // 是否已点赞
                    totalLikes: 114,  // 总点赞次数
                    showInput: false,
                    comment: '',
                },
                {
                    author: '作者2',
                    avatar: require('../assets/author-avatar.jpg'),
                    blogName: '博客名称2',
                    partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
                    fullContent:
                        `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
                    showFullContent: false,
                    isOpen: false,
                    comments: [
                        { user: 'User3', content: 'Comment 3' },
                        { user: 'User4', content: 'Comment 4' },
                        // Add more comments here
                    ],
                    liked: false,  // 是否已点赞
                    totalLikes: 514,  // 总点赞次数
                    showInput: false,
                    comment: '',
                },
                {
                    author: '作者3',
                    avatar: require('../assets/author-avatar.jpg'),
                    blogName: '博客名称3',
                    partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
                    fullContent:
                        `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
                    showFullContent: false,
                    isOpen: false,
                    comments: [
                        { user: 'User5', content: 'Comment 5' },
                        { user: 'User6', content: 'Comment 6' },
                        // Add more comments here
                    ],
                    liked: false,  // 是否已点赞
                    totalLikes: 19,  // 总点赞次数
                    showInput: false,
                    comment: '',
                },
                {
                    author: '作者4',
                    avatar: require('../assets/author-avatar.jpg'),
                    blogName: '博客名称4',
                    partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
                    fullContent:
                        `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
                    showFullContent: false,
                    isOpen: false,
                    comments: [
                        { user: 'User7', content: 'Comment 7' },
                        { user: 'User8', content: 'Comment 8' },
                        // Add more comments here
                    ],
                    liked: false,  // 是否已点赞
                    totalLikes: 19,  // 总点赞次数
                    showInput: false,
                    comment: '',
                },
                {
                    author: '作者5',
                    avatar: require('../assets/author-avatar.jpg'),
                    blogName: '博客名称5',
                    partialContent: `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动`,
                    fullContent:
                        `(字体暂未确定)这里是文章内容的一小部分...只因你太美 baby只因你太美 baby只因你实在是太美 baby只因你太美 baby迎面走来的你让我如此蠢蠢欲动
                    这种感觉我从未有Cause I got a crush on you who you你是我的我是你的谁再多一眼看一眼就会爆炸再近
                    一点靠近点快被融化想要把你占为己有 baby bae不管走到哪里都会想起的人是你 you you我应该拿你怎样Uh 
                    所有人都在看着你我的心总是不安Oh 我现在已病入膏肓Eh oh难道真的因你而疯狂吗我本来不是这种人因你变
                    成奇怪的人第一次呀变成这样的我不管我怎么去否认只因你太美 baby只因你太美 baby只因你实在是太美
                    baby只因你太美 babyOh eh oh现在确认地告诉我Oh eh oh你到底属于谁Oh eh oh`,
                    showFullContent: false,
                    isOpen: false,
                    comments: [
                        { user: 'User9', content: 'Comment 9' },
                        { user: 'User10', content: 'Comment 10' },
                        // Add more comments here
                    ],
                    liked: false,  // 是否已点赞
                    totalLikes: 810,  // 总点赞次数
                    showInput: false,
                    comment: '',
                },
                // 添加更多卡片...
            ],
            showInput: false,
            comment: '',
        }
    },
    methods: {
        handleAfterLeave() {
            // 过渡结束后立即隐藏退出的图标，优化用户体验
            this.$nextTick(() => {
                this.liked = !this.liked;
            });
        },
        toggleContent(index) {
            this.cards[index].showFullContent = !this.cards[index].showFullContent;
        },
        toggleCollapse(index) {
            this.cards[index].isOpen = !this.cards[index].isOpen;
        },
        handleLike(index) {
            if (!this.cards[index].liked) {
                this.cards[index].totalLikes++;
            } else {
                this.cards[index].totalLikes--;
            }
            this.cards[index].liked = !this.cards[index].liked;
        },
        toggleInput(index) {
            this.cards[index].showInput = !this.cards[index].showInput;
            this.cards[index].comment = '';
        },
        submitComment(index) {
            if (this.cards[index].comment.trim() === '') {
                return;
            }
            window.alert('评论已经提交');
            this.toggleInput(index);
        }
    },
});
</script>
