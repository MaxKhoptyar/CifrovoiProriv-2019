using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHermesEntities
{
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
        public virtual DbSet<Claim> Claim { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<OrganisationInfo> OrganisationInfo { get; set; }
        public virtual DbSet<ClaimUserCollaboration> ClaimUserCollaboration { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        public virtual DbSet<StatisticRating> StatisticRating { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>().Property(e => e.Id);
        }
    }
}
