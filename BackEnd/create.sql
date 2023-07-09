DROP TABLE Student;
DROP TABLE Administer;
DROP TABLE Login_Info;
DROP TABLE Violation_Info;
DROP TABLE Account_Profile;
DROP TABLE Blog_Ratings;
DROP TABLE Blog_Comment;
DROP TABLE Blog;
DROP TABLE Apply;
DROP TABLE Report_approval_history;
DROP TABLE Report;
DROP TABLE Garden_Maintenance;
DROP TABLE Garden_Invitation;
DROP TABLE Garden_Activity;
DROP TABLE Points_Redeem;
DROP TABLE Points_Mall;
DROP TABLE Act_Application;
DROP TABLE Act_Works;
DROP TABLE Voluntary_Activities;
DROP TABLE Act_Recruitment;
DROP TABLE Garden;
DROP TABLE Account;

CREATE TABLE Account (
  account_id INT PRIMARY KEY,
  password VARCHAR(50),
  account_type VARCHAR(50),
  create_time DATE
);

CREATE TABLE Student (
  stu_id INT PRIMARY KEY,
  name VARCHAR(50),
  account_id INT,
  point INT,
  FOREIGN KEY (account_id) REFERENCES Account(account_id)
);

CREATE TABLE Administer (
  admin_id INT PRIMARY KEY,
  admin_name VARCHAR(50),
  account_id INT,
  FOREIGN KEY (account_id) REFERENCES Account(account_id)
);

CREATE TABLE Login_Info (
  login_info_id INT PRIMARY KEY,
  account_id INT,
  login_time DATE,
  login_location VARCHAR(50),
  FOREIGN KEY (account_id) REFERENCES Account(account_id)
);

CREATE TABLE Violation_Info (
  account_id INT PRIMARY KEY,
  violation_description VARCHAR(50),
  violation_time DATE,
  FOREIGN KEY (account_id) REFERENCES Account(account_id)
);

CREATE TABLE Account_Profile (
  account_id INT PRIMARY KEY,
  avatar VARCHAR(50),
  otherinfo VARCHAR(50),
  registration_time DATE,
  FOREIGN KEY (account_id) REFERENCES Account(account_id)
);

CREATE TABLE Blog (
  blog_id INT PRIMARY KEY,
  account_id INT,
  blog_type VARCHAR(50),
  title VARCHAR(50),
  release_time DATE,
  interactive_rating INT,
  is_legal INT,
  FOREIGN KEY (account_id) REFERENCES Account(account_id)
);

CREATE TABLE Blog_Ratings (
  blog_rating_id INT PRIMARY KEY,
  blog_id INT,
  account_id INT,
  rating_value INT,
  rating_time DATE,
  FOREIGN KEY (blog_id) REFERENCES Blog(blog_id),
  FOREIGN KEY (account_id) REFERENCES Account(account_id)
);

CREATE TABLE Blog_Comment (
  comment_id INT,
  blog_id INT,
  comment_content VARCHAR(50),
  commentator_id INT,
  comment_time DATE,
  PRIMARY KEY (comment_id, blog_id),
  FOREIGN KEY (blog_id) REFERENCES Blog(blog_id),
  FOREIGN KEY (commentator_id) REFERENCES Account(account_id)
);

CREATE TABLE Apply (
  apply_id INT PRIMARY KEY,
  account_id INT,
  apply_type VARCHAR(50),
  apply_time DATE,
  is_approved INT,
  FOREIGN KEY (account_id) REFERENCES Account(account_id)
);

CREATE TABLE Report (
  report_id INT PRIMARY KEY,
  reporter_id INT,
  reported_user_id INT,
  reported_content_id INT,
  report_type VARCHAR(50),
  report_time DATE,
  FOREIGN KEY (reporter_id) REFERENCES Account(account_id),
  FOREIGN KEY (reported_user_id) REFERENCES Account(account_id)
);

CREATE TABLE Report_approval_history (
  approval_id INT PRIMARY KEY,
  report_id INT,
  approval_result VARCHAR(50),
  approval_time DATE,
  FOREIGN KEY (report_id) REFERENCES Report(report_id)
);

CREATE TABLE Garden (
  garden_id INT PRIMARY KEY,
  owner_id INT,
  create_time DATE,
  garden_pos VARCHAR(50),
  garden_size INT,
  rating INT,
  is_public INT,
  FOREIGN KEY (owner_id) REFERENCES Account(account_id)
);

CREATE TABLE Garden_Maintenance (
  garden_id INT,
  maintenance_id INT,
  maintenance_time DATE,
  maintainer_id INT,
  maintenance_description VARCHAR(50),
  PRIMARY KEY(garden_id, maintenance_id),
  FOREIGN KEY (garden_id) REFERENCES Garden(garden_id),
  FOREIGN KEY (maintainer_id) REFERENCES Account(account_id)
);

CREATE TABLE Garden_Activity (
  activity_id INT PRIMARY KEY,
  garden_id INT,
  activity_name VARCHAR(50),
  activity_time DATE,
  activity_theme VARCHAR(50),
  FOREIGN KEY (garden_id) REFERENCES Garden(garden_id)
);

CREATE TABLE Garden_Invitation (
  invitation_id INT PRIMARY KEY,
  activity_id INT,
  invitee_id INT,
  FOREIGN KEY (activity_id) REFERENCES Garden_Activity(activity_id),
  FOREIGN KEY (invitee_id) REFERENCES Account(account_id)
);

CREATE TABLE Points_Mall (
  item_id INT PRIMARY KEY,
  item_name VARCHAR(50),
  item_type VARCHAR(50),
  points_required INT,
  item_storage INT
);

CREATE TABLE Points_Redeem (
  redeem_id INT PRIMARY KEY,
  account_id INT,
  item_id INT,
  redeem_time DATE,
  FOREIGN KEY (account_id) REFERENCES Account(account_id),
  FOREIGN KEY (item_id) REFERENCES Points_Mall(item_id)
);

CREATE TABLE Act_Recruitment (
  act_recruitment_id INT PRIMARY KEY,
  garden_id INT,
  recruiter_id INT,
  recruiter_time DATE,
  recruiter_content VARCHAR(50),
  FOREIGN KEY (garden_id) REFERENCES Garden(garden_id),
  FOREIGN KEY (recruiter_id) REFERENCES Account(account_id)
);

CREATE TABLE Voluntary_Activities (
  act_id INT PRIMARY KEY,
  garden_id INT,
  act_description VARCHAR(50),
  act_points INT,
  act_recruitment_id INT,
  act_participants_id INT,
  FOREIGN KEY (act_recruitment_id) REFERENCES Act_Recruitment(act_recruitment_id),
  FOREIGN KEY (garden_id) REFERENCES Garden(garden_id)
);

CREATE TABLE Act_Application (
  act_application_id INT PRIMARY KEY,
  act_id INT,
  account_id INT,
  app_description VARCHAR(50),
  application_result VARCHAR(50),
  is_approved INT,
  FOREIGN KEY (account_id) REFERENCES Account(account_id),
  FOREIGN KEY (act_id) REFERENCES Voluntary_Activities(act_id)
);

CREATE TABLE Act_Works (
  act_id INT,
  act_works_id INT PRIMARY KEY,
  worker_id INT,
  work_description VARCHAR(50),
  work_time DATE,
  submission_time DATE,
  rewards INT,
  FOREIGN KEY (act_id) REFERENCES Voluntary_Activities(act_id),
  FOREIGN KEY (worker_id) REFERENCES Account(account_id)
);

commit;