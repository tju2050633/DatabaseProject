<template>
    <body>
      <div class="common-layout">
        <el-container class="personalinfo" style="height:100vw">
          <el-header>Header</el-header>
          <el-container>
            <el-aside width="200px"><el-row >
              <el-col :span="3">
                <el-menu>
                  <el-sub-menu index="1">
                    <template #title>
                      <el-icon><user /></el-icon>
                      <span>账号管理</span>
                    </template>
                    <el-menu-item index="1-1" @click="this.$router.push({ name: 'personal' })">我的主页</el-menu-item>
                    <el-menu-item index="1-2" @click="this.$router.push({ name: 'personalInfo' })">登入/登出</el-menu-item>
                  </el-sub-menu>
                  <el-sub-menu index="2">
                    <template #title>
                      <el-icon><position /></el-icon>
                      <span>校园地图</span>
                    </template>
                    <el-menu-item index="2-1" @click="this.$router.push('/login/')">四平路校区</el-menu-item>
                    <el-menu-item index="2-2" @click="this.$router.push('/login/')">嘉定校区</el-menu-item>
                    <el-menu-item index="2-3" @click="this.$router.push('/login/')">沪西校区</el-menu-item>
                  </el-sub-menu>
                  <el-sub-menu index="3">
                    <template #title>
                      <el-icon><house /></el-icon>
                      <span>花园管理</span>
                    </template>
                    <el-menu-item index="3-1" @click="this.$router.push('/login/')">精选花园</el-menu-item>
                    <el-menu-item index="3-2" @click="this.$router.push('/login/')">我的花园</el-menu-item>
                  </el-sub-menu>
                  <el-sub-menu index="4">
                    <template #title>
                      <el-icon><chatSquare /></el-icon>
                      <span>博客论坛</span>
                    </template>
                    <el-menu-item index="4-1" @click="this.$router.push('/login/')">精选博客</el-menu-item>
                    <el-menu-item index="4-2" @click="this.$router.push('/login/')">我的发表</el-menu-item>
                  </el-sub-menu>
                </el-menu>
              </el-col>
            </el-row></el-aside>

            <el-container class="info">
              <el-main>
                <el-row class="top-image" body-style="heigh:500px ">
                  <el-col :span='24'>
                     <el-image style="width: 100vw; height: 30vh" :src="url" :fit="fill" />
                  </el-col>
                </el-row>


                  <el-row :gutter="20" >
                    <el-col :span="4">
                      <el-avatar :size="350" :src="avaUrl" />
                      <span size="large" style="font-size:xx-large">{{ UserInfo.name }}</span>
                    </el-col>
                    
                    <el-col :span="6" style="margin-bottom:0"><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
                      <span style="font-size:x-large">个人描述：</span>
                      <el-row>
                      <span  v-if="!change" style="text-align:center">{{ UserInfo.Description }}</span>
                      <el-input class="username-change" style="font-size:large" v-if="change"  v-model="UserInfo.Description" @change="InfoHasChanged()"/></el-row>
                    </el-col>
                    <el-col :span="6"><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><el-button type="danger" @click="changeInfo">修改信息</el-button></el-col>
                  </el-row>
                  <br/>

                  <el-card style="width=50vw">
                  <el-row :gutter='30'>
                    <el-col :span="6"><span style="font-size:x-large">邮箱：</span>
                      <el-row>
                      <span v-if="!change">{{ UserInfo.email }}</span>
                      <el-input class="email-change" v-if="change" v-model="UserInfo.email" @change="InfoHasChanged()"/>
                      </el-row>
                    </el-col>
                    <el-col :span="6"><span style="font-size:x-large">注册时间：</span>
                      <el-row><span >{{ UserInfo.registerTime }}</span></el-row>
                    </el-col>
                  </el-row>
                  
                  <br/>
                  <el-row :gutter='30'>
                    <el-col :span="6"><span style="font-size:x-large">积分：</span>
                      <el-row><span >{{ UserInfo.points }}</span></el-row>
                    </el-col>
                    <el-col :span="8"> 
                      <el-row>
                        <el-col :span='10'><el-button type="primary" icon="Lock" circle size="medium" @click="ifshowTel"/><span style="font-size:x-large">手机号：</span>
                        <el-row v-if="!change"><span v-if="showtel&&!change">{{ UserInfo.tel }}</span> <span v-if="!showtel&&!change">***</span></el-row>
                        <el-input class="tel-change" v-if="change" v-model="UserInfo.tel" @change="InfoHasChanged()"/></el-col>
                      </el-row>
                    </el-col>
                    <el-col :span="4"></el-col>
                  </el-row></el-card>

                  <br/>
                  <br/>
                  <br/>
                  <br/>
                  <br/>
                  <el-row :gutter="30">
                    <el-col :offset="1">
                    <el-breadcrumb separator="|" style="font-size:x-large">
                      <el-breadcrumb-item :to="{}" ></el-breadcrumb-item>
                      <el-breadcrumb-item :to="{}" @click="refresh(1)">互动</el-breadcrumb-item>
                      <el-breadcrumb-item :to="{}" @click="refresh(2)">博客</el-breadcrumb-item>
                      <el-breadcrumb-item :to="{}" @click="refresh(3)">花园</el-breadcrumb-item>
                      <el-breadcrumb-item :to="{}" @click="refresh(4)">工作记录</el-breadcrumb-item>
                      <el-breadcrumb-item :to="{}" ></el-breadcrumb-item>
                    </el-breadcrumb>
                  </el-col>
                  </el-row>

                  <el-container class="functions">
                    <br/><br/><br/><br/>
                    <!-- 等待组件插入在这里-->
                    <div class="interact" style="margin-left:200px" v-if="chooseComponent==1">互动组件</div>
                    <div class="blog" style="margin-left:200px" v-if="chooseComponent==2">博客组件</div>
                    <div class="garden" style="margin-left:200px" v-if="chooseComponent==3">花园组件</div>
                    <div class="record" style="margin-left:200px" v-if="chooseComponent==4">工作记录组件</div>
                  </el-container>

              </el-main>
            </el-container>

          </el-container>
        </el-container>
      </div>
    </body>

</template>

<script>


export default{
  name:'PersonalInfoPage',
  data(){
    return{
      ifInfoChanged:false,
      change:false,
      showtel:true,
      chooseComponent:1,
      url:'https://img2.baidu.com/it/u=3194475248,8547823&fm=253&fmt=auto&app=138&f=JPEG?w=800&h=500',
      avaUrl:'',
      UserInfo:{
        'name':'楚杰',
        'Description':'我真的不卷。。。',
        'email':'123@tongji.edu.cn',
        'registerTime':'2020年1月',
        'tel':'123456',
        'points':'114',
        'id':'1919810',

      }
      
    }
  },
  methods:{
    changeInfo(){
      this.change=!this.change
    },
    ifshowTel(){
      this.showtel=!this.showtel
    },
    refresh(index){
      this.chooseComponent=index //通过v-if 展示四个不同的组件 还没写
    },
    InfoHasChanged(){
      alert('信息改变！')
      //此处应该向后端发送请求修改数据
    }

    
  }
  }
</script>

<style scoped>
.personalinfo .el-header {
  position: relative;
  background-color: var(--el-color-primary-light-7);
  color: var(--el-text-color-primary);
}
.personalinfo .el-aside {
}
.personalinfo .el-menu {
  border-right: none;
}
.personalinfo .el-main {
  padding: 0;
  background-color: rgb(223, 245, 223);
}
.personalinfo .toolbar {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  height: 100%;
  right: 20px;
}
</style>
