<template>
    <div class="home">
        <div class="container" style="margin-top: 70px;">
            <div class="card">
                <div class="card-body">
                    <slot></slot>
                </div>
            </div>
        </div>
    </div>
</template>
  
<script>
export default {
    name: "ContentBase",
}
</script>
  
<style scoped>
.container {
    margin-top: 20px;
}
</style>