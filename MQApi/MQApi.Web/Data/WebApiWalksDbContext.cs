using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MQApi.Web.Model.Domain;
using System.Security.Cryptography.X509Certificates;

namespace MQApi.Web.Data
{
	public class WebApiWalksDbContext:DbContext
	{
		public WebApiWalksDbContext(DbContextOptions<WebApiWalksDbContext> options):base(options)

		{
	      

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Role>()
                .HasOne(x => x.Role)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<User_Role>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.UserId);
        }


        public DbSet<Region> Regions { get; set; }
	    
		public DbSet<Walk> Walks { get; set; }

		public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_Role> Users_Roles { get; set; }

    }
}
