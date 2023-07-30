<template>
    <div id="blog-distribution" ref="test0" style="height:500px;width:100%">hello！</div>
</template>

<script>
import * as echarts from 'echarts';
export default{
  name:'BlogDistribution',
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
      data: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
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
      data: [
        242, 545, 657, 737, 858, 976, 1435, 2116, 2932, 3620, 4666, 5843
      ]
    },
    {
      name: '热门原创内容数量',
      type: 'line',
      yAxisIndex: 1,
      data: [100, 235, 357, 437, 558, 676, 935, 1116, 1232, 1220, 1266, 1343]
    }
  ]
};

option && myChart.setOption(option);
    }
  },
  mounted(){
    this.createChart()
  }
}
</script>

<style scoped>


</style>