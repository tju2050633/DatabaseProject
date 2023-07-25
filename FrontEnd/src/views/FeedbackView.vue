<template>
    <div class="d-flex justify-content-center">
        <FeedbackCard />
    </div>
</template>
  
<script>
import FeedbackCard from '@/components/FeedbackCard.vue';

export default {
    name: 'FeedbackView',
    components: {
        FeedbackCard
    }
}
</script>
  
<style scoped>
.d-flex {
    margin-top: 100px;
    margin-bottom: 40px;
}
</style>