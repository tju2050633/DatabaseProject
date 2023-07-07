<template>
  <ContentBase>
    <div class="card">
      <div class="card-body">
        <div class="d-flex align-items-center">
          <strong>Loading...</strong>
          <div class="spinner-border ms-auto" role="status" aria-hidden="true"></div>
        </div>
      </div>
    </div>
  </ContentBase>
</template>

<script>
import ContentBase from '../components/ContentBase.vue';

export default {
  name: 'NotFoundView',
  components: {
    ContentBase,
  }
}
</script>

<style scoped></style>