using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCare.Models
{
    public class Fall
    {

        [DisplayName("编号")]
        public int Id { get; set; }

        [DisplayName("状态")]
        [Column("Fall")]
        public int Status { get; set; }

    }
}
