# 学习日志

## 7.3

### 1. HTML语法学习

- 学习了用HTML搭建一个网页的主体结构，掌握了meta、head、title、body等部分的编辑方式
- 学习了使用div盒子模型进行页面骨架设计：由于div框架有外边距的存在，每一个类将独立占据一行；在div盒子模型中嵌套span标签可实现一行内多个标签并列

### 2. Web API项目创建与学习

#### （1）Web API项目结构

- 项目中Controllers是一个存放项目对外接口的类
- Web API有四种请求方式：get post  put delete（数据的获取、插入、更新、删除）
- get本质上获取数据，不会添加新内容（用于用户登录），post用于数据插入（用户账户注册）
- appsettings: 配置文件
- Program: 程序的入口类，其中包含整个程序的入口

#### （2）路由创建与使用规则

- 路由：相当于是后端的一个路径，可以实现前端根据路由来处理后端数据的功能，进而实现接口、前后端交互

- [Route("api/[controller]")] 表示路由为根目录下api-项目名，为区分相同路由下的不同行为（如get post put delete），则需要在方括号后加action，写成如下形式：

  [Route("api/[controller]/[action]")] 

- 上述两种方式中，前者为restful风格（行为不可见，同一路由）

#### （3）form表单传输与路由传参

- form表单传输会跳转页面，传入参数显示在地址栏中
- 路由传参不进行跳转，隐藏传入参数
- 通过路由传参进行前后端分离可以保护用户数据

#### （4）从数据库中获取数据

- Nuget包管理器使用：在依赖项中添加SQLClient依赖项
- SQL Connection类、SQL Command类、SQL DATa Adapter类、DataSet类、DATa Table类的使用实现对于数据库的访问，数据的返回

### 目前进度

熟悉HTML、CSS；学习了WebApi的项目结构，路由规则的创建与使用，form表单传输与路由传参，从数据库中获取并返回数据。从数据库中获取与返回数据尚未做demo进行测试