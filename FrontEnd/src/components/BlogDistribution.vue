<template>
    <div id="blog-distribution" style="height:500px;width:100%">hello！</div>
</template>

<script>
import {getHotNum,getOriginNum} from '../api/DataVisualization/BlogDistribution'
import * as echarts from 'echarts';
export default{
  name:'BlogDistribution',
  data(){
    return{
      timeperiod:['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
      origin_num:[ 242, 545, 657, 737, 858, 976, 1435, 2116, 2932, 3620, 4666, 5843 ],
      hot_num:[100, 235, 357, 437, 558, 676, 935, 1116, 1232, 1220, 1266, 1343]
    }
  },
  methods:{
    createChart(){
    var chartDom = document.getElementById('blog-distribution');
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
    data: ['总花园数量', '热门花园数量']
  },
  xAxis: [
    {
      type: 'category',
      axisTick: {
        alignWithLabel: true
      },
      // prettier-ignore
      //data: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
      data:this.timeperiod
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
      name: '原创内容数量',
      type: 'bar',
     // data: [ 242, 545, 657, 737, 858, 976, 1435, 2116, 2932, 3620, 4666, 5843 ]
     data:this.origin_num
    },
    {
      name: '热门原创内容数量',
      type: 'line',
      yAxisIndex: 1,
      //data: [100, 235, 357, 437, 558, 676, 935, 1116, 1232, 1220, 1266, 1343]
      data:this.hot_num
    }
  ]
};

option && myChart.setOption(option);
    },
    getData(){
      getOriginNum({
        begin_date:this.begin_date,
        end_date:this.end_date
      }).then(res=>{
        console.log(res)
        //将activeuser数组保存到本地 假定传回的就叫active user
        this.origin_num=res.data.origin_num
      })

      getHotNum({
        begin_date:this.begin_date,
        end_date:this.end_date
      }).then(res=>{
        console.log(res)
        //将totaluser写入到本地
        this.hot_num=res.data.hot_num
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