using System.ComponentModel;

namespace HomeCare.Models
{
    /**
     * 
     * -- 账户表
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
     */
    public class Zhanghu
    {
        [DisplayName("编号")]
        public int Id { get; set; }

        [DisplayName("用户名")]
        public string? Username { get; set; }

        [DisplayName("用户密码")]
        public string? Userpassword { get; set; }

        [DisplayName("手机号")]
        public string? Phone { get; set; }

        [DisplayName("账号类型")]
        public string? Type { get; set; }

        [DisplayName("子女电话")]
        public string? Phone_zinv { get; set; }

        [DisplayName("居住地")]
        public string? Address { get; set; }

        [DisplayName("头像")]
        public string? Image { get; set; }

        [DisplayName("年龄")]
        public int? Age { get; set; }

        [DisplayName("老人的账号才有子女")]
        public string? Zinv_name { get; set; }

    }
}
