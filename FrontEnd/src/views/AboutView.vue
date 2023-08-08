<template>
    <body>
        <div class="container" id="main-container">
            <!-- 导航栏 -->
            <NavBar />

            <!-- 主体 -->
            <div class="row" style="width: 90vw;">
                <!-- 左侧导航栏 -->
                <div class="col-2">
                    <nav id="navbar" class="h-100 flex-column align-items-stretch pe-4 ps-4 border-end">
                        <nav class="nav nav-pills flex-column">
                            <a class="nav-item" href="#project">
                                我们的项目
                            </a>
                            <a class="nav-item" href="#vision">
                                我们的愿景
                            </a>
                            <a class="nav-item" href="#mission">
                                我们的使命
                            </a>
                        </nav>
                    </nav>
                </div>

                <!-- 右侧文本区 -->
                <div class="col-10">
                    <div data-bs-spy="scroll" data-bs-target="#navbar" data-bs-smooth-scroll="true" class="scrollspy"
                        tabindex="0">
                        <!-- 标题 -->
                        <h1 class="heading">关于我们</h1>

                        <div class="d-flex justify-content-center">
                            <!-- 联系方式 -->
                            <div class="canvas-trigger" data-bs-toggle="offcanvas" data-bs-target="#offcanvasContact"
                                aria-controls="offcanvasContact">
                                联系方式
                                <!-- 图标 -->
                                <svg xmlns="http://www.w3.org/2000/svg" width="30" fill="currentColor"
                                    class="bi bi-envelope-fill" viewBox="0 0 16 16">
                                    <path
                                        d="M.05 3.555A2 2 0 0 1 2 2h12a2 2 0 0 1 1.95 1.555L8 8.414.05 3.555ZM0 4.697v7.104l5.803-3.558L0 4.697ZM6.761 8.83l-6.57 4.027A2 2 0 0 0 2 14h12a2 2 0 0 0 1.808-1.144l-6.57-4.027L8 9.586l-1.239-.757Zm3.436-.586L16 11.801V4.697l-5.803 3.546Z" />
                                </svg>
                            </div>

                            <!-- 团队成员 -->
                            <div class="canvas-trigger" data-bs-toggle="offcanvas" data-bs-target="#offcanvasTeam"
                                aria-controls="offcanvasTeam">
                                开发团队
                                <!-- 图标 -->
                                <svg xmlns="http://www.w3.org/2000/svg" width="30" fill="currentColor"
                                    class="bi bi-microsoft-teams" viewBox="0 0 16 16">
                                    <path
                                        d="M9.186 4.797a2.42 2.42 0 1 0-2.86-2.448h1.178c.929 0 1.682.753 1.682 1.682v.766Zm-4.295 7.738h2.613c.929 0 1.682-.753 1.682-1.682V5.58h2.783a.7.7 0 0 1 .682.716v4.294a4.197 4.197 0 0 1-4.093 4.293c-1.618-.04-3-.99-3.667-2.35Zm10.737-9.372a1.674 1.674 0 1 1-3.349 0 1.674 1.674 0 0 1 3.349 0Zm-2.238 9.488c-.04 0-.08 0-.12-.002a5.19 5.19 0 0 0 .381-2.07V6.306a1.692 1.692 0 0 0-.15-.725h1.792c.39 0 .707.317.707.707v3.765a2.598 2.598 0 0 1-2.598 2.598h-.013Z" />
                                    <path
                                        d="M.682 3.349h6.822c.377 0 .682.305.682.682v6.822a.682.682 0 0 1-.682.682H.682A.682.682 0 0 1 0 10.853V4.03c0-.377.305-.682.682-.682Zm5.206 2.596v-.72h-3.59v.72h1.357V9.66h.87V5.945h1.363Z" />
                                </svg>
                            </div>
                        </div>

                        <!-- 分隔线 -->
                        <div class="colored-line"></div>

                        <!-- 联系方式侧边栏 -->
                        <div class="offcanvas offcanvas-end" data-bs-scroll="true" tabindex="-1" id="offcanvasContact"
                            aria-labelledby="offcanvasContactLabel">
                            <!-- 标题 -->
                            <div class="offcanvas-header">
                                <h5 id="offcanvasContactLabel">联系我们</h5>
                                <!-- 关闭按钮 -->
                                <button type="button" class="btn-close" data-bs-dismiss="offcanvas"
                                    aria-label="Close"></button>
                            </div>
                            <!-- 正文 -->
                            <div class="offcanvas-body">
                                <p class="offcanvas-p">如果您对我们的项目感兴趣，</p>
                                <p class="offcanvas-p">或者有任何建议和意见，</p>
                                <p class="offcanvas-p">欢迎随时与我们联系。</p>
                                <p class="offcanvas-p">您可以通过以下方式与我们取得联系：</p>
                                <p class="offcanvas-p">2050633@tongji.edu.cn</p>
                            </div>
                        </div>

                        <!-- 团队成员侧边栏 -->
                        <div class="offcanvas offcanvas-end" data-bs-scroll="true" tabindex="-1" id="offcanvasTeam"
                            aria-labelledby="offcanvasTeamLabel">
                            <!-- 标题 -->
                            <div class="offcanvas-header">
                                <h5 id="offcanvasTeamLabel">团队成员</h5>
                                <!-- 关闭按钮 -->
                                <button type="button" class="btn-close" data-bs-dismiss="offcanvas"
                                    aria-label="Close"></button>
                            </div>
                            <!-- 正文 -->
                            <div class="offcanvas-body">
                                <p class="offcanvas-p">2050633 卢嘉霖</p>
                                <p class="offcanvas-p">2051475 王浩</p>
                                <p class="offcanvas-p">2152814 周成杰</p>
                                <p class="offcanvas-p">2153684 雷扬</p>
                                <p class="offcanvas-p">2153604 郭晓杰</p>
                                <p class="offcanvas-p">2152598 郑皓予</p>
                                <p class="offcanvas-p">2151136 朱开来</p>
                                <p class="offcanvas-p">2151765 张铭宸</p>
                                <p class="offcanvas-p">2151268 李昊诚</p>
                                <p class="offcanvas-p">2151064 余亚辉</p>
                            </div>
                        </div>

                        <!-- 我们的项目 -->
                        <div id="project">
                            <br>
                            <!-- 子标题 -->
                            <h4 class="subheading">
                                我们的项目
                                <!-- 图标 -->
                                <svg xmlns="http://www.w3.org/2000/svg" width="40" fill="currentColor" class="bi bi-cast"
                                    viewBox="0 0 16 16">
                                    <path
                                        d="m7.646 9.354-3.792 3.792a.5.5 0 0 0 .353.854h7.586a.5.5 0 0 0 .354-.854L8.354 9.354a.5.5 0 0 0-.708 0z" />
                                    <path
                                        d="M11.414 11H14.5a.5.5 0 0 0 .5-.5v-7a.5.5 0 0 0-.5-.5h-13a.5.5 0 0 0-.5.5v7a.5.5 0 0 0 .5.5h3.086l-1 1H1.5A1.5 1.5 0 0 1 0 10.5v-7A1.5 1.5 0 0 1 1.5 2h13A1.5 1.5 0 0 1 16 3.5v7a1.5 1.5 0 0 1-1.5 1.5h-2.086l-1-1z" />
                                </svg>
                            </h4>

                            <!--  补充说明-->
                            <h6 class="subsubheading">
                                我们的项目名为“共享花园”，是一个旨在提供学生共享、照顾和美化校园花园的创新平台。<br>
                                我们的使命是通过共享园艺爱好和知识，让校园更美丽，同时为学生提供一个积极参与的社区。
                            </h6>

                            <!-- 网格布局 -->
                            <div class="container text-center">
                                <div class="row row-cols-3">
                                    <div class="col">
                                        <div class="card">
                                            我们的项目名为 "共享花园"，是一个专注于学生参与、照顾和美化校园花园的创新平台。
                                            我们的使命是通过共享园艺爱好和知识，让校园更加美丽，并为学生提供一个积极参与的社区。
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card">
                                            该项目旨在将校园内的闲置、废弃土地改造成由所有学生参与建设和建造的共享花园。其目的是响应国家节能减排号召，
                                            建设绿色低碳校园，积极促进科学、低碳、高效的资源配置模式的发展，推动生态文明建设。
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card">
                                            项目的主要行动是将校园内的闲置废弃土地改造成共享花园，由所有学生参与设计和建造。学生可以通过参与获得积分和奖励。
                                            同时，项目将打造一个内容良好、氛围和谐的共享花园线上社区。
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <br>
                        <br>
                        <br>
                        <br>
                        <br>

                        <!-- 我们的愿景 -->
                        <div id="vision">
                            <br>
                            <br>
                            <!-- 子标题 -->
                            <h4 class="subheading">
                                我们的愿景
                                <!-- 图标 -->
                                <svg xmlns="http://www.w3.org/2000/svg" width="40" fill="currentColor"
                                    class="bi bi-bullseye" viewBox="0 0 16 16">
                                    <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z" />
                                    <path d="M8 13A5 5 0 1 1 8 3a5 5 0 0 1 0 10zm0 1A6 6 0 1 0 8 2a6 6 0 0 0 0 12z" />
                                    <path d="M8 11a3 3 0 1 1 0-6 3 3 0 0 1 0 6zm0 1a4 4 0 1 0 0-8 4 4 0 0 0 0 8z" />
                                    <path d="M9.5 8a1.5 1.5 0 1 1-3 0 1.5 1.5 0 0 1 3 0z" />
                                </svg>
                            </h4>

                            <!-- 补充说明 -->
                            <h6 class="subsubheading">
                                我们的愿景是成为一个充满活力、创意和社会责任的绿色生态共享平台。<br>
                                我们致力于打造一个连接人与自然的桥梁，为社区成员提供一个共享花园的空间，<br>
                                让每个人都能亲近大自然、享受花园带来的美好体验。
                            </h6>

                            <!-- 网格布局 -->
                            <div class="container text-center">
                                <div class="row row-cols-3">
                                    <div class="col">
                                        <div class="card">
                                            绿化环境：<br>
                                            我们希望通过共享花园项目，促进城市绿化和环境保护。
                                            每个共享花园都将成为一个绿洲，为城市增添生机和美丽。
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card">
                                            社区凝聚：<br>
                                            我们希望拉近社区居民之间的距离，促进邻里之间的交流和合作。
                                            花园成为人们相聚、交流的场所，增进社区凝聚力。
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card">
                                            教育与启发：<br>
                                            我们希望共享花园不仅仅是花草树木的聚集地，更是一个教育和启发的场所。
                                            通过举办园艺知识分享、绿色环保活动等，让人们更深入了解大自然，提高生态意识。
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card">
                                            健康与幸福：<br>
                                            我们相信花园的美景和绿色环境对人们的身心健康有着积极的影响。
                                            我们希望让更多人拥有身心愉悦的时刻，感受大自然的美好。
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card">
                                            社会责任：<br>
                                            我们视社会责任为己任，在项目的运营和管理中，积极参与社会公益活动，回馈社会，推动可持续发展。
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card">
                                            创新与共享：<br>
                                            我们鼓励创新思维和共享精神。共享花园项目不仅仅是一个地方，更是一个社群，
                                            鼓励学生、园艺爱好者和各界人士共同参与和贡献。
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!-- 补充说明 -->
                            <h6 class="subsubheading">
                                我们的愿景是打造一个和谐、美丽的共享花园社区，为每个人创造一个与自然相融的绿色天地，让花园之美成为城市的共同财富。<br>
                                我们希望通过共同努力，让花园的美丽绽放在每一个人的心中，成就一个更美好的明天。
                            </h6>
                        </div>

                        <br>
                        <br>
                        <br>

                        <!-- 我们的使命 -->
                        <div id="mission">
                            <br>
                            <br>
                            <!-- 子标题 -->
                            <h4 class="subheading">
                                我们的使命
                                <!-- 图标 -->
                                <svg xmlns="http://www.w3.org/2000/svg" width="40" fill="currentColor"
                                    class="bi bi-list-task" viewBox="0 0 16 16">
                                    <path fill-rule="evenodd"
                                        d="M2 2.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5V3a.5.5 0 0 0-.5-.5H2zM3 3H2v1h1V3z" />
                                    <path
                                        d="M5 3.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zM5.5 7a.5.5 0 0 0 0 1h9a.5.5 0 0 0 0-1h-9zm0 4a.5.5 0 0 0 0 1h9a.5.5 0 0 0 0-1h-9z" />
                                    <path fill-rule="evenodd"
                                        d="M1.5 7a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5H2a.5.5 0 0 1-.5-.5V7zM2 7h1v1H2V7zm0 3.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5H2zm1 .5H2v1h1v-1z" />
                                </svg>
                            </h4>

                            <!-- 补充说明 -->
                            <h6 class="subsubheading">
                                我们的使命是通过共享花园项目，为社会创造一个可持续发展的绿色生态共享平台。<br>
                                我们坚信花园不仅仅是一片绿色，更是一种生活态度和社会责任的体现。<br>
                                在共享花园项目中，我们承载着以下使命：
                            </h6>

                            <!-- 网格布局 -->
                            <div class="container text-center">
                                <div class="row row-cols-3">
                                    <div class="col">
                                        <div class="card">
                                            推动环保与可持续发展：<br>
                                            我们致力于推动环保和可持续发展理念在社会中的传播和实践。通过共享花园，我们鼓励人们关注生态环境，
                                            采取更环保的生活方式，减少对自然资源的消耗，共同构建可持续的未来。
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card">
                                            促进社区互助与合作：<br>
                                            我们希望通过共享花园项目，搭建起一个社区互助和合作的平台。
                                            花园成为人们共同参与、共同管理的场所，增进社区居民之间的友谊和互动，共同创造美好的花园环境。
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card">
                                            传承园艺文化与知识：<br>
                                            我们珍视园艺文化的传承和知识的传递。共享花园不仅是花草树木的聚集地，
                                            更是园艺知识的分享和学习平台。我们鼓励人们相互交流园艺心得，传承园艺智慧，让园艺文化薪火相传。
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card">
                                            促进城市绿化和美化：<br>
                                            我们希望共享花园成为城市绿化和美化的助力。通过共同努力，
                                            让每个角落都充满花园的美丽，打造一个令人心旷神怡的城市绿洲。
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card">
                                            培养生态意识与责任感：<br>
                                            我们认为生态意识和责任感是每个人应当具备的品质。
                                            在共享花园项目中，我们鼓励人们学习尊重大自然、保护环境的观念，从小事做起，践行绿色生活。
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="card">
                                            共创美好未来：<br>
                                            我们相信每个人的努力都能汇聚成美好的力量。
                                            共享花园项目是一个共同创造的过程，我们鼓励学生、志愿者和社区成员一起携手，共创美好未来。
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!-- 补充说明 -->
                            <h6 class="subsubheading">
                                我们的使命是用绿色、生态的方式，将人与自然融为一体，推动社会绿色发展，培养更多关爱环境、热爱大自然的社会公民。<br>
                                我们希望共享花园成为一个爱心和创意的汇聚地，为社会贡献一份美丽和温暖。<br>
                                让我们携手前行，用行动去诠释共享花园项目的使命与价值。
                            </h6>
                        </div>

                        <br>
                        <br>
                        <br>
                        <br>
                        <br>
                    </div>
                </div>
            </div>
        </div>
    </body>
</template>

<script>
export default {
    name: 'AboutView',
};
</script>

  
<style scoped>
body {
    background-color: rgb(244, 237, 228);
}

#main-container {
    margin-top: 9vh;
    margin-left: 0vw;
    margin-right: 0vw;
    width: 100vw;
}

#project {
    background-image: url("../assets/img-all-kinds-of-companies.jpg");
    background-size: auto;
    background-repeat: no-repeat;
    position: relative;
    background-position: top right;
    animation: fade-in 3s forwards;
}

#vision {
    background-image: url("../assets/img-amazing-things.jpg");
    background-size: auto;
    background-repeat: no-repeat;
    position: relative;
    background-position: top right;
    animation: fade-in 3s forwards;
}

#mission {
    background-image: url("../assets/img-teamwork.jpg");
    background-size: auto;
    background-repeat: no-repeat;
    position: relative;
    background-position: top right;
    animation: fade-in 3s forwards;
}

@keyframes fade-in {
    0% {
        opacity: 0;
    }

    100% {
        opacity: 1;
    }
}

#navbar {
    position: fixed;
    padding: 0;
    margin: 0;
}

.canvas-trigger {
    margin-top: 3vh;
    margin-bottom: 3vh;
    margin-left: 5vw;
    margin-right: 5vw;
    font-size: 3vh;
    color: rgb(12, 60, 38);
    animation: slide-in-from-top 2s;
}

.canvas-trigger:hover {
    cursor: pointer;
    font-weight: bold;
    transform: scale(1.2);
    transition: 500ms;
}

.nav-item {
    padding: 5px;
    margin: 10px;
    border-width: 0vh;
    font-size: 2.5vh;
    color: rgb(12, 60, 38);
    background-color: rgb(244, 237, 228);
    text-decoration: none;
    animation: slide-in-from-left 2.5s;
}

.nav-item:hover {
    font-weight: bold;
    transform: scale(1.2);
    transition: 500ms;
}

@keyframes slide-in-from-left {
    from {
        transform: translateX(-200%);
    }

    to {
        transform: translateX(0);
    }
}

.colored-line {
    height: 1px;
    background-color: rgb(12, 60, 38);
    margin-top: 5vh;
    margin-bottom: 10vh;
}

.heading {
    text-align: center;
    font-weight: bold;
    font-size: 6vh;
    color: rgb(12, 60, 38);
    margin-top: 8vh;
    margin-bottom: 8vh;
    animation: slide-in-from-top 1.5s;
}

@keyframes slide-in-from-top {
    from {
        transform: translateY(-200%);
    }

    to {
        transform: translateY(0);
    }
}

.subheading {
    font-size: 4vh;
    font-weight: bold;
    color: rgb(12, 60, 38);
    margin-top: 10vh;
    margin-bottom: 10vh;
}

.subsubheading {
    font-size: 2vh;
    color: rgb(12, 60, 38);
    margin-top: 10vh;
    margin-bottom: 10vh;
}

#offcanvasContactLabel {
    font-weight: bold;
    font-size: 3vh;
    color: rgb(12, 60, 38);
    margin-top: 5vh;
    margin-bottom: 5vh;
}

#offcanvasTeamLabel {
    font-weight: bold;
    font-size: 3vh;
    color: rgb(12, 60, 38);
    margin-top: 5vh;
    margin-bottom: 5vh;
}

.offcanvas-p {
    text-align: center;
    font-size: 2vh;
    color: rgb(12, 60, 38);
    margin-top: 3vh;
    margin-bottom: 3vh;
}

.card {
    height: 25vh;
    width: 20vw;
    margin-top: 3vh;
    margin-bottom: 3vh;
    padding: 3vh;
    border-width: 0vh;
    border-radius: 3vh;
    font-size: 2vh;
    color: rgb(12, 60, 38);
    background-color: rgb(228, 220, 220);
    user-select: none;
}

.card:hover {
    transform: scale(1.25);
    transition: 500ms;
    box-shadow: 4px 4px 4px rgba(0, 0, 0, 0.2);
    font-weight: bold;
    color: rgb(11, 94, 215);
}
</style>