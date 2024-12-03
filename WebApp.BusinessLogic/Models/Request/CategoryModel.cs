namespace WebApp.BusinessLogic.Models.Request
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductModel> Product { get; set; }
    }
}
