using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCare.Models
{
    public class Jiankang
    {

        /**
 * 
-- 老人上报健康表
create table jiankang(
 id int identity(1,1),-- 编号
 username varchar(50) not null default(''),-- 老人姓名
 收缩压 varchar(50) not null default(''), 
 舒张压 varchar(50) not null default(''), 
 血糖 varchar(50) not null default(''), 
 心率 varchar(50) not null default(''), 
 血氧 varchar(50) not null default(''), 
 年龄 varchar(50) not null default(''), 
 图片 varchar(50) not null default(''), 
 createtime datetime  not null default('1900-01-01'), 
 CONSTRAINT PK_jiankang PRIMARY KEY CLUSTERED(id) -- 主键
); 
 */
        [DisplayName("编号")]
        public int Id { get; set; }

        [DisplayName("老人姓名")]
        public string? Username { get; set; }

        [DisplayName("收缩压")]
        [Column("收缩压")]
        public string? Shousuoya { get; set; }

        [DisplayName("舒张压")]
        [Column("舒张压")]
        public string? Shuzhangya { get; set; }

        [DisplayName("血糖")]
        [Column("血糖")]
        public string? Xuetang { get; set; }

        [DisplayName("心率")]
        [Column("心率")]
        public string? Xinlv { get; set; }

        [DisplayName("血氧")]
        [Column("血氧")]
        public string? Xueyang { get; set; }

        [DisplayName("年龄")]
        [Column("年龄")]
        public string? Age { get; set; }

        [DisplayName("图片")]
        [Column("图片")]
        public string? Image { get; set; }

        [DisplayName("创建时间")]
        public DateTime? Createtime { get; set; }
    }
}
