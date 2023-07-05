<template>
    <ContentBase>
        <div class="row">
            <div class="col-3">
                <div class="card">
                    <div class="card-body">
                        <div class="text-center">
                            <img src="../assets/logo.png" class="rounded" alt="">
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-9">
                <div class="card">
                    <div class="card-body">
                        <ValidationExample />
                    </div>
                </div>
            </div>
        </div>
    </ContentBase>
</template>
  
<script>
import ContentBase from '../components/ContentBase.vue';
import ValidationExample from '../components/ValidationExample.vue';

export default {
    name: 'LinkView',
    components: {
        ContentBase,
        ValidationExample
    }
}
</script>
  
<style scoped></style>