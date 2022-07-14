using Microsoft.AspNetCore.Identity;

namespace pharmacie_ami_salah.Models
{
    public class ApplicationUser: IdentityUser
    {

        public IList<Commandes> commandes { get; set; }
    }
}
