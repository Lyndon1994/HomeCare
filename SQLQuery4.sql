
drop table 警报表
go

create table alert(
 id int identity(1,1),-- 警报编号
 oldman varchar(100) not null default(''),-- 老人名字
 result1  varchar(100) not null default(''),-- 早-打卡结果 0：待打卡 1：已打卡  
 result2 varchar(100) not null default(''),--  中-打卡结果 0：待打卡 1：已打卡  
 result3  varchar(100) not null default(''),-- 晚-打卡结果 0：待打卡 1：已打卡 
 createtime   datetime not null default('1900-01-01'),--  生成时间
 CONSTRAINT PK_alert PRIMARY KEY CLUSTERED(id) -- 主键
);
 