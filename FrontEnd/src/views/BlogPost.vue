<template>
  <el-form ref="blogForm" :model="blog" label-width="120px">
    <el-form-item label="标题">
      <el-input v-model="blog.title"></el-input>
    </el-form-item>
    <el-form-item label="内容">
      <el-input type="textarea" v-model="blog.content"></el-input>
    </el-form-item>
    <el-form-item label="标签">
      <el-select v-model="blog.tags" multiple>
        <el-option
          v-for="tag in tagOptions"
          :key="tag.value"
          :label="tag.label"
          :value="tag.value"
        ></el-option>
      </el-select>
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="submitForm">发布</el-button>
      <el-button @click="resetForm">重置</el-button>
    </el-form-item>
  </el-form>
</template>

<script>
import { ref } from "vue";

export default {
  name: "BlogForm",
  setup() {
    const blog = ref({
      title: "",
      content: "",
      tags: [],
    });

    const tagOptions = [
      { value: "technology", label: "科技" },
      { value: "lifestyle", label: "生活方式" },
      { value: "travel", label: "旅行" },
      { value: "food", label: "美食" },
      // 可根据需要添加更多标签选项
    ];

    const submitForm = () => {
      // 提交表单逻辑
      console.log("提交表单", blog.value);
      // 发送数据到后端等操作

      // 重置表单
      resetForm();
    };

    const resetForm = () => {
      // 重置表单逻辑
      blog.value = {
        title: "",
        content: "",
        tags: [],
      };
    };

    return {
      blog,
      tagOptions,
      submitForm,
      resetForm,
    };
  },
};
</script>