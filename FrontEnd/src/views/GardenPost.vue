<template>
  <el-form ref="gardenForm" :model="garden" label-width="120px">
    <el-form-item label="花园名称">
      <el-input v-model="garden.name"></el-input>
    </el-form-item>
    <el-form-item label="花园描述">
      <el-input type="textarea" v-model="garden.description"></el-input>
    </el-form-item>
    <el-form-item label="花园地点">
      <el-input v-model="garden.location"></el-input>
    </el-form-item>
    <el-form-item label="花园大小">
      <el-input v-model="garden.size"></el-input>
    </el-form-item>
    <el-upload
      v-model:file-list="fileList"
      action="https://run.mocky.io/v3/9d059bf9-4660-45f2-925d-ce80ad6c4d15"
      list-type="picture-card"
      :on-preview="handlePictureCardPreview"
      :on-remove="handleRemove"
    >
      <el-icon><Plus /></el-icon>
    </el-upload>

    <el-dialog v-model="dialogVisible">
      <img w-full :src="dialogImageUrl" alt="Preview Image" />
    </el-dialog>
    <el-form-item>
      <el-button type="primary" @click="submitForm">发布</el-button>
      <el-button @click="resetForm">重置</el-button>
    </el-form-item>
  </el-form>
</template>

<script>
import { ref } from "vue";

export default {
  name: "GardenForm",
  setup() {
    const garden = ref({
      name: "",
      description: "",
      location: "",
      size: "",
      imageUrl: "",
    });

    const submitForm = () => {
      // 提交表单逻辑
      console.log("提交表单", garden.value);
      // 发送数据到后端等操作

      // 重置表单
      resetForm();
    };

    const resetForm = () => {
      // 重置表单逻辑
      garden.value = {
        name: "",
        description: "",
        location: "",
        size: "",
        imageUrl: "",
      };
    };

    const beforeUpload = (file) => {
      const isJpgOrPng =
        file.type === "image/jpeg" || file.type === "image/png";
      if (!isJpgOrPng) {
        this.$message.error("只支持上传 JPG/PNG 格式的图片");
        return false;
      }
      const isLt2M = file.size / 1024 / 1024 < 2;
      if (!isLt2M) {
        this.$message.error("图片大小不能超过 2MB");
        return false;
      }
      return true;
    };

    const handleUploadSuccess = (response) => {
      // 图片上传成功的处理逻辑
      console.log("上传成功", response);
      garden.value.imageUrl = response.imageUrl; // 假设后端返回的图片地址字段为imageUrl
    };

    const handleUploadError = (error) => {
      // 图片上传失败的处理逻辑
      console.log("上传失败", error);
      this.$message.error("图片上传失败");
    };

    //************* */
    const fileList = ref([
      {
        name: "food.jpeg",
        url: "https://fuss10.elemecdn.com/3/63/4e7f3a15429bfda99bce42a18cdd1jpeg.jpeg?imageMogr2/thumbnail/360x360/format/webp/quality/100",
      },
      {
        name: "plant-1.png",
        url: "/images/plant-1.png",
      },
      {
        name: "food.jpeg",
        url: "https://fuss10.elemecdn.com/3/63/4e7f3a15429bfda99bce42a18cdd1jpeg.jpeg?imageMogr2/thumbnail/360x360/format/webp/quality/100",
      },
      {
        name: "plant-2.png",
        url: "/images/plant-2.png",
      },
      {
        name: "food.jpeg",
        url: "https://fuss10.elemecdn.com/3/63/4e7f3a15429bfda99bce42a18cdd1jpeg.jpeg?imageMogr2/thumbnail/360x360/format/webp/quality/100",
      },
      {
        name: "figure-1.png",
        url: "/images/figure-1.png",
      },
      {
        name: "food.jpeg",
        url: "https://fuss10.elemecdn.com/3/63/4e7f3a15429bfda99bce42a18cdd1jpeg.jpeg?imageMogr2/thumbnail/360x360/format/webp/quality/100",
      },
      {
        name: "figure-2.png",
        url: "/images/figure-2.png",
      },
    ]);

    const dialogImageUrl = ref("");
    const dialogVisible = ref(false);

    return {
      garden,
      fileList,
      dialogImageUrl,
      dialogVisible,
      submitForm,
      resetForm,
      beforeUpload,
      handleUploadSuccess,
      handleUploadError,
    };
  },
};
</script>

<style>
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