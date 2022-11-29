using Microsoft.EntityFrameworkCore;

namespace API_hienchanel.Data
{
    public class MyDbContext :DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) 
        {

        }
        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<LoaiHangHoa> loais { get; set; }
        public DbSet<test> test { get; set; }
        #endregion
    }
}
