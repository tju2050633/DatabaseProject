<template>
  <el-card class="blog-post-card">
    <el-row>
      <el-col :offset="2" span="2">
        标题
      </el-col>
      <el-col  span="12">
        <el-input v-model="blog.title" style="margin-left:50px" placeholder="给博客起个标题吧！"></el-input>
      </el-col>
    </el-row>

    <el-row style="margin-top:4vh">
      <el-col :offset="2" span="12">
        博客内容
      </el-col>
      <el-col  span="12">
        <el-input type="textarea" v-model="blog.content" style="width:50vw;margin-left:18px;"  placeholder="今天有什么想说的呢？请畅所欲言~"></el-input>
      </el-col>
    </el-row>

    <!-- create.sql里面也没有imgs属性啊？但是接口里又有？？怎么回事啊-->
    <el-row style="margin-top:4vh">
      <el-col :offset="2" span="12">
        图片
      </el-col>
      <el-col  span="12">
        <el-upload
        style="margin-left:50px"
        class="avatar-uploader"
        action="#"
        list-type="picture-card"
        :on-preview="imgPreview"
        :on-remove="handleRemove"
        :before-upload="uploadImage"
        >
        <el-icon><Plus /></el-icon>
        </el-upload>
        <el-dialog v-model="preview">
          <img style="width:25%" :src="blog.imgs" alt="Preview Image" />
        </el-dialog>
      </el-col>
    </el-row>

    <!-- 瞄了一眼 后端数据库没有博客tag属性 -->
    <el-row style="margin-top:4vh">
      <el-col :offset="2" span="2">
        标签
      </el-col>
      <el-col  span="12">
      <div style="margin-left:50px">
      <el-select v-model="blog.tags" style="width:50vw" placeholder="如果快捷标签中没有你想要的，请自行创建~" multiple allow-create filterable>
        <el-option
          v-for="tag in tagOptions"
          :key="tag.value"
          :label="tag.label"
          :value="tag.value">
        </el-option>
      </el-select>
    </div>
    </el-col>
    </el-row>
    
    <el-row style="margin-top: 4vh;">
      <el-col :offset="11">
        <el-button type="primary" @click="submitForm">发布</el-button>
        <el-button @click="resetForm">重置</el-button>
      </el-col>
    </el-row>

  </el-card>
  
</template>
  
<script>  
import OSS from 'ali-oss'
import { mapGetters } from 'vuex';
import { postBlog } from '@/api/blogApi';
export default {
    name: "BlogForm",
    computed: {
      ...mapGetters(['getUserId']),
      userId() {
        return this.getUserId;
      },
    },
    data(){
        return{
          // oss参数
          imageUrl:'',
          client: null,
          preview:false,
          //前端数据
          blog:{
            title:'',
            content:'',
            tags:[],
            imgs:'',
          },
          tagOptions : [
            { value: "technology", label: "科技" },
            { value: "lifestyle", label: "校园生活" },
            { value: "re-acts", label: "文娱活动" },
            { value: "food", label: "美食" },
            { value: "exams",label:"各类考试"},
          ],
        }
    },
    methods:{

      async put(name, file) {
      // oss初始化
      this.client = new OSS({
      region: 'oss-cn-hangzhou', 
      accessKeyId: 'LTAI5tC6nc26iJYDa7iWJFRZ', 
      accessKeySecret: 'tZEndrhkAdUFo1PDUQcInGfwJKynm0', 
      bucket: 'sharing-garden'
      })
      try {
        let fileName = new Date().getTime() + name
        const result = await this.client.put(fileName, file)
        console.log(result)
        this.imageUrl = result.url // 返回的上传图片地址
        if(this.blog.imgs instanceof Array){
          this.blog.imgs.push(this.imageUrl)
        }
        this.imageUrl = result.url;
        this.preview = true;
        console.log(this.imageUrl,this.preview)
      } catch (e) {
        console.log(e)
      }
      },
      imgPreview(file) {
        this.imageUrl = file.url;
        this.preview = true;
        console.log(this.imageUrl,this.preview)
      },
      handleRemove(file,filelist){
        console.log(file,filelist)
      },
      checkEmpty(){
        if(this.blog.imgs[0]=='')
          return true
        if(this.blog.content=='')
          return true
        if(this.blog.title=='')
          return true
        if(this.blog.tags[0]=='')
          return true

        return false
      },
      resetForm(){
        this.blog={
            title:'',
            content:'',
            tags:[],
          }
      },
      async submitForm(){
        if(this.checkEmpty()==true){
          alert('请完成表格填写后再提交！')
          return
        }
        let res = await postBlog("1", this.blog.title, this.blog.content, this.blog.imgs);
        alert(res);
        this.resetForm()
      },
      uploadImage(file){
        this.put(file.name, file)
        return false
      }
    },
  };
</script>

<style scoped>
.blog-post-card{
  margin-top: 10px;
  border-radius: 10px;
  width: 65vw;
}

</style>