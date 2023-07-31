<!-- 主页底部板块，博客、花园等 -->

<template>
    <div class="item-block">
      <el-card :body-style="{ padding: '1px' }" shadow="hover">
        <img src="https://img1.baidu.com/it/u=4038661611,1664572164&fm=253&fmt=auto&app=138&f=JPEG?w=500&h=502">
        <div style="padding: 15px;">
          <span>同济大学共享花园</span>
          <div class="bottom clearfix">
            <time class="time">{{ currentDate }}</time>
            <el-button type="text" class="button" icon="el-icon-warning">举报</el-button>
          </div>
        </div>
      </el-card>
    </div>
    </template>
    
    <style>
      .time {
        font-size: 13px;
        color: #999;
      }
      
      .bottom {
        margin-top: 13px;
        line-height: 12px;
      }
    
      .button {
        padding: 0;
        float: right;
      }
    
      .image {
        width: 100%;
        display: block;
      }
    
      .clearfix:before,
      .clearfix:after {
          display: table;
          content: "";
      }
      
      .clearfix:after {
          clear: both
      }
    </style>
    
    <script>
    export default {
      name: "ItemBlock",
      data() {
        return {
          currentDate: new Date()
        };
      }
    }
    </script>