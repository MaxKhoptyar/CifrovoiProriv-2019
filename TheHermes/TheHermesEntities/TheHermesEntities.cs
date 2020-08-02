using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
    public static class LocalStorage
    {
        public static List<Education> Education { get; set; }
        public static List<Population> Population { get; set; }
        public static List<StateOfMarriage> StateOfMarriage { get; set; }
        public static List<MakeMoney> MakeMoney { get; set; }

        public static Dictionary<string,string> DictionaryRegions { get; set; } 

    }

    public class TheHermesEntities : DbContext
    {
        public TheHermesEntities(string connStringName)
            : base("name=" + (connStringName ?? "TheHermesEntities"))
        {
            Database.SetInitializer<TheHermesEntities>(null);
        }

        public TheHermesEntities()
            : base("name=TheHermesEntities")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer<TheHermesEntities>(null);
        }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Population> Population { get; set; }
        public virtual DbSet<StateOfMarriage> StateOfMarriage { get; set; }
        public virtual DbSet<MakeMoney> MakeMoney { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>().Property(e => e.Id);
        }
    }
}
