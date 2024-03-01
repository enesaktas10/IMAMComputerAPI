using System.ComponentModel.DataAnnotations;

namespace IMAMComputerAPI.Models
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }

        public DateTime OrderDateTime { get; set; }



        //F.K
        public Guid BasketID { get; set; }
        public Basket Basket { get; set; }
    }
}
