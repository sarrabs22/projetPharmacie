using System.ComponentModel.DataAnnotations;

namespace pharmacie_ami_salah.Models
{
    public class Produits
    {
        [Key]
        public int id_prod { get; set; }
        public int prix { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public DateTime date { get; set; }

        public IList<Commandes> commandes { get; set; }




    }
}
