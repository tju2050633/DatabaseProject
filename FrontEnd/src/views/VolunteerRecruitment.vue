<template>
    <div class="container" style="margin-top: 60px;">
    <!-- 导航栏 -->
    <NavBar/>

    <el-row id="mainpart">
        <!-- 侧边栏 -->
        <SideBar/>
        <!-- 主体 -->
        <el-col :span="13">
            <el-container>
                <!-- 标签栏 -->
                <br>
                <el-header><h1>志愿者招募</h1></el-header>
                <!-- 志愿信息 -->
                <el-main>
                    <!--这里实际项目中应该为数据库读取并展示-->
                    <el-card v-for="(content, index) in volunteerContent" :key="index"
                        style="margin: 20px;box-shadow: 0 10px 18px rgba(0, 0, 0, 0.53);">
                        <VolunteerBlock :content="content"/>

                        <!--志愿问卷-->
                        <span>
                        <el-button @click="volunteerDialog.dialogVisible = true" style="margin-top: 10px;">
                            {{ '我要报名' }}
                        </el-button>
                        <el-button @click="this.$router.push('/garden/')" style="margin-top: 10px;">
                            {{ '进入花园' }}
                        </el-button>
                        </span>
                        <el-dialog v-model="volunteerDialog.dialogVisible" title="Shipping address">
                            <el-form :model="form">
                                <el-form-item label="你的名字" :label-width="formLabelWidth">
                                    <el-input v-model="volunteerDialog.volunteername" style="width: 140px" autocomplete="off" />
                                </el-form-item>
                                <el-form-item label="电话号码" :label-width="formLabelWidth">
                                    <el-input v-model="volunteerDialog.phonenumber" style="width: 200px" autocomplete="off" />
                                </el-form-item>
                                <el-form-item label="选择日期" :label-width="formLabelWidth">
                                    <el-select v-model="volunteerDialog.dayOfWeek" class="m-2" placeholder="星期" >
                                        <el-option v-for="item in week" 
                                        :key="item.value" :label="item.label" :value="item.value"/>
                                    </el-select>
                                    <el-time-select v-model="volunteerDialog.time" start="08:30" step="00:15" 
                                end="18:30" placeholder="选择时间"/>
                                </el-form-item>
                                    <el-form-item label="自我描述" :label-width="formLabelWidth">
                                        <el-input v-model="volunteerDialog.describe" 
                                        :autosize="{ minRows: 2, maxRows: 10 }" type="textarea" placeholder="here"/>
                                        <div style="margin: 20px 0" />
                                    </el-form-item>
                            </el-form>                            
                            <template #footer>
                                <span class="dialog-footer">
                                    <el-button @click="volunteerDialog.dialogVisible = false">
                                        Cancel
                                    </el-button>
                                    <el-button type="primary" @click="volunteerDialog.dialogVisible = false">
                                        Confirm
                                    </el-button>
                                </span>
                            </template>
                        </el-dialog>
                    </el-card>
                </el-main>
            </el-container>
        </el-col>

        <!-- 志愿工作榜 -->
        <el-col :span="8">
            <el-container>
                <br>
                <i class="el-icon-star-on"></i>
                <el-header><h2>志愿工作榜</h2></el-header>
                <el-main>                   
                 <el-col v-for="(item, index) in displayedImageList" :key="index">
                    <el-card @click="this.$router.push('/personalInfo/')">                          
                        <span><h4>                           
                            {{ item.description }}&ensp;                          
                            <el-icon style="margin-top: 20px"><user /></el-icon>
                            {{ item.username }}&ensp;
                            {{ item.myPoints }}
                        </h4></span>                                
                    </el-card>
                </el-col>                    
                    <br>
                    <el-button @click="toggleShowMore" style="margin-top: 10px;">{{ showMore ? '收起' : '显示更多' }}</el-button>
                </el-main>
            </el-container>
        </el-col>
    </el-row>
    </div>
</template>

<style></style>

<script>

export default ({
    el: '#mainpart',
    data() {
        return {
            showMore: false, // 控制是否显示更多
            displayedImageList: [], // 实际显示的列表
            maxDisplayCount: 3, // 默认显示的数量

            imageList: [
                {
                    description: 'TOP1 ',
                    username:'王浩',
                    myPoints:'256',
                },
                {
                    description: 'TOP2 ',
                    username:'王浩二',
                    myPoints:'246',
                },
                {
                    description: 'TOP3 ',
                    username:'王浩三',
                    myPoints:'240',

                },
                {
                    description: 'TOP4 ',
                    username:'王浩四',
                    myPoints:'235',

                },
                {
                    description: 'TOP5 ',
                    username:'王浩五',
                    myPoints:'230',

                },
                {
                    description: 'TOP6 ',
                    username:'王浩六',
                    myPoints:'226',

                },
                {
                    description: 'TOP7 ',
                    username:'王浩七',
                    myPoints:'210',

                },
                {
                    description: 'TOP8 ',
                    username:'王浩八',
                    myPoints:'200',

                },
                {
                    description: 'TOP9 ',
                    username:'王浩九',
                    myPoints:'156',
                },
                {
                    description: 'TOP10 ',
                    username:'王浩十',
                    myPoints:'56',
                },
            ],
            volunteerContent: [
                {
                    imageUrl: require('../assets/Garden-e.jpg'),
                    dialogVisible:false,//是否出现弹窗
                    username: 'Student1',
                    gardenname: '王浩的后宫1',
                    location:'嘉定校区19号楼',
                    describe: `诚邀您来维护本花园，主要工作如下：
                    首先，帮我把花园的土给翻了
                    然后，我的花园一盆花都没有，帮我全买了 
                    最后帮我浇水
                    谢谢你`,
                },
                {
                    imageUrl: require('../assets/Garden-e.jpg'),
                    dialogVisible:false,
                    username: 'Student2',
                    gardenname: 'Garden2',
                    location:'嘉定校区19号楼',
                    describe: `诚邀您来维护本花园，主要工作如下：
                    首先，帮我把花园的土给翻了
                    然后，我的花园一盆花都没有，帮我全买了 
                    最后帮我浇水
                    谢谢你`,
                },
                {
                    imageUrl: require('../assets/Garden-e.jpg'),
                    dialogVisible:false,
                    username: 'Student3',
                    gardenname: 'Garden3',
                    location:'嘉定校区19号楼',
                    describe: `诚邀您来维护本花园，主要工作如下：
                    首先，帮我把花园的土给翻了
                    然后，我的花园一盆花都没有，帮我全买了 
                    最后帮我浇水
                    谢谢你`,
                },
                {
                    imageUrl: require('../assets/Garden-e.jpg'),
                    dialogVisible:false,
                    username: 'Student4',
                    gardenname: 'Garden4',
                    location:'嘉定校区19号楼',
                    describe: `诚邀您来维护本花园，主要工作如下：
                    首先，帮我把花园的土给翻了
                    然后，我的花园一盆花都没有，帮我全买了 
                    最后帮我浇水
                    谢谢你`,
                },
            ],
            volunteerDialog:[
                {
                    dialogVisible:false,//是否出现弹窗
                    ownername: 'Student1',
                    volunteername:'',
                    phonenumber:'',
                    time:'',
                    dayOfWeek:'',
                    describe:'',
                },
            ],
            week:[
                { value:'星期一', label:'星期一',},{ value:'星期二', label:'星期二',},
                { value:'星期三', label:'星期三',},{ value:'星期四', label:'星期四',},
                { value:'星期五', label:'星期五',},{ value:'星期六', label:'星期六',},
                { value:'星期日', label:'星期日',},
            ],
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
