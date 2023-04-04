using System.ComponentModel.DataAnnotations;

namespace ContactAPI.Entities
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

    }
}