# 7.3

### Vue前端开发环境配置

`npm 9.5.1`

`node v18.16.0`

`vue @vue/cli 5.0.8`

### 编写.vue文件

`template` 内编写 `html` 代码

`script` 内编写 `javascript` 代码

`style` 内编写 `css` 代码

### 熟悉组件间的交互逻辑

父组件 -> 子组件：`props`

子组件 -> 父组件：`event`

举例：

帖子编辑部分 -> `event` -> 用户动态页面 -> `props` -> 帖子内容部分

### 创建示范项目(类似QQ空间)

[github链接](https://github.com/rmEleven/testVue)

##### 已有的页面

1. 主页
2. 登录页面
3. 注册页面
4. 用户动态页面
   1. 用户信息部分
   2. 帖子编辑部分
   3. 帖子内容部分
5. 好友列表页面
6. 404页面

##### 页面的结构

导航栏：**路由**实现页面**跳转**
内容框：页面**交互**逻辑

# 7.4

### Vue项目仪表盘

学习项目仪表盘的基本操作，并编写[文档](../%E8%AF%B4%E6%98%8E%E6%96%87%E6%A1%A3/%E9%A1%B9%E7%9B%AE%E4%BB%AA%E8%A1%A8%E7%9B%98.md)

### 学习组长提供的视频

学习视频 `P1 ~ P8`

包括：

1. `el` 挂载点
2. `data` 数据对象
3. `v-text` 指令
4. `v-html` 指令

# 7.5

### 学习vue项目结构

`src` 文件夹结构如下：

```txt
├── assets      # 资源文件夹
│   ├── ...
│   └── ...
├── components  # 组件文件夹
│   ├── ...
│   └── ...
├── router      # 路由文件夹
│   ├── ...
│   └── ...
├── store       # 状态管理文件夹
│   ├── ...
│   └── ...
├── views       # 视图文件夹
│   ├── ...
│   └── ...
├── App.vue     # Vue应用程序的根组件
└── main.js     # Vue应用程序的入口文件
```

### 学习bootstrap的使用

安装 `bootstrap` 依赖

在 `src/main.js` 中：

```js
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/js/bootstrap'
```

项目中可以直接使用 `bootstrap` 上提供的控件的代码

选取了一些控件，可在 `DatabaseProject\FrontEnd` 中查看

# 7.6







# 7.7