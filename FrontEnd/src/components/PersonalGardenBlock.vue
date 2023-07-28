<!-- 个人信息页面的花园模块 -->

<template>
    <div>
        <h2>
            <el-icon style="user: 10px;"><User /></el-icon>
            <span >{{ Garden.author }}</span>
        </h2>
        <h1> 
            <span >{{ Garden.title }}</span>
        </h1>
        <el-image style="width: 50vw; height: 30vh" :src="Garden.cover" :fit="fill" />
    </div>
</template>

<script>
export default {
    props: ['Garden']
}
</script>