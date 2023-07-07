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

(该文档于7.5删除，更加完善的文档在 [这里](../../FrontEnd/%E4%BD%BF%E7%94%A8%E8%AF%B4%E6%98%8E.md))

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

## 1. 学习API的使用

**这里我使用的是 `Ajax` 使用 `Axios` 似乎更简单一些？**

需要安装 `jquery` 依赖

通过

```js
import $ from 'jquery';
```

在其他 **.js** 或 **.vue** 文件中导入 **$**

通过

```js
$.ajax({
   url: "https:xxxxxxxxx",
   type: "GET",
   data: {
      user_id: xxx,
   },
   headers: {
      'Authorization': "Bearer " + access,
   },
   success(resp) {
      console.log(resp);
   }
});
```

使用 **API**

## 2. 学习router的使用

通过

```js
import router from '@/router/index';
```

在其他 **.js** 或 **.vue** 文件中导入 **router**

通过

```js
router.push({
   name: 'userprofile',
   params: {
      userId
   }
});
```

使用 **router** 进行页面跳转

## 3. 学习store的使用

不同控件间传递数据通常可以使用这种方法：

父组件 -> 子组件：`props`

子组件 -> 父组件：`event`

但是如果控件嵌套较多，父子控件间传递数据会很复杂。`store` 可以将数据设置为全局数据，方便所有控件使用。

`/src/store/index.js` 文件功能介绍：

```txt
├── state      # 存储全局的共享状态数据
├── getters    # 一组从状态中派生出的计算属性
├── mutations  # 一组用于修改状态的方法
├── actions    # 一组用于执行异步操作的方法
└── modules    # 一个包含其他模块的对象
```

通过将 ModuleUser 模块添加到 modules 选项中，该模块可以在全局的 store 中进行使用，它可以有自己的 state、getters、mutations、actions，并与其他模块进行交互。

通过将这个配置文件导出为默认导出，其他部分的代码可以通过导入该文件获取 Vuex store 的实例，并在应用程序中使用它来进行全局的状态管理。

## 4. 完善示范项目

[github链接](https://github.com/rmEleven/testVue)

在之前的示范项目中使用 **API**、**router**、**store** 等相关知识，成功与公开的后端对接，实现了登录、退出等一系列功能。



# 7.7

没有学习新的内容

根据已学习的知识进行项目的前端开发，顺利实现 **导航栏**、**页面跳转**、**404页面**