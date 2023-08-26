<template>
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
      total_user_num:[22, 45, 67, 237, 258, 376, 435, 516, 532, 620, 666, 843]
    }
  },
  methods:{
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
      getActiveUser({
      }).then(res=>{
        console.log(res)
        //将activeuser数组保存到本地 假定传回的就叫active user
        this.active_user_num=res.data.active_user_num
      },
      err=>{
        console.log(err)
      });

      getTotalUser({
      }).then(res=>{
        console.log(res)
        //将totaluser写入到本地
        this.total_user_num=res.data.total_user_num
      },
      err=>{
        console.log(err)
      })
    }
  },
  mounted(){
    this.getData()
    this.createChart()
  }
}
</script>

<style scoped>


</style>