using System.ComponentModel;

namespace HomeCare.Models
{
    public class Daka
    {
        [DisplayName("编号")]
        public int Id { get; set; }

        [DisplayName("老人的姓名")]
        public string? Zh_name { get; set; }

        [DisplayName("打卡时间")]
        public DateTime? Createtime { get; set; }
    }
}
