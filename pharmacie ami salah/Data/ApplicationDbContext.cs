using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pharmacie_ami_salah.Models;

namespace pharmacie_ami_salah.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<pharmacie_ami_salah.Models.Produits>? Produits { get; set; }
        public DbSet<pharmacie_ami_salah.Models.Commandes>? Commandes { get; set; }
        public DbSet<pharmacie_ami_salah.Models.ApplicationUser>? ApplicationUser { get; set; }
    }
}