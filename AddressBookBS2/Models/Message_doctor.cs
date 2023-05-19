using System.ComponentModel;

namespace HomeCare.Models
{
    public class Message_doctor
    {

        /**
 * 
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
 */
        [DisplayName("编号")]
        public int Id { get; set; }

        [DisplayName("医生的姓名")]
        public string? Zh_name { get; set; }

        [DisplayName("留言内容")]
        public string? Context { get; set; }

        [DisplayName("年龄")]
        public int? Age { get; set; }

        [DisplayName("头像")]
        public string? Image { get; set; }

        [DisplayName("留言时间")]
        public DateTime? Createtime { get; set; }

        [DisplayName("老人名字")]
        public string? Oldman { get; set; }
    }
}
