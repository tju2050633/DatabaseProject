DROP TABLE Volunteer_Apply;
DROP TABLE Volunteer_Recruit;
DROP Table Redeems;
DROP TABLE Items;
DROP TABLE Report;
DROP TABLE Garden_Create_Apply;
DROP TABLE Garden_Activity_Invitation;
DROP TABLE Garden_Activity;
DROP TABLE Garden_Comments;
DROP TABLE Garden_Maintenance;
DROP TABLE Garden;
DROP TABLE Blog_Comments;
DROP TABLE Blog;
DROP TABLE Violation_Info;
DROP TABLE Login_Info;
DROP TABLE Admin;
DROP TABLE Account;
DROP TABLE Student_Staff;

-- 在系统上线前先导入所有信息，只作为注册账号时检测学工号是否存在
CREATE TABLE Student_Staff (
    student_staff_id char(10) PRIMARY KEY NOT NULL,
    name varchar(20) NOT NULL
);

-- 存账号基本信息，每次注册插入一条数据
-- 注册账号必须指定：password, account_name, student_staff_id
-- 系统自动生成：account_id, join_time, points(初始为0)
-- 其余字段初始为空
CREATE TABLE Account (
  account_id char(10) PRIMARY KEY NOT NULL,
  password varchar(20) NOT NULL,
  account_name varchar(20) NOT NULL,
  portrait varchar(255),
  bio clob,
  join_time date NOT NULL,
  email varchar(30),
  phone varchar(20),
  points int NOT NULL,
  student_staff_id char(10) NOT NULL,
  FOREIGN KEY(student_staff_id) REFERENCES Student_Staff(student_staff_id)
);

CREATE TABLE Admin (
  admin_id char(10) PRIMARY KEY NOT NULL,
  password varchar(20) NOT NULL,
  student_staff_id char(10) NOT NULL,
  FOREIGN KEY(student_staff_id) REFERENCES Student_Staff(student_staff_id)
);

-- 存每个用户每次登录的时间
CREATE TABLE Login_Info (
  login_info_id char(10) PRIMARY KEY NOT NULL,
  account_id char(10) NOT NULL,
  login_time date NOT NULL,
  FOREIGN KEY (account_id) REFERENCES Account(account_id)
);

-- 每个用户每次违规的具体描述和时间
CREATE TABLE Violation_Info (
  violation_info_id char(10) PRIMARY KEY NOT NULL,
  account_id char(10) NOT NULL,
  violation_description clob NOT NULL,
  violation_time date NOT NULL,
  FOREIGN KEY (account_id) REFERENCES Account(account_id)
);

-- 存博客版块中的博客数据，每次发布博客时插入一条数据
-- blog_id, owner_id, release_time, rating系统自动生成
-- 标题和正文发布时从用户输入读取
-- rating在每次有用户评分后更新(根据rating和rating_num重新算平均)
CREATE TABLE Blog (
  blog_id char(10) PRIMARY KEY NOT NULL,
  owner_id char(10) NOT NULL,
  title varchar(50),
  content clob,
  release_time date NOT NULL,
  rating float,
  rating_num int NOT NULL,
  FOREIGN KEY (owner_id) REFERENCES Account(account_id)
);

-- 存所有博客的评论，以blog_id区分所在哪个博客，每次系统有发布博客评论都插入一条数据
CREATE TABLE Blog_Comments (
  blog_comment_id char(10) PRIMARY KEY NOT NULL,
  blog_id char(10) NOT NULL,
  release_time date NOT NULL,
  content clob,
  FOREIGN KEY (blog_id) REFERENCES Blog(blog_id)
);

-- 创建申请提交后直接插入一条数据，但页面不显示
-- 当审核通过后（通过Garden_Create_Apply），修改状态为Approved，此时可以从中读取数据来显示
CREATE TABLE Garden (
  garden_id char(10) PRIMARY KEY NOT NULL,
  owner_id char(10) NOT NULL,
  pictures varchar(255),
  create_time date NOT NULL,
  description clob,
  position varchar(20),
  stars int,
  status int,
  FOREIGN KEY (owner_id) REFERENCES Account(account_id)
);

-- 存所有花园的评论，以garden_id区分所在哪个花园，每次系统有发布花园评论都插入一条数据
CREATE TABLE Garden_Comments (
  garden_comment_id char(10) PRIMARY KEY NOT NULL,
  garden_id char(10) NOT NULL,
  release_time date NOT NULL,
  content clob,
  FOREIGN KEY (garden_id) REFERENCES Garden(garden_id)
);

CREATE TABLE Garden_Maintenance (
  maintenance_id char(10) PRIMARY KEY NOT NULL,
  garden_id char(10) NOT NULL,
  maintenance_time date,
  volunteer_id char(10) NOT NULL,
  maintenance_description clob,
  point_earned int,
  FOREIGN KEY (garden_id) REFERENCES Garden(garden_id),
  FOREIGN KEY (volunteer_id) REFERENCES Account(account_id)
);

CREATE TABLE Garden_Activity (
  activity_id char(10) PRIMARY KEY NOT NULL,
  garden_id char(10) NOT NULL,
  holder_id char(10) NOT NULL,
  activity_picture varchar(255),
  activity_description clob,
  FOREIGN KEY (garden_id) REFERENCES Garden(garden_id),
  FOREIGN KEY (holder_id) REFERENCES Account(account_id)
);

CREATE TABLE Garden_Activity_Invitation (
  invitation_id char(10) PRIMARY KEY NOT NULL,
  invitor_id char(10) NOT NULL,
  invitee_id char(10) NOT NULL,
  garden_id char(10) NOT NULL,
  FOREIGN KEY (invitor_id) REFERENCES Account(account_id),
  FOREIGN KEY (invitee_id) REFERENCES Account(account_id),
  FOREIGN KEY (garden_id) REFERENCES Garden(garden_id)
);

CREATE TABLE Garden_Create_Apply (
  apply_id char(10) PRIMARY KEY NOT NULL,
  applier_id char(10) NOT NULL,
  apply_time date,
  garden_id char(10) NOT NULL,
  FOREIGN KEY (applier_id) REFERENCES Account(account_id),
  FOREIGN KEY (garden_id) REFERENCES Garden(garden_id)
);

-- 可举报对象：博客，花园，博客评论，花园评论，花园活动
CREATE TABLE Report (
  report_id char(10) PRIMARY KEY NOT NULL,
  reporter_id char(10) NOT NULL,
  reported_content_id char(10),
  report_type int NOT NULL,
  report_time date,
  status int,
  FOREIGN KEY (reporter_id) REFERENCES Account(account_id)
);

-- 存积分商城的商品列表
CREATE TABLE Items (
  item_id char(10) PRIMARY KEY NOT NULL,
  item_name varchar(20) NOT NULL,
  price int NOT NULL,
  item_storage int NOT NULL,
  sales int NOT NULL
);

-- 兑换记录
CREATE TABLE Redeems (
  redeem_id char(10) PRIMARY KEY NOT NULL,
  redeemer char(10) NOT NULL,
  item_id char(10) NOT NULL,
  redeem_time date NOT NULL,
  FOREIGN KEY (redeemer) REFERENCES Account(account_id),
  FOREIGN KEY (item_id) REFERENCES Items(item_id)
);

CREATE TABLE Volunteer_Apply (
  apply_id char(10) PRIMARY KEY NOT NULL,
  account_id char(10) NOT NULL,
  apply_description clob,
  is_approved int,
  FOREIGN KEY (account_id) REFERENCES Account(account_id)
);

CREATE TABLE Volunteer_Recruit (
  recruitment_id char(10) PRIMARY KEY NOT NULL,
  garden_id char(10) NOT NULL,
  recruiter_id char(10) NOT NULL,
  recruit_time date NOT NULL,
  recruit_content clob,
  FOREIGN KEY (garden_id) REFERENCES Garden(garden_id),
  FOREIGN KEY (recruiter_id) REFERENCES Account(account_id)
);

COMMIT;