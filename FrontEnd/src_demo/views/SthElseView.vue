<template>
    <ContentBase>
        <div class="d-flex align-items-center">
            <strong>Loading...</strong>
            <div class="spinner-border ms-auto" role="status" aria-hidden="true"></div>
        </div>
    </ContentBase>
</template>
  
<script>
import ContentBase from '../components/ContentBase.vue';

export default {
    name: 'SthElseView',
    components: {
        ContentBase,
    }
}
</script>
  
<style scoped></style>