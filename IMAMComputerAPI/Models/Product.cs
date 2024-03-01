using System.ComponentModel.DataAnnotations;

namespace IMAMComputerAPI.Models
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDesciption { get; set; }
        public string? ProductImage1 { get; set; }
        public string? ProductImage2 { get; set; }
        public string? ProductImage3 { get; set; }


        //F.K

        public Guid CategoryID { get; set; }
        public Category Category { get; set; }


        //F.K
        public Guid BrandID { get; set; }
        public Brand Brand { get; set; }
        

        //P.K
        public List<Basket> Baskets { get; set; }

    }
}
