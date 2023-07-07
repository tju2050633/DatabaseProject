<template>
  <ContentBase>
    <div class="row">
      <div class="col-3">
        <ul class="list-group">
          <li class="list-group-item active" aria-current="true">
            An active item
          </li>
          <li class="list-group-item">A second item</li>
          <li class="list-group-item">A third item</li>
          <li class="list-group-item">A fourth item</li>
          <li class="list-group-item">And a fifth one</li>
        </ul>
      </div>

      <div class="col-9">
        <div class="card">
          <div class="card-body">
            <CarouselExample />
          </div>
        </div>
      </div>
    </div>
  </ContentBase>
</template>
  
<script>
import ContentBase from "../components/ContentBase.vue";
import CarouselExample from "../components/CarouselExample.vue";

export default {
  name: "ActionView",
  components: {
    ContentBase,
    CarouselExample,
  },
};
</script>
  
<style scoped></style>