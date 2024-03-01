namespace IMAMComputerAPI.Dto
{
    public class AddProductDto
    {
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDesciption { get; set; }
        public Guid CategoryID { get; set; }
        public Guid BrandID { get; set; }
    }
}
