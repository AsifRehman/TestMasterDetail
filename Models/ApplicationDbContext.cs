using Microsoft.EntityFrameworkCore;
using TestMasterDetail.Models;

namespace TestMasterDetail.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<tbl_Party> tbl_Party { get; set; }
        public DbSet<tbl_PartyType> tbl_PartyType { get; set; }
        public DbSet<tbl_PartyCateg> tbl_PartyCateg { get; set; }
        public DbSet<tbl_Ledger> tbl_Ledger { get; set; }

    }
}
