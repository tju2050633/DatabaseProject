<template>
    <div class="container" style="margin-top: 60px;">
        <NavBar />
        <el-row>
            <SideBar />
            <el-col :span="16">
                <div class="point-mall-view">
                    <el-card style="margin-left:10px;margin-bottom: 20px;">
                        <img src="../assets/GardenAct-logo.png">
                    </el-card>
                    <el-card  v-for="(item, index) in GardenAct" :key="index" style="margin-top: 20px;margin-left: 10px;padding: 10px;">
                        <h2>
                            <img class="author-avatar-img" :src="item.avatar" @click="this.$router.push('/personalInfo/')" alt="作者头像">
                            <span @click="this.$router.push('/personal/')">{{ item.author }}</span>
                        </h2>
                        <h4> <span @click="this.$router.push('/personal/')">{{ item.title }}</span></h4>
                        <div @click="this.$router.push('/personal/')"><img :src="item.imageurl" alt="花园" style="width: 43vw; height: 30vh; margin-bottom: 10px;"></div>
                        <h4>时间：{{ item.time }}</h4>
                        <h4>地点：{{ item.address }}</h4>
                        <h4>细节：{{ item.detail }}</h4>
                        <div class='button-container'>
                            <el-button @click="this.$router.push('/garden/')">查看详情</el-button>
                            <el-button>报名参加</el-button>
                        </div>
                    </el-card>
                </div>
            </el-col>
        </el-row>
    </div>
</template>

<script>
export default {
    data() {
        return {
            GardenAct:[
                {
                author:'楚杰',
                title:'杰哥的安楼自习室',
                avatar: require('../assets/author-avatar.jpg'),
                imageurl:require('../assets/Garden.jpg'),
                time:'2020年1月1日',
                address:'安楼后面的小树林',
                detail:'给你看点好康的'
                },
                {
                author:'楚杰',
                title:'杰哥的安楼自习室',
                avatar: require('../assets/author-avatar.jpg'),
                imageurl:require('../assets/Garden.jpg'),
                time:'2020年1月1日',
                address:'安楼后面的小树林',
                detail:'给你看点好康的'
                },
                {
                author:'楚杰',
                title:'杰哥的安楼自习室',
                avatar: require('../assets/author-avatar.jpg'),
                imageurl:require('../assets/Garden.jpg'),
                time:'2020年1月1日',
                address:'安楼后面的小树林',
                detail:'给你看点好康的'
                },
                {
                author:'楚杰',
                title:'杰哥的安楼自习室',
                avatar: require('../assets/author-avatar.jpg'),
                imageurl:require('../assets/Garden.jpg'),
                time:'2020年1月1日',
                address:'安楼后面的小树林',
                detail:'给你看点好康的'
                },
                {
                author:'楚杰',
                title:'杰哥的安楼自习室',
                avatar: require('../assets/author-avatar.jpg'),
                imageurl:require('../assets/Garden.jpg'),
                time:'2020年1月1日',
                address:'安楼后面的小树林',
                detail:'给你看点好康的'
                }
            ]
        }
    }
}
</script>

<style>
    .author-avatar-img {
        cursor: pointer;
        width: 80px;
        height: 80px;
        border-radius: 50%;
        object-fit: cover;
    }
    .button-container {
        text-align: center;
    }
</style>