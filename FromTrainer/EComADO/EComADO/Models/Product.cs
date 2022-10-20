namespace EComADO.Models
{

    public class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }


        public Product(int ProductId, string ProductName, string Category)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.Category = Category;
        }
    }
}
