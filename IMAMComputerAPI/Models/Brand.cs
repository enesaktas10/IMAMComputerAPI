using System.ComponentModel.DataAnnotations;

namespace IMAMComputerAPI.Models
{
    public class Brand
    {
        [Key]
        public Guid BrandID { get; set; }
        public string BrandName { get; set; }


        //P.K
        public List<Product > Products { get; set; }

    }
}
