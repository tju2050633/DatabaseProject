<template>
    <div class="d-flex justify-content-center">
        <MessageCard />
    </div>
</template>
  
<script>
import MessageCard from '@/components/MessageCard.vue';

export default {
    name: 'MessageView',
    components: {
        MessageCard
    }
}
</script>
  
<style scoped>
.d-flex {
    margin-top: 10vh;
}
</style>