<template>
  <ContentBase>
    <div class="row">
      <div class="col-3">

        <CardExample />

        <div class="card">
          <div class="card-body">
            <button type="button" class="btn btn-primary btn-sm">button</button>
            <button type="button" class="btn btn-secondary btn-sm">button</button>
          </div>
        </div>

        <div class="card">
          <div class="card-body">
            <div class="btn-group" role="group" aria-label="Basic outlined example">
              <button type="button" class="btn btn-outline-primary">Left</button>
              <button type="button" class="btn btn-outline-primary">Middle</button>
              <button type="button" class="btn btn-outline-primary">Right</button>
            </div>
          </div>
        </div>

      </div>
      <div class="col-9">

        <div class="card">
          <div class="card-body">
            <InputExample />
          </div>
        </div>

      </div>
    </div>
  </ContentBase>
</template>

<script>
import ContentBase from '../components/ContentBase.vue';
import CardExample from '../components/CardExample.vue';
import InputExample from '../components/InputExample.vue';

export default {
  name: 'HomeView',
  components: {
    ContentBase,
    CardExample,
    InputExample
  }
}
</script>

<style scoped>
.card {
  margin-top: 10px;
}
</style>