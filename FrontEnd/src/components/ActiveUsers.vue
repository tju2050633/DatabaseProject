<template>
  <!-- <div class="datetime-picker">
    <el-date-picker
      v-model="range"
      type="daterange"
      range-separator="至"
      start-placeholder="开始日期"
      end-placeholder="结束日期">
    </el-date-picker>
    <el-button type="primary" @click="createChart">开始画图</el-button>
  </div> -->
    <div id="activeUser" ref="test0" style="height:500px;width:100%">hello！</div>
</template>

<script>
import * as echarts from 'echarts';
import { getTotalUser, getActiveUser} from '../api/DataVisualization/ActiveUser'
export default{
  name:'ActiveUsers',
  data(){
    return{
      timeperiod:['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
      active_user_num: [10, 23, 33, 45, 163, 222, 203, 234, 220, 215, 120, 362],
      total_user_num:[22, 45, 67, 237, 258, 376, 435, 516, 532, 620, 666, 843],
      total:[],
      active:[],
      range:'',
      dates:[],
    }
  },
  methods:{
    formatDate(date) {
      const year = date.getFullYear();
      const month = String(date.getMonth() + 1).padStart(2, '0'); // 补零
      const day = String(date.getDate()).padStart(2, '0'); // 补零
      return `${year}-${month}-${day}`;
    },
    
    createChart(){
      var chartDom = document.getElementById('activeUser');
      var myChart = echarts.init(chartDom);
      var option;

const colors = ['#5470C6', '#91CC75', '#EE6666'];
option = {
  color: colors,
  tooltip: {
    trigger: 'axis',
    axisPointer: {
      type: 'cross'
    }
  },
  grid: {
    right: '20%'
  },
  toolbox: {
    feature: {
      dataView: { show: true, readOnly: false },
      restore: { show: true },
      saveAsImage: { show: true }
    }
  },
  legend: {
    data: ['总用户数量', '活跃用户数量']
  },
  xAxis: [
    {
      type: 'category',
      axisTick: {
        alignWithLabel: true
      },
      // prettier-ignore
      data: this.timeperiod
    }
  ],
  yAxis: [
    {
      type: 'value',
      name: '活跃用户数量(人)',
      position: 'right',
      alignTicks: true,
      axisLine: {
        show: true,
        lineStyle: {
          color: colors[0]
        }
      },
      axisLabel: {
        formatter: '{value}'
      }
    },
    {
      type: 'value',
      name: '总用户数量(人)',
      position: 'left',
      alignTicks: true,
      axisLine: {
        show: true,
        lineStyle: {
          color: colors[2]
        }
      },
      axisLabel: {
        formatter: '{value}'
      }
    }
  ],
  series: [
    {
      name: '总用户数量',
      type: 'bar',
      data:this.total_user_num
    },
    {
      name: '活跃用户数量',
      type: 'line',
      yAxisIndex: 1,
      data:this.active_user_num
    }
  ]
};

option && myChart.setOption(option);
    },
    getData(){
      //我没搞懂为什么这个数据处理要扔给我前端做 就这个页面做个接口好了

      //还是按月份来
      let total=[]
      let active=[]
      for(let i=0;i<12;i++){
        let item='2023-'+toString(i+1).padStart(2, '0')+'-15'//每月15号统计人数
        getTotalUser({
          date:item
        }).then(res=>{
        console.log(res)
        //将totaluser写入到本地
        total.push(res.data)
      },err=>{
        console.log(err)
      })
      getActiveUser({
      }).then(res=>{
        console.log(res)
        //将activeuser数组保存到本地 假定传回的就叫active user
        active.push(res.data)
      },
      err=>{
        console.log(err)
      });
      }
    },
  },
  mounted(){
    this.createChart()
    
    this.getData()
  }
}
</script>

<style scoped>


</style>