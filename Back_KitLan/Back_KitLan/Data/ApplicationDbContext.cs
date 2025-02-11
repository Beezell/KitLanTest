using Back_KitLan.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_KitLan.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }

	}
}
