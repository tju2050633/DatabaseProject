<!-- 地图通用页面，仅需修改经纬度参数表示不同校区 -->

<template>
  <div class="container" style="margin-top: 60px; margin-left: 150px">
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
        <el-row>
          <div class="upload-container">
            <button class="upload-button" @click="uploadLocation">
              上传花园位置
            </button>
          </div>
        </el-row>
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
          @moving="handleCenterChange"
        >
          <BCityList />
          <BScale />
          <BZoom />
          <BLocation />
        </BMap>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import { ref } from "vue";
import "../api/mapApi.js";
import { postLocation } from "../api/mapApi.js";
// import { MapType, MapProps } from 'vue3-baidu-map-gl'

export default {
  name: "CampusMap",
  props: {
    latitude: Number,
    longtitude: Number,
  },

  setup(props) {
    const center = ref({
      lng: props.longtitude,
      lat: props.latitude,
    });

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

    const handleCenterChange = (event) => {
      const map = event.target; // 获取地图实例
      const newCenter = map.getCenter(); // 获取新的中心点经纬度
      center.value = {
        lng: newCenter.lng,
        lat: newCenter.lat,
      };
      console.log("更新成功");
    };

    const uploadLocation = () => {
      // 获取当前地图中心的经纬度，执行位置上传操作
      const { lng, lat } = center.value;
      // 这里使用示例代码，你需要根据实际情况执行位置上传操作
      console.log("上传位置:", lng, lat);
      postLocation(lng, lat).then(
        function (res) {
          console.log("测试成功");
          alert("上传成功");
          //测试获得的内容
          console.log(res.data);
        },
        function (err) {
          alert("上传失败");
          console.log(err.data);
        }
      );
    };

    return {
      center,
      type,
      mapSetting,
      handleCenterChange,
      uploadLocation,
    };
  },
};
</script>

<style scoped>
@import url("../css/map.css");
</style>