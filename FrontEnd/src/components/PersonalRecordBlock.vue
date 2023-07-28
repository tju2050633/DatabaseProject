<!-- 个人信息页面的工作记录模块 -->

<template>
    <div>
        <h2>
            时间：
            <span >{{ Record.date }}</span>
        </h2>

        <h2>
            地点：
            <span >{{ Record.location }}</span>
        </h2>

        <h2>
            详情：
        </h2>

        <p v-if="!Record.showFullContent">
            {{ Record.partialContent }}
        </p>
        <p v-else>
            {{ Record.fullContent }}
        </p>

        <button class="read-more-button" @click="toggleContent(index)">
            {{ Record.showFullContent ? '收起' : '展开' }}
        </button>
    </div>
</template>

<script>
export default {
    props: ['Record']
}
</script>