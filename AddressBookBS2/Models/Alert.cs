using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCare.Models
{
    [Table("警报表")]
    public class Alert
    {

        /**

create table alert(
 id int identity(1,1),-- 警报编号
 oldman varchar(100) not null default(''),-- 老人名字
 result1  varchar(100) not null default(''),-- 早-打卡结果 0：待打卡 1：已打卡  
 result2 varchar(100) not null default(''),--  中-打卡结果 0：待打卡 1：已打卡  
 result3  varchar(100) not null default(''),-- 晚-打卡结果 0：待打卡 1：已打卡 
 createtime   datetime not null default('1900-01-01'),--  生成时间
 CONSTRAINT PK_alert PRIMARY KEY CLUSTERED(id) -- 主键
);
 
 */
        [DisplayName("编号")]
        public int Id { get; set; }

        [DisplayName("老人名字")]
        public string? Oldman { get; set; }

        [DisplayName("早-打卡结果 0：待打卡 1：已打卡")]
        public string? Result1 { get; set; }

        [DisplayName("中-打卡结果 0：待打卡 1：已打卡")]
        public string? Result2 { get; set; }

        [DisplayName("晚-打卡结果 0：待打卡 1：已打卡")]
        public string? Result3 { get; set; }

        [DisplayName("生成时间")]
        public DateTime? Createtime { get; set; }

    }
}
