<template>
    <div id="GradeDistribution" ref="test0" style="height:500px;width:100%">hello！</div>
</template>

<script>
import {getGradeTable} from '../api/DataVisualization/GradeDistribution'
import * as echarts from 'echarts';
export default{
  name:'GradeDistribution',
  data(){
    return{
      table:[
        { value: 130, name: '大一' },
        { value: 218, name: '大二' },
        { value: 126, name: '大三' },
        { value: 94, name: '大四' },
        { value: 82, name: '其他（硕士、博士）' },
      ]
    }
  },
  methods:{
    createChart(){
        var chartDom = document.getElementById('GradeDistribution');
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
      '大一',
      '大二',
      '大三',
      '大四',
      '其他（硕士、博士）',
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
      radius: [50, 120],
      center: ['50%', '50%'],
      roseType: 'area',
      itemStyle: {
        borderRadius: 5
      },
      data: this.table
    }
  ]
};

option && myChart.setOption(option);
    },
    getData(){
      getGradeTable().then(res=>{
        console.log(res)
        this.table=res.data.table
      },
      err=>{
        console.log(err)
      })
    }
  },
  mounted(){
    this.createChart()
    
    this.getData()
  }
}
</script>

<style scoped>


</style>