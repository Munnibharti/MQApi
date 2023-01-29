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

		public DbSet<Region> Regions { get; set; }
	    
		public DbSet<Walk> Walks { get; set; }

		public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
        
    }
}
