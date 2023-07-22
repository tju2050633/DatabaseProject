<template>
    <body>
        <div class="container" style="margin-top: 60px;">
            <div class="row">
                <!-- 左侧导航栏 -->
                <div class="col-2">
                    <nav id="navbar" class="h-100 flex-column align-items-stretch pe-4 border-end">
                        <nav class="nav nav-pills flex-column">
                            <a class="btn btn-outline-success" href="#project">我们的项目</a>
                            <a class="btn btn-outline-success" href="#vision">我们的愿景</a>
                            <a class="btn btn-outline-success" href="#mission">我们的使命</a>
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
                            <!-- 联系方式按钮 -->
                            <button class="btn btn-outline-success btn-lg" type="button" data-bs-toggle="offcanvas"
                                data-bs-target="#offcanvasContact" aria-controls="offcanvasContact">联系方式</button>

                            <!-- 团队成员按钮 -->
                            <button class="btn btn-outline-success btn-lg" type="button" data-bs-toggle="offcanvas"
                                data-bs-target="#offcanvasTeam" aria-controls="offcanvasTeam">开发团队</button>
                        </div>

                        <!-- 联系方式侧边栏 -->
                        <div class="offcanvas offcanvas-start" data-bs-scroll="true" tabindex="-1" id="offcanvasContact"
                            aria-labelledby="offcanvasContactLabel">
                            <div class="offcanvas-header">
                                <h5 id="offcanvasContactLabel" style="text-align: center;">联系我们</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="offcanvas"
                                    aria-label="Close"></button>
                            </div>
                            <div class="offcanvas-body">
                                <p class="offcanvas-p">如果您对我们的项目感兴趣，</p>
                                <p class="offcanvas-p">或者有任何建议和意见，</p>
                                <p class="offcanvas-p">欢迎随时与我们联系。</p>
                                <p class="offcanvas-p">您可以通过以下方式与我们取得联系：</p>
                                <p class="offcanvas-p">2050633@tongji.edu.cn</p>
                            </div>
                        </div>

                        <!-- 团队成员侧边栏 -->
                        <div class="offcanvas offcanvas-start" data-bs-scroll="true" tabindex="-1" id="offcanvasTeam"
                            aria-labelledby="offcanvasTeamLabel">
                            <div class="offcanvas-header">
                                <h5 id="offcanvasTeamLabel" style="text-align: center;">团队成员</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="offcanvas"
                                    aria-label="Close"></button>
                            </div>
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

                        <div id="project">
                            <h4 class="subheading">我们的项目</h4>
                            <p class="maintext-p">我们的项目名为“共享花园”，是一个旨在提供学生共享、照顾和美化校园花园的创新平台。
                                我们的使命是通过共享园艺爱好和知识，让校园更美丽，同时为学生提供一个积极参与的社区。</p>
                            <p class="maintext-p">
                                该项目旨在将校园内的闲置、废弃土地改造成由所有学生参与建设和建造的共享花园。其目的是响应国家节能减排号召，
                                建设绿色低碳校园，积极促进科学、低碳、高效的资源配置模式的发展，推动生态文明建设。</p>
                            <p class="maintext-p">
                                项目的主要行动是将校园内的闲置废弃土地改造成共享花园，由所有学生参与设计和建造。学生可以通过参与获得积分和奖励。
                                同时，项目将打造一个内容良好、氛围和谐的共享花园线上社区。</p>
                            <p class="maintext-p">项目主要功能包括用户注册登录系统、花园创建和维护系统、
                                评分评论和举报系统、志愿者招募系统、积分奖励系统和管理员审核系统。</p>
                        </div>
                        <div id="vision">
                            <h4 class="subheading">我们的愿景</h4>
                            <p class="maintext-p">我们的愿景是成为一个充满活力、创意和社会责任的绿色生态共享平台。我们致力于打造一个连接人与自然的桥梁，
                                为社区成员提供一个共享花园的空间，让每个人都能亲近大自然、享受花园带来的美好体验。</p>
                            <p class="maintext-p">我们希望通过共享花园项目，实现以下目标：</p>
                            <p class="maintext-p">绿化环境：我们希望通过共享花园项目，促进城市绿化和环境保护。每个共享花园都将成为一个绿洲，为城市增添生机和美丽。</p>
                            <p class="maintext-p">社区凝聚：我们希望拉近社区居民之间的距离，促进邻里之间的交流和合作。花园成为人们相聚、交流的场所，增进社区凝聚力。</p>
                            <p class="maintext-p">
                                教育与启发：我们希望共享花园不仅仅是花草树木的聚集地，更是一个教育和启发的场所。通过举办园艺知识分享、绿色环保活动等，让人们更深入了解大自然，提高生态意识。</p>
                            <p class="maintext-p">健康与幸福：我们相信花园的美景和绿色环境对人们的身心健康有着积极的影响。我们希望让更多人拥有身心愉悦的时刻，感受大自然的美好。</p>
                            <p class="maintext-p">社会责任：我们视社会责任为己任，在项目的运营和管理中，积极参与社会公益活动，回馈社会，推动可持续发展。</p>
                            <p class="maintext-p">创新与共享：我们鼓励创新思维和共享精神。共享花园项目不仅仅是一个地方，更是一个社群，鼓励学生、园艺爱好者和各界人士共同参与和贡献。</p>
                            <p class="maintext-p">
                                我们的愿景是打造一个和谐、美丽的共享花园社区，为每个人创造一个与自然相融的绿色天地，让花园之美成为城市的共同财富。
                                我们希望通过共同努力，让花园的美丽绽放在每一个人的心中，成就一个更美好的明天。</p>
                        </div>
                        <div id="mission">
                            <h4 class="subheading">我们的使命</h4>
                            <p class="maintext-p">我们的使命是通过共享花园项目，为社会创造一个可持续发展的绿色生态共享平台。
                                我们坚信花园不仅仅是一片绿色，更是一种生活态度和社会责任的体现。在共享花园项目中，我们承载着以下使命：</p>
                            <p class="maintext-p">推动环保与可持续发展：我们致力于推动环保和可持续发展理念在社会中的传播和实践。
                                通过共享花园，我们鼓励人们关注生态环境，采取更环保的生活方式，减少对自然资源的消耗，共同构建可持续的未来。</p>
                            <p class="maintext-p">促进社区互助与合作：我们希望通过共享花园项目，搭建起一个社区互助和合作的平台。
                                花园成为人们共同参与、共同管理的场所，增进社区居民之间的友谊和互动，共同创造美好的花园环境。</p>
                            <p class="maintext-p">传承园艺文化与知识：我们珍视园艺文化的传承和知识的传递。共享花园不仅是花草树木的聚集地，
                                更是园艺知识的分享和学习平台。我们鼓励人们相互交流园艺心得，传承园艺智慧，让园艺文化薪火相传。</p>
                            <p class="maintext-p">促进城市绿化和美化：我们希望共享花园成为城市绿化和美化的助力。通过共同努力，
                                让每个角落都充满花园的美丽，打造一个令人心旷神怡的城市绿洲。</p>
                            <p class="maintext-p">培养生态意识与责任感：我们认为生态意识和责任感是每个人应当具备的品质。
                                在共享花园项目中，我们鼓励人们学习尊重大自然、保护环境的观念，从小事做起，践行绿色生活。</p>
                            <p class="maintext-p">共创美好未来：我们相信每个人的努力都能汇聚成美好的力量。
                                共享花园项目是一个共同创造的过程，我们鼓励学生、志愿者和社区成员一起携手，共创美好未来。</p>
                            <p class="maintext-p">我们的使命是用绿色、生态的方式，将人与自然融为一体，推动社会绿色发展，培养更多关爱环境、热爱大自然的社会公民。
                                我们希望共享花园成为一个爱心和创意的汇聚地，为社会贡献一份美丽和温暖。让我们携手前行，用行动去诠释共享花园项目的使命与价值。</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </body>
</template>

<script>
export default {
    name: 'AboutView',
    components: {
    }
};
</script>

  
<style scoped>
#navbar {
    position: fixed;
}

.btn {
    margin-top: 20px;
    margin-bottom: 20px;
}

.heading {
    text-align: center;
    margin-top: 50px;
    margin-bottom: 50px;
}

.subheading {
    margin-top: 50px;
    margin-bottom: 50px;
}

.btn {
    margin: 30px;
}

.offcanvas-p {
    text-align: center;
}

.maintext-p {
    text-indent: 2em;
}
</style>