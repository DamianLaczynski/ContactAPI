using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Entities
{
    [Index(nameof(Category.Name),IsUnique =true)]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
