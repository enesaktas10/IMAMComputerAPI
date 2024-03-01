using System.ComponentModel.DataAnnotations;

namespace IMAMComputerAPI.Models
{
    public class Basket
    {
        [Key]
        public Guid BasketID { get; set; }

        public decimal BasketPrice { get; set; }
        public int BasketProductQuantity { get; set; }


        //F.K

        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        

        //F.K

        public Guid UserID { get; set; }
        public User User { get; set; }

        
        //P.K
        public List<Order> Orders { get; set; }
    }
}
