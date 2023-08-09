<!-- 地图通用页面，仅需修改经纬度参数表示不同校区 -->

<template>
  <div class="container" style="margin-top: 60px">
    <el-row>
      <el-col :span="6">
        <label class="infohead">
          <input type="checkbox" v-model="mapSetting.enableScrollWheelZoom" />
          鼠标缩放
        </label>
        <br />
        <label class="infohead">
          <input type="checkbox" v-model="mapSetting.enableDragging" />
          拖拽
        </label>
        <br />
        <label class="infohead">
          <input type="checkbox" v-model="mapSetting.enableInertialDragging" />
          惯性拖拽
        </label>
        <br />
        <label class="infohead">
          <input type="checkbox" v-model="mapSetting.enablePinchToZoom" />
          双指缩放地图
        </label>
        <br />
        <label class="infohead">
          <input type="checkbox" v-model="mapSetting.enableKeyboard" />
          键盘操作
        </label>
        <br />
        <label class="infohead">
          <input type="checkbox" v-model="mapSetting.enableDoubleClickZoom" />
          双击缩放，左键双击放大、右键双击缩小
        </label>
        <br />
        <label class="infohead">
          <input type="checkbox" v-model="mapSetting.enableContinuousZoom" />
          双击平滑缩放效果
        </label>
        <br />
        <label class="infohead">
          <input type="checkbox" v-model="mapSetting.enableTraffic" />
          显示交通路况
        </label>
        <br />
        <br />
        <span class="infohead">地图类型：</span>
        <select class="mySelect" name="" id="" v-model="type">
          <option value="BMAP_NORMAL_MAP">常规地图 BMAP_NORMAL_MAP</option>
          <option value="BMAP_EARTH_MAP">地球模式 BMAP_EARTH_MAP</option>
          <option value="BMAP_SATELLITE_MAP">卫星图 BMAP_EARTH_MAP</option>
        </select>
      </el-col>
      <br />
      <br />
      <el-col :span="18">
        <BMap
          :heading="64.5"
          :tilt="73"
          :center="center"
          :ak="'HR8QVms0aC9N8giqxCuXfNXGhzBuT6X2'"
          :zoom="19"
          :minZoom="3"
          :mapType="type"
          :enableDragging="mapSetting.enableDragging"
          :enableInertialDragging="mapSetting.enableInertialDragging"
          :enableScrollWheelZoom="mapSetting.enableScrollWheelZoom"
          :enableContinuousZoom="mapSetting.enableContinuousZoom"
          :enableDoubleClickZoom="mapSetting.enableDoubleClickZoom"
          :enableKeyboard="mapSetting.enableKeyboard"
          :enablePinchToZoom="mapSetting.enablePinchToZoom"
          :enableTraffic="mapSetting.enableTraffic"
        >
          <BCityList />
        </BMap>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import { ref } from "vue";
// import { MapType, MapProps } from 'vue3-baidu-map-gl'

export default {
  name: "CampusMap",
  props: {
    latitude: Number,
    longtitude: Number,
  },
  computed: {
    center() {
      return { lng: this.longtitude, lat: this.latitude };
    },
  },
  setup() {
    const type = ref("BMAP_NORMAL_MAP");
    const mapSetting = ref({
      enableDragging: true,
      enableInertialDragging: true,
      enableScrollWheelZoom: true,
      enableContinuousZoom: true,
      enableResizeOnCenter: true,
      enableDoubleClickZoom: false,
      enableKeyboard: true,
      enablePinchToZoom: true,
      enableAutoResize: true,
      enableTraffic: false,
    });

    return {
      type,
      mapSetting,
    };
  },
};
</script>

<style scoped>
@import url("../css/map.css");
</style>