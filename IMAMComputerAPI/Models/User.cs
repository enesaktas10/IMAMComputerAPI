using System.ComponentModel.DataAnnotations;

namespace IMAMComputerAPI.Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        public string UserFirstName { get; set; } = String.Empty;
        public string UserLastName { get; set; } = String.Empty;
        public string UserEmail { get; set; } = String.Empty;
        public string UserPassword { get; set; } = String.Empty;
        public string UserCity { get; set; } = String.Empty;
        public string UserDistrict { get; set; } = String.Empty;
        public string UserAddressDetails { get; set; } = String.Empty;



        //P.K
        public List<Basket> Baskets { get; set; }


    }
}
