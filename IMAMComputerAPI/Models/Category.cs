using System.ComponentModel.DataAnnotations;

namespace IMAMComputerAPI.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }


        //P.K 
        public List<Product> Products { get; set; }
    }
}
