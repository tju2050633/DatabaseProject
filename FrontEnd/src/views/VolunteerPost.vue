<template>
    <body>
        <div class="container">
            <NavBar />
            <el-row id="mainpart">
                <SideBar />
                &nbsp; &nbsp;
                <el-col :span="15">
                    <el-header class="posthead">
                        <img src="../assets/img-volunteerpost.png">
                    </el-header>
                    <el-form ref="volunteerForm" :model="recruitment" label-width="120px">
                        <el-form-item label="活动名称">
                            <el-input v-model="recruitment.name"></el-input>
                        </el-form-item>
                        <el-form-item label="活动描述">
                            <el-input type="textarea" v-model="recruitment.description"></el-input>
                        </el-form-item>
                        <el-form-item label="活动时间">
                            <el-input v-model="recruitment.time"></el-input>
                        </el-form-item>
                        <el-form-item label="活动地点">
                            <el-input v-model="recruitment.location"></el-input>
                        </el-form-item>
                        <el-form-item label="志愿者规模">
                            <el-input v-model="recruitment.size"></el-input>
                        </el-form-item>
                        <el-form-item label="志愿者要求">
                            <el-input type="textarea" v-model="recruitment.requirement"></el-input>
                        </el-form-item>
                        <el-form-item label="联系方式">
                            <el-input v-model="recruitment.contact"></el-input>
                        </el-form-item>
                        <el-form-item>
                            <el-button type="primary" @click="submitForm">发布</el-button>
                            <el-button @click="resetForm">重置</el-button>
                            <el-button @click="this.$router.push('/VolunteerRecruitment/')">返回</el-button>
                        </el-form-item>
                        <el-card class="caution">
                            <div>
                                <p>注意事项：</p>
                                <li>1.提交后审核：提交您的志愿者招募通知后，它将由管理员进行审核，请耐心等待审核结果。</li>
                                <li>2.审核通过时间：如果您的招募通知审核通过，将在24小时内上传到志愿者招募的平台进行公示。请确保您的联系信息和通知内容准确无误。</li>
                                <li>3.审核不通过通知：如果您的申请未能通过审核，系统将会向您发送通知信息，说明审核不通过的原因。</li>
                                <li>4.修改和再次提交：如果您的申请未通过审核，您可以根据系统提供的反馈信息进行必要的修改。您对申请内容进行了修改之后，可以再次提交申请。</li>
                                <li>5.仔细检查申请内容：在提交之前，请确保您的申请内容充分符合招募要求和平台规定。避免拼写错误、信息不完整或不准确。</li>
                                <li>6.联系管理员：如果您对审核过程或审核结果有任何疑问或需要帮助，联系管理员以获取帮助。</li>
                            </div>
                        </el-card>
                    </el-form>
                </el-col>
            </el-row>
        </div>
    </body>
</template>
  
<script>
import { postRecruitment } from '@/api/VolunteerAPI';

export default {
    name: "VolunteerForm",
    data() {
        return {
            recruitment: {
                name: "",
                description: "",
                time: "",
                location: "",
                size: "",
                requirement: "",
                contact: "",
            },
        };
    },
    created() {

    },
    methods: {
        async submitForm() {
            console.log("View VolunteerPost submitForm : ", this.recruitment);
            const result = await postRecruitment(this.recruitment);
            alert(result);
            this.resetForm();
        },
        resetForm() {
            this.recruitment = {
                name: "",
                description: "",
                time: "",
                location: "",
                size: "",
                requirement: "",
                contact: "",
            };
        },
    },
};
</script>
  
<style>
body {
    background-color: rgb(245, 235, 226);
    background-image: url("../assets/img-volunteer.jpg");
    background-size: 30vw;
    background-repeat: no-repeat;
    position: relative;
    background-position: 65vw 35vh;
    background-attachment: fixed;
}

.container {
    margin-top: 60px;
}

.posthead {
    margin-left: 80px;
    margin-bottom: 50px;
}

.caution {
    margin-left: 120px;
    margin-bottom: 30px;
}

.avatar-uploader .el-upload {
    border: 1px dashed #d9d9d9;
    border-radius: 6px;
    cursor: pointer;
    position: relative;
    overflow: hidden;
    display: inline-block;
}

.avatar-uploader-icon {
    font-size: 28px;
    color: #8c939d;
    width: 178px;
    height: 178px;
    line-height: 178px;
    text-align: center;
}

.avatar {
    width: 178px;
    height: 178px;
    display: block;
}
</style>