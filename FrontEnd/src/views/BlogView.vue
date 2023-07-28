<template>
    <div class="container" style="margin-top: 60px;">
    
    <!-- 导航栏 -->
    <NavBar/>

    <el-row id="mainpart">
        <!-- 侧边栏 -->
        <SideBar/>

        <el-col :span="14">
            <div id="app">
                <el-card class="card">
                    <img src="../assets/blog-logo.png">
                </el-card>
                <el-card v-for="(card, index) in cards" :key="index" class="card">
                    <BlogBlock :card="card"/>
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
