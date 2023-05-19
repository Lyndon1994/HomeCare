using System.ComponentModel;

namespace HomeCare.Models
{
    public class Video
    {

        /**
-- 视频地址表
create table video(
 id int identity(1,1),-- 视频编号
 oldman varchar(100) not null default(''),-- 老人名字
 url varchar(500) not null default(''),-- 视频链接
 CONSTRAINT PK_video PRIMARY KEY CLUSTERED(id) -- 主键
);
 */
        [DisplayName("编号")]
        public int Id { get; set; }

        [DisplayName("老人名字")]
        public string? Oldman { get; set; }

        [DisplayName("视频链接")]
        public string? Url { get; set; }

    }
}
