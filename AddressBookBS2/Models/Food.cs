using System.ComponentModel;

namespace HomeCare.Models
{
    public class Food
    {

        /**
-- 食谱表
create table food(
 id int identity(1,1),--  食谱编号
 foodname varchar(50) not null default(''),-- 食物名称
 url varchar(100) not null default(''),-- 食物图片链接
 remark varchar(1000) not null default(''),-- 描述
 zuofa varchar(1000) not null default(''),-- 做法
 CONSTRAINT PK_food PRIMARY KEY CLUSTERED(id) -- 主键
);
 */
        [DisplayName("编号")]
        public int Id { get; set; }

        [DisplayName("食物名称")]
        public string? Foodname { get; set; }

        [DisplayName("食物图片链接")]
        public string? Url { get; set; }

        [DisplayName("描述")]
        public string? Remark { get; set; }

        [DisplayName("做法")]
        public string? Zuofa { get; set; }


    }
}
