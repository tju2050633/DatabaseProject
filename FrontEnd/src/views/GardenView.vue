<template>
    <div class="container" style="margin-top: 60px;">
    <!-- 导航栏 -->
    <NavBar/>

    <el-row id="mainpart">
        <!-- 侧边栏 -->
        <SideBar/>
        
        <el-col :span="15">
            <el-card style="margin-top:10px;margin-left: 20px; margin-right: 20px">
                <el-row style="font-size: x-large">
                    <el-col :span="1" :offset="4">
                        <el-icon style="margin-top: 5px">
                            <user />
                        </el-icon>
                    </el-col>
                    <el-col :span="2">楚杰</el-col>
                    <el-col :span="6" :offset="2">杰哥的自习室</el-col>
                    <el-col :span="1" :offset="2">
                        <el-icon style="margin-top: 5px">
                            <star />
                        </el-icon>
                    </el-col>
                    <el-col :span="2">54</el-col>
                    <el-button @click="this.$router.push('/display')">返回展厅</el-button>
                </el-row>
            </el-card>

            <el-card style="margin-top: 20px; margin-left: 20px; margin-right: 20px">
                <el-carousel indicator-position="outside">
                    <el-carousel-item v-for="(item, index) in imageList" :key="index">
                        <img :src="item.imageUrl" alt="花园" style="width: 100%">
                    </el-carousel-item>
                </el-carousel>
                <h1>描述
                    <el-icon style="margin-top: 10px;">
                        <house />
                    </el-icon>
                </h1>
                <div>
                    <br>
                    &nbsp;&nbsp;&nbsp;&nbsp;在这个梦幻般的A花园里，自然与人工的完美融合令人惊叹。踏入花园的瞬间，弥漫着清新的花香，让人心情为之一振。漫步其中，映入眼帘的是一片色彩斑斓的花海，各种绚丽多姿的花朵竞相绽放，彼此交织成一幅绚烂的画卷。
                    沿着曲折的小径，脚下软软的绿草踏起来舒适宜人，仿佛走在大自然的怀抱中。这些小径通向不同的角落，让人好奇地探索着。林荫小道在夏日的阳光下，投下斑驳的树影，让人感受到阵阵清凉。在炎热的日子，这里是避暑的好去处。
                    <br>
                </div>
                <h1>
                    地点
                    <el-icon style="margin-top: 10px;">
                        <position />
                    </el-icon>
                </h1>
                <div><br>安楼后的小树林<br><br><br></div>

                <div class="comment-box" style="width: 100%;height: 200px;resize: none;margin-bottom: 10px;">
                    <textarea v-model="comment" placeholder="写下您的评论..."></textarea>
                    <button style="background-color: #68b1fe;color: #fff;border: none;padding: 10px 15px;cursor: pointer;"
                        @click="submitComment">提交评论</button>
                </div>
            </el-card>
        </el-col>
    </el-row>
    </div>
</template>
  
  
<style scoped>
.logo {
    border-radius: 50%;
    width: 50px;
}

.logo-text {
    margin-top: 10px;
}

textarea {
    width: 100%;
    height: 100px;
    resize: none;
    margin-bottom: 10px;
}
</style>
  
  
<script>
export default {
    name: "app",
    data() {
        return {
            comment: "", // 存储用户输入的评论内容
            searchData: "",
            imageList: [
                {
                    imageUrl: require('../assets/Garden.jpg'),
                },
                {
                    imageUrl: require('../assets/Garden.jpg'),
                },
                {
                    imageUrl: require('../assets/Garden.jpg'),
                },
                {
                    imageUrl: require('../assets/Garden.jpg'),
                },
            ],
        };
    },
    methods: {
        submitComment() {
            // 在此处添加提交评论的逻辑，例如将评论内容发送到后端服务器保存等
            console.log("提交评论:", this.comment);
            // 清空输入框
            this.comment = "";
        },
    },
};
</script>
  
  