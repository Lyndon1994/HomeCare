﻿-- ALTER DATABASE 居家养老系统 COLLATE Chinese_PRC_CI_AS;

create database HomeCare COLLATE Chinese_PRC_CI_AS;

ALTER DATABASE HomeCare COLLATE Chinese_PRC_CI_AS;

use HomeCare;
-- 账户表
create table zhanghu(
 id int identity(1,1),-- 用户编号
 username varchar(50) not null default(''),-- 用户名
 userpassword varchar(50) not null default(''),-- 用户密码
 phone varchar(50) not null default(''),-- 手机号	
 type varchar(50) not null default(''),-- 账号类型  医生/老人/子女
 phone_zinv varchar(50) not null default(''),-- 子女电话
 address varchar(100) not null default(''),-- 居住地
 image varchar(100) not null default(''),-- 头像 
 age int not null default(0),-- 年龄
 zinv_name varchar(50) not null default(''),-- 老人的账号才有子女
 CONSTRAINT PK_zhanghu PRIMARY KEY CLUSTERED(id) -- 主键
);
   insert into zhanghu(username,userpassword,phone,type,phone_zinv,address,image,age,zinv_name) values('医生','1','110','医生','','辽宁省沈阳市沈北新区三盛颐景园','/img/20.jpg',60,'');
insert into zhanghu(username,userpassword,phone,type,phone_zinv,address,image,age,zinv_name) values('老人1','1','1234567789','老人','3268597851','辽宁省沈阳市沈北新区新湖仙林金谷','/img/1.jpg',77,'子女1');
insert into zhanghu(username,userpassword,phone,type,phone_zinv,address,image,age,zinv_name) values('老人2','1','1569875154','老人','3268597852','辽宁省沈阳市沈北新区中南高科沈阳智造园','/img/2.jpg',78,'子女2');
insert into zhanghu(username,userpassword,phone,type,phone_zinv,address,image,age,zinv_name) values('老人3','1','6598456851','老人','3268597853','辽宁省沈阳市沈北新区融创观澜壹号','/img/3.jpg',75,'子女3');
insert into zhanghu(username,userpassword,phone,type,phone_zinv,address,image,age,zinv_name) values('子女1','1','1234567789','子女','3268597854','辽宁省沈阳市沈北新区中瑞府','',45,'');
insert into zhanghu(username,userpassword,phone,type,phone_zinv,address,image,age,zinv_name) values('子女2','1','1569875154','子女','3268597855','辽宁省沈阳市沈北新区龙湖香醍漫步','',46,'');
insert into zhanghu(username,userpassword,phone,type,phone_zinv,address,image,age,zinv_name) values('子女3','1','6598456851','子女','3268597856','辽宁省沈阳市沈北新区恒大时代新城','',47,'');
-- 老人上报健康表
create table jiankang(
 id int identity(1,1),-- 编号
 username varchar(50) not null default(''),-- 老人姓名
 Shousuoya varchar(50) not null default(''), 
 Shuzhangya varchar(50) not null default(''), 
 Xuetang varchar(50) not null default(''), 
 Xinlv varchar(50) not null default(''), 
 Xueyang varchar(50) not null default(''), 
 Age varchar(50) not null default(''), 
 Image varchar(50) not null default(''), 
 createtime datetime  not null default('1900-01-01'), 
 CONSTRAINT PK_jiankang PRIMARY KEY CLUSTERED(id) -- 主键
); 
insert into jiankang(username,Shousuoya,Shuzhangya,Xuetang,Xinlv,Xueyang,Age,Image,createtime)values
('老人1','120','70','4.2','70','97','77','/img/1.jpg','2023-05-01'),
('老人1','122','69','4.1','73','96','77','/img/1.jpg','2023-05-03'),
('老人1','123','68','4.0','72','97','77','/img/1.jpg','2023-05-05'),
('老人1','123','71','4.2','71','97','77','/img/1.jpg','2023-05-07'),
('老人1','120','70','3.9','73','96','77','/img/1.jpg','2023-05-09'),
('老人1','119','69','4.0','72','95','77','/img/1.jpg', '2023-05-11'),
('老人1','125','70','4.1','71','96','77','/img/1.jpg','2023-05-13'),
													  
('老人2','120','70','4.2','70','97','71','/img/2.jpg','2023-05-01'),
('老人2','122','69','4.1','73','96','71','/img/2.jpg','2023-05-03'),
('老人2','123','68','4.0','72','97','71','/img/2.jpg','2023-05-05'),
('老人2','123','71','4.2','71','97','71','/img/2.jpg','2023-05-07'),
('老人2','120','70','3.9','73','96','71','/img/2.jpg','2023-05-09'),
('老人2','119','69','4.0','72','95','71','/img/2.jpg','2023-05-11'),
('老人2','125','70','4.1','71','96','71','/img/2.jpg','2023-05-13'),
													  
('老人3','120','70','4.2','70','97','75','/img/3.jpg','2023-05-01'),
('老人3','122','69','4.1','73','96','75','/img/3.jpg','2023-05-03'),
('老人3','123','68','4.0','72','97','75','/img/3.jpg','2023-05-05'),
('老人3','123','71','4.2','71','97','75','/img/3.jpg','2023-05-07'),
('老人3','120','70','3.9','73','96','75','/img/3.jpg','2023-05-09'),
('老人3','119','69','4.0','72','95','75','/img/3.jpg','2023-05-11'),
('老人3','125','70','4.1','71','96','75','/img/3.jpg','2023-05-13');

-- 医生留言表
create table message_doctor(
 id int identity(1,1),--  留言编号
 zh_name varchar(100) not null default(''),-- 医生的姓名
 context varchar(1000) not null default(''),-- 留言内容
 age int not null default(0),-- 年龄
 image varchar(100) not null default(''),-- 头像 
 createtime datetime  not null default('1900-01-01'), --留言时间
 oldman varchar(100) not null default(0),-- 老人名字
 CONSTRAINT PK_message_doctor PRIMARY KEY CLUSTERED(id) -- 主键
);
      insert into message_doctor(zh_name,context,age,image,createtime,oldman)values
   ('医生','注意早睡早起哦1。',60,'/img/20.jpg',getdate(),'老人1'),
   ('医生','饮食一定要规律1。',60,'/img/20.jpg',getdate(),'老人1'),
   ('医生','多吃水果蔬菜，少吃油腻的，禁烟酒哦1~',60,'/img/20.jpg',getdate(),'老人1'),
    ('医生','注意早睡早起哦2。',60,'/img/20.jpg',getdate(),'老人2'),
   ('医生','饮食一定要规律2。',60,'/img/20.jpg',getdate(),'老人2'),
   ('医生','多吃水果蔬菜，少吃油腻的，禁烟酒哦2~',60,'/img/20.jpg',getdate(),'老人2'),
    ('医生','注意早睡早起哦3。',60,'/img/20.jpg',getdate(),'老人3'),
   ('医生','饮食一定要规律3。',60,'/img/20.jpg',getdate(),'老人3'),
   ('医生','多吃水果蔬菜，少吃油腻的，禁烟酒哦3~',60,'/img/20.jpg',getdate(),'老人3');

    

-- 老人留言表
create table message_oldman(
 id int identity(1,1),--  留言编号
 zh_name varchar(100) not null default(''),-- 老人的姓名
 context varchar(100) not null default(''),-- 留言内容
 age int not null default(0),-- 年龄
 image varchar(100) not null default(''),-- 头像 
  createtime datetime  not null default('1900-01-01'), --留言时间
 CONSTRAINT PK_message_oldman PRIMARY KEY CLUSTERED(id) -- 主键
);
insert into message_oldman(zh_name,context,age,image,createtime)
 values('老人1','医生您好~我晚上有时候会失眠~请问下如何调理',77,'/img/1.jpg',getdate()),
 ('老人2','一到下雨天，我的膝盖骨会疼，该怎么办',78,'/img/2.jpg',getdate()),
 ('老人3','又是新的一年，张医生新年快乐！',75,'/img/3.jpg',getdate());


-- 食谱表
create table food(
 id int identity(1,1),--  食谱编号
 foodname varchar(50) not null default(''),-- 食物名称
 url varchar(100) not null default(''),-- 食物图片链接
 remark varchar(1000) not null default(''),-- 描述
 zuofa varchar(1000) not null default(''),-- 做法
 CONSTRAINT PK_food PRIMARY KEY CLUSTERED(id) -- 主键
);
insert into food(foodname,url,remark,zuofa)
values('糖醋排骨','/img/21.jpg','排骨焖至30分钟，完全酥软','1.先煲一锅水开水把排骨绰水，然后再用清水清洗干净2.锅里放入少许油，把冰糖放入小火煮开冰糖3.直到冰糖煮到焦糖的颜色4.把排骨放入翻炒5.再把姜片放入炒出姜片的味道'),
('小鸡炖蘑菇','/img/23.jpg','新鲜的蘑菇大补','方法一做法二所需食材：散养小鸡750g，干榛蘑150g，植物油、精盐、生姜、小葱、八角、桂皮、香叶、老抽适量。'),
('红枣凤梨汤','/img/24.jpg','清凉可口','材料 新鲜白木耳 100g,凤梨 1/4颗,红枣 10颗,水 1600cc,黄冰糖 ');
 


-- 视频地址表
create table video(
 id int identity(1,1),-- 视频编号
 oldman varchar(100) not null default(''),-- 老人名字
 url varchar(500) not null default(''),-- 视频链接
 CONSTRAINT PK_video PRIMARY KEY CLUSTERED(id) -- 主键
);

 insert into  video(oldman,url)values('老人1','https://open.ys7.com/v3/openlive/G45758252_1_2.m3u8?expire=1714921299&id=576906799064555520&t=dd17826dad6f1af1adbf26afdbb2debde9e51dc120f9bb519da808ae2dfbae8b&ev=100'); 
 insert into  video(oldman,url)values('老人2','https://open.ys7.com/v3/openlive/G71138540_1_2.m3u8?expire=1714921318&id=576906880501161984&t=fcf754475c6c812575d95b5055e7083d61755f1442117745c92d4b6adb29c19f&ev=100');


 
-- 打卡表
create table daka(
 id int identity(1,1),-- 打卡编号
 zh_name varchar(100) not null default(''),-- 老人的姓名
 createtime datetime not null default('1900-01-01'),-- 打卡时间
 CONSTRAINT PK_daka PRIMARY KEY CLUSTERED(id) -- 主键
);

create table alert(
 id int identity(1,1),-- 警报编号
 oldman varchar(100) not null default(''),-- 老人名字
 result1  varchar(100) not null default(''),-- 早-打卡结果 0：待打卡 1：已打卡  
 result2 varchar(100) not null default(''),--  中-打卡结果 0：待打卡 1：已打卡  
 result3  varchar(100) not null default(''),-- 晚-打卡结果 0：待打卡 1：已打卡 
 createtime   datetime not null default('1900-01-01'),--  生成时间
 CONSTRAINT PK_alert PRIMARY KEY CLUSTERED(id) -- 主键
);
 

CREATE TABLE [dbo].[fall] (
    [id]   INT NOT NULL,
    [fall] INT NOT NULL
);

