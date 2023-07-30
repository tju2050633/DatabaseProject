<template>
    <div id="GardenDistribution" ref="test0" style="height:500px;width:100%">hello!</div>
    <div id="Pie" ref="test0" style="height:500px;width:100%"></div>
</template>

<script>
import * as echarts from 'echarts';
export default{
  name:'GardenDistribution',
  methods:{
    createChart(){
      var chartDom = document.getElementById('GardenDistribution');
      var myChart = echarts.init(chartDom);
      var option;

      const colors = ['#f89588', 'efa666', '#7cd6cf'];
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
      name: '总花园数量（座）',
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
      name: '热门花园数量（座）',
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
      data: [
        242, 545, 657, 737, 858, 976, 1435, 2116, 2932, 3620, 4666, 5843
      ]
    },
    {
      name: '活跃用户数量',
      type: 'line',
      yAxisIndex: 1,
      data: [100, 235, 357, 437, 558, 676, 935, 1116, 1232, 1220, 1266, 1343]
    }
  ]
};

option && myChart.setOption(option);
},
createPie(){
  var chartDom = document.getElementById('Pie');
        var myChart = echarts.init(chartDom);
var option;

option = {
  title: {
    text: '用户年级分布图',
    left: 'center'
  },
  tooltip: {
    trigger: 'item',
    formatter: '{a} <br/>{b} : {c} ({d}%)'
  },
  legend: {
    left: 'center',
    top: 'bottom',
    data: [
      '四平路校区',
      '嘉定校区',
      '沪西小区',
    ]
  },
  toolbox: {
    show: true,
    feature: {
      mark: { show: true },
      dataView: { show: true, readOnly: false },
      restore: { show: true },
      saveAsImage: { show: true }
    }
  },
  series: [
    {
      name: 'Area Mode',
      type: 'pie',
      radius: [100, 170],
      center: ['50%', '50%'],
      roseType: 'area',
      itemStyle: {
        borderRadius: 3
      },
      data: [
        { value: 430, name: '四平路校区' },
        { value: 518, name: '嘉定校区' },
        { value: 226, name: '沪西校区' },
      ]
    }
  ]
};

option && myChart.setOption(option);

}
  },
  mounted(){
    this.createChart();
    this.createPie()
  }
}
</script>

<style scoped>


</style>