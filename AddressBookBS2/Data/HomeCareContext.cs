using Microsoft.EntityFrameworkCore;

namespace HomeCare.Data
{
    public class HomeCareContext : DbContext
    {
        public HomeCareContext(DbContextOptions<HomeCareContext> options)
            : base(options)
        {
        }

        public DbSet<HomeCare.Models.Daka> Daka { get; set; } = default!;

        public DbSet<HomeCare.Models.Zhanghu> Zhanghu { get; set; } = default!;

        public DbSet<HomeCare.Models.Jiankang> Jiankang { get; set; } = default!;

        public DbSet<HomeCare.Models.Alert> Alert { get; set; } = default!;

        public DbSet<HomeCare.Models.Fall> Fall { get; set; } = default!;

        public DbSet<HomeCare.Models.Food> Food { get; set; } = default!;

        public DbSet<HomeCare.Models.Message_doctor> Message_doctor { get; set; } = default!;

        public DbSet<HomeCare.Models.Message_oldman> Message_oldman { get; set; } = default!;

        public DbSet<HomeCare.Models.Video> Video { get; set; } = default!;
    }
}
