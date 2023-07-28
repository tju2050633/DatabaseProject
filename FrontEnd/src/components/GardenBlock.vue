<!-- 花园展厅模块 hot new共用 参数为image对象 -->

<template>
    <div>
        <div style="text-align: center;">
            <img :src="image.imageUrl" alt="花园图片" style="width: 60%">
        </div>
        <div style="display: flex; justify-content: space-between;">
            <span style="flex: 1; text-align: left;"><el-icon style="margin-top: 5px">
                    <user />
                </el-icon>{{ image.username }}</span>
            <span style="flex: 1; text-align: center;">{{ image.gardenname }}</span>
            <span style="flex: 1; text-align: right;"><el-icon style="margin-top: 5px">
                    <star />
                </el-icon>{{ image.hot }}</span>
        </div>
    </div>
</template>

<script>
export default {
    name: 'GardenBlock',
    props: {
        image: {
            type: Object,
            required: true
        }
    }
}
</script>