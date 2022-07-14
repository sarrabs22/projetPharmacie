using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharmacie_ami_salah.Models
{
    public class Commandes
    {
        [Key]
        public int Id_commande { get; set; }


        public int Id_produit { get; set; }
        [ForeignKey("Id_produit")]
        public Produits produit { get; set; }

    }
}
