<!-- 消息模块，仅在MessageView里使用 -->

<template>
    <!-- 水平布局 -->
    <div class="row">

        <!-- 左侧导航区域 -->
        <div class="col-md-3 d-flex justify-content-center">
            <!-- 导航卡片 -->
            <div class="card sidebar">
                <div class="card-body">
                    <!-- 分隔线 -->
                    <div class="colored-line"></div>
                    <!-- 小标题 -->
                    <h5 class="heading">
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" fill="currentColor" class="bi bi-send"
                            viewBox="0 0 16 16">
                            <path
                                d="M15.854.146a.5.5 0 0 1 .11.54l-5.819 14.547a.75.75 0 0 1-1.329.124l-3.178-4.995L.643 7.184a.75.75 0 0 1 .124-1.33L15.314.037a.5.5 0 0 1 .54.11ZM6.636 10.07l2.761 4.338L14.13 2.576 6.636 10.07Zm6.787-8.201L1.591 6.602l4.339 2.76 7.494-7.493Z" />
                        </svg>
                        消息中心
                    </h5>
                    <!-- 分隔线 -->
                    <div class="colored-line"></div>
                    <br>
                    <!-- 导航项 -->
                    <ul>
                        <!-- 我的消息 -->
                        <li @click="selectTab('my-messages')" :class="{ active: activeTab === 'my-messages' }">
                            <span v-if="activeTab === 'my-messages'">
                                <svg xmlns="http://www.w3.org/2000/svg" width="25" fill="currentColor"
                                    class="bi bi-toggle-on" viewBox="0 0 16 16">
                                    <path d="M5 3a5 5 0 0 0 0 10h6a5 5 0 0 0 0-10H5zm6 9a4 4 0 1 1 0-8 4 4 0 0 1 0 8z" />
                                </svg>
                            </span>
                            <span v-else>
                                <svg xmlns="http://www.w3.org/2000/svg" width="25" fill="currentColor"
                                    class="bi bi-toggle-off" viewBox="0 0 16 16">
                                    <path
                                        d="M11 4a4 4 0 0 1 0 8H8a4.992 4.992 0 0 0 2-4 4.992 4.992 0 0 0-2-4h3zm-6 8a4 4 0 1 1 0-8 4 4 0 0 1 0 8zM0 8a5 5 0 0 0 5 5h6a5 5 0 0 0 0-10H5a5 5 0 0 0-5 5z" />
                                </svg>
                            </span>
                            &emsp;我的消息
                        </li>
                        <!-- 系统通知 -->
                        <li @click="selectTab('system-notifications')"
                            :class="{ active: activeTab === 'system-notifications' }">
                            <span v-if="activeTab === 'system-notifications'">
                                <svg xmlns="http://www.w3.org/2000/svg" width="25" fill="currentColor"
                                    class="bi bi-toggle-on" viewBox="0 0 16 16">
                                    <path d="M5 3a5 5 0 0 0 0 10h6a5 5 0 0 0 0-10H5zm6 9a4 4 0 1 1 0-8 4 4 0 0 1 0 8z" />
                                </svg>
                            </span>
                            <span v-else>
                                <svg xmlns="http://www.w3.org/2000/svg" width="25" fill="currentColor"
                                    class="bi bi-toggle-off" viewBox="0 0 16 16">
                                    <path
                                        d="M11 4a4 4 0 0 1 0 8H8a4.992 4.992 0 0 0 2-4 4.992 4.992 0 0 0-2-4h3zm-6 8a4 4 0 1 1 0-8 4 4 0 0 1 0 8zM0 8a5 5 0 0 0 5 5h6a5 5 0 0 0 0-10H5a5 5 0 0 0-5 5z" />
                                </svg>
                            </span>
                            &emsp;系统通知
                        </li>
                        <!-- 收到的赞 -->
                        <li @click="selectTab('received-likes')" :class="{ active: activeTab === 'received-likes' }">
                            <span v-if="activeTab === 'received-likes'">
                                <svg xmlns="http://www.w3.org/2000/svg" width="25" fill="currentColor"
                                    class="bi bi-toggle-on" viewBox="0 0 16 16">
                                    <path d="M5 3a5 5 0 0 0 0 10h6a5 5 0 0 0 0-10H5zm6 9a4 4 0 1 1 0-8 4 4 0 0 1 0 8z" />
                                </svg>
                            </span>
                            <span v-else>
                                <svg xmlns="http://www.w3.org/2000/svg" width="25" fill="currentColor"
                                    class="bi bi-toggle-off" viewBox="0 0 16 16">
                                    <path
                                        d="M11 4a4 4 0 0 1 0 8H8a4.992 4.992 0 0 0 2-4 4.992 4.992 0 0 0-2-4h3zm-6 8a4 4 0 1 1 0-8 4 4 0 0 1 0 8zM0 8a5 5 0 0 0 5 5h6a5 5 0 0 0 0-10H5a5 5 0 0 0-5 5z" />
                                </svg>
                            </span>
                            &emsp;收到的赞
                        </li>
                        <!-- 回复我的 -->
                        <li @click="selectTab('replies')" :class="{ active: activeTab === 'replies' }">
                            <span v-if="activeTab === 'replies'">
                                <svg xmlns="http://www.w3.org/2000/svg" width="25" fill="currentColor"
                                    class="bi bi-toggle-on" viewBox="0 0 16 16">
                                    <path d="M5 3a5 5 0 0 0 0 10h6a5 5 0 0 0 0-10H5zm6 9a4 4 0 1 1 0-8 4 4 0 0 1 0 8z" />
                                </svg>
                            </span>
                            <span v-else>
                                <svg xmlns="http://www.w3.org/2000/svg" width="25" fill="currentColor"
                                    class="bi bi-toggle-off" viewBox="0 0 16 16">
                                    <path
                                        d="M11 4a4 4 0 0 1 0 8H8a4.992 4.992 0 0 0 2-4 4.992 4.992 0 0 0-2-4h3zm-6 8a4 4 0 1 1 0-8 4 4 0 0 1 0 8zM0 8a5 5 0 0 0 5 5h6a5 5 0 0 0 0-10H5a5 5 0 0 0-5 5z" />
                                </svg>
                            </span>
                            &emsp;回复我的
                        </li>
                    </ul>
                </div>
            </div>
        </div>

        <!-- 右侧内容区域 -->
        <div class="col-md-9 d-flex justify-content-center">
            <!-- 内容卡片 -->
            <div class="card content">
                <div class="card-body">

                    <!-- 我的消息 -->
                    <div v-if="activeTab === 'my-messages'">
                        敬请期待
                    </div>

                    <!-- 系统通知 -->
                    <div v-if="activeTab === 'system-notifications'">
                        <!-- 循环为每个通知创建一张卡片 -->
                        <div class="card subcontent" v-for=" notification  in  notifications " :key="notification.id">
                            <div class="card-body">
                                <h5 class="subcontent-title">{{ notification.title }}</h5> <!-- 通知的标题 -->
                                <p class="subcontent-time">{{ notification.time }}</p> <!-- 通知发布的时间 -->
                                <div class="colored-line"></div> <!-- 分隔线 -->
                                <span class="subcontent-text">{{ notification.content }}</span> <!-- 通知的内容 -->
                            </div>
                        </div>
                    </div>

                    <!-- 收到的赞 -->
                    <div v-if="activeTab === 'received-likes'">
                        <!-- 循环为每个点赞创建一张卡片 -->
                        <div class="card subcontent" v-for=" like  in  likes " :key="like.id">
                            <div class="card-body">
                                <!-- 点赞的标题 -->
                                <h5 class="subcontent-title" v-if="like.likedtype === 'comment'">评论收到点赞 </h5>
                                <h5 class="subcontent-title" v-if="like.likedtype === 'garden'">花园收到点赞 </h5>
                                <h5 class="subcontent-title" v-if="like.likedtype === 'blog'">博客收到点赞 </h5>

                                <p class="subcontent-time">{{ like.time }}</p> <!-- 点赞的时间 -->
                                <div class="colored-line"></div> <!-- 分隔线 -->

                                <!-- 具体点赞信息 -->
                                <span class="subcontent-text">
                                    <!-- 点赞的用户的头像 -->
                                    <img class="img-fluid" src="../assets/logo.png" style="width: 30px;">
                                    <!-- 点赞的用户的昵称 -->
                                    用户 {{ like.userid }}（我没有定义昵称 这里暂时用id）点赞了您的
                                </span>
                                <!-- 被点赞内容的类型以及标题 -->
                                <span class="subcontent-text" v-if="like.likedtype === 'comment'">评论 {{ like.typeid
                                }}（实际用标题 这里暂时用id）</span>
                                <span class="subcontent-text" v-if="like.likedtype === 'garden'">花园 {{ like.typeid
                                }}（实际用标题 这里暂时用id）</span>
                                <span class="subcontent-text" v-if="like.likedtype === 'blog'">博客 {{ like.typeid
                                }}（实际用标题 这里暂时用id）</span>
                            </div>
                        </div>
                    </div>

                    <!-- 回复我的 -->
                    <div v-if="activeTab === 'replies'">
                        <!-- 循环为每个回复创建一张卡片 -->
                        <div class="card subcontent" v-for=" reply  in  replies " :key="reply.id" style="width: 100%;">
                            <div class="card-body">
                                <!-- 回复标题 -->
                                <h5 class="subcontent-title">
                                    <!-- 回复用户的头像 -->
                                    <img class="img-fluid" src="../assets/logo.png" style="width: 30px;">
                                    <!-- 回复用户的id/昵称 -->
                                    用户 {{ reply.userid }}（实际用昵称 这里暂时用id）回复了您的评论
                                </h5>
                                <!-- 回复的时间 -->
                                <p class="subcontent-time">{{ reply.time }}</p>

                                <div class="colored-line"></div> <!-- 分隔线 -->

                                <!-- 原评论的内容 -->
                                <p class="subcontent-text" style="font-weight: bold;">原评论</p>
                                <p class="subcontent-text">（显示评论内容 超出一定字数用 ...）</p>

                                <div class="colored-line"></div> <!-- 分隔线 -->

                                <!-- 回复的内容 -->
                                <p class="subcontent-text" style="font-weight: bold;">回复内容</p>
                                <p class="subcontent-text">{{ reply.content }}</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { reactive } from 'vue';

export default {
    name: 'MessageCard',
    components: {
    },

    data() {
        // 自定义响应式数组
        const messages = reactive([
            { userid: 3, text: '用户zzz给您发送了一条消息', time: '2023年3月3日 08:00' },
            { userid: 2, text: '用户yyy给您发送了一条消息', time: '2023年2月2日 08:00' },
            { userid: 1, text: '用户xxx给您发送了一条消息', time: '2023年1月1日 08:00' },
        ]);
        const notifications = reactive([
            { id: 4, title: '精选花园通知', time: '2023年7月29日 20:00', content: '您的花园“xxx”已入选“精选花园”，可以在“主页-花园管理”中查看~' },
            { id: 3, title: '精选花园通知', time: '2023年7月29日 20:00', content: '您的花园“yyy”已入选“精选花园”，可以在“主页-花园管理”中查看~' },
            { id: 2, title: '意见反馈通知', time: '2023年6月29日 20:00', content: '我们针对您的意见反馈“zzz”作出相应的改善，感谢您提供宝贵的意见~' },
            { id: 1, title: '系统维修通知', time: '2023年5月29日 20:00', content: '2023.6.1全天将对系统进行维修，共享花园届时将无法使用，感谢您的理解。' },
        ]);
        const likes = reactive([
            { id: 4, userid: 65472, likedtype: 'blog', typeid: 2, time: '2023年5月29日 21:00' },
            { id: 3, userid: 65472, likedtype: 'blog', typeid: 1, time: '2023年5月29日 20:00' },
            { id: 2, userid: 1919810, likedtype: 'garden', typeid: 1, time: '2023年5月29日 20:00' },
            { id: 1, userid: 114514, likedtype: 'comment', typeid: 1, time: '2023年5月29日 20:00' }
        ]);
        const replies = reactive([
            { id: 3, userid: 65472, repliedid: 1, time: '2023年7月29日 20:00', content: '你说的对，但是感觉不如原根。原根，是一个数学符号。设m是正整数，a是整数，若a模m的阶等于φ(m)，则称a为模m的一个原根。假设一个数g是P的原根，那么g^i mod P的结果两两不同，且有 1<g<P，0<i<P，归根到底就是g^(P-1) = 1 (mod P)当且仅当指数为P-1的时候成立。(这里P是素数)。你的数学很差，我现在每天用原根都能做1e5次数据规模1e6的NTT，每个月差不多3e6次卷积， 也就是现实生活中3e18次乘法运算，换算过来最少也要算1000年。虽然我只有14岁，但是已经超越了中国绝大多数人(包括你)的水平，这便是原根给我的骄傲的资本。' },
            { id: 2, userid: 1919810, repliedid: 1, time: '2023年6月29日 20:00', content: '你说的对，但​是《你说的对》是由你说的对自主研发的一款全新你说的对。你说的对发生在一个被称作「你说的对」的你说的对世界，在这里被你说的对选中的你说的对将被授予「你说的对」，引导你说的对之力。你将扮演一位名为「你说的对」的神秘角色，在自由的旅行中邂逅你说的对、你说的对的你说的对们，和你说的对一起击败你说的对，寻找失散的你说的对，同时，逐步发掘「你说的对」的真相。' },
            { id: 1, userid: 114514, repliedid: 1, time: '2023年5月29日 20:00', content: '你说的对，但是《论语》 是由孔子的弟子及再传弟子自主记录孔子及其弟子言行而编成的一本全新语录文集。故事发生在一个被称作「春秋」的历史世界，在这里，被圣人选中的人将被授予「朝服」，导引儒家之力。你将扮演一位名为 「衍圣公」的神秘角色，在朝代的更迭中邂逅性格各异、能力独特的帝王们，和他们一起击败强敌，维护崩坏的礼乐——同时，逐步发掘「仁爱」的真相。' },
        ]);

        return {
            activeTab: 'my-messages',
            messages,
            notifications,
            likes,
            replies
        };
    },
    methods: {
        selectTab(tab) {
            this.activeTab = tab;
            this.scrollToTop();
        },
        scrollToTop() {
            const container = document.querySelector('.content');
            container.scrollTop = 0;
        }
    },
};
</script>

  
<style scoped>
.card {
    padding: 2vh;
    border-width: 0vh;
    border-radius: 5vh;
    box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
    background-color: rgb(222, 217, 207);
    margin-top: 3vh;
    margin-bottom: 3vh;
}

.content {
    height: 80vh;
    width: 50vw;
    flex: 1;
    overflow-y: auto;
}

.sidebar {
    height: 80vh;
    width: 14vw;
}

.subcontent {
    margin-bottom: 6vh;
    width: 100%;
    background-color: rgb(244, 237, 228);
    animation: slide-in-from-bottom 1s;
}

.subcontent:hover {
    transform: scale(1.05);
    transition: 1000ms;
}

/* 设置滚动条轨道的样式 */
.content::-webkit-scrollbar-track {
    background-color: #f1f1f1;
}

/* 设置滚动条滑块的样式 */
.content::-webkit-scrollbar-thumb {
    background-color: rgb(99, 110, 115);
    border-radius: 5vh;
}

/* 设置滚动条的整体样式 */
.content::-webkit-scrollbar {
    height: 50%;
    width: 0.5vw;
}

/* 设置滚动条角落的样式 */
.content::-webkit-scrollbar-corner {
    background-color: #f1f1f1;
    border-radius: 5vh;
}

@keyframes fade-in {
    0% {
        opacity: 0;
    }

    100% {
        opacity: 1;
    }
}

@keyframes slide-in-from-bottom {
    from {
        transform: translateY(100%);
    }

    to {
        transform: translateY(0);
    }
}

.heading {
    text-align: center;
    font-size: 3.5vh;
    font-weight: bold;
    color: rgb(12, 60, 38);
}

.colored-line {
    height: 1px;
    background-color: rgb(12, 60, 38);
    margin-top: 2vh;
    margin-bottom: 2vh;
}

.sidebar ul {
    list-style: none;
    margin: 0vh;
    padding: 0vh;
}

.sidebar li {
    cursor: pointer;
    margin-top: 2vh;
    margin-bottom: 2vh;
    margin-left: 1vh;
    margin-right: 1vh;
    color: rgb(99, 110, 115);
    font-size: 16px;
    font-weight: bold;
}

.sidebar li.active {
    color: rgb(12, 60, 38);
    transform: scale(1.1);
    transition: 1000ms;
}

.subcontent-title {
    font-size: 2.5vh;
    font-weight: bold;
    color: rgb(12, 60, 38);
}

.subcontent-time {
    font-size: 2vh;
    font-weight: bold;
    color: rgb(99, 110, 115);
}

.subcontent-text {
    font-size: 2vh;
    color: rgb(12, 60, 38);
}
</style>