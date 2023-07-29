<template>
  <CampusMap
    :latitude="this.$route.params.lat"
    :longtitude="this.$route.params.lng"
  />
</template>
  
  <script>
export default {
  name: "TJMap",
};
</script>