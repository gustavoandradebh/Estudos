using System.ComponentModel.DataAnnotations;

namespace MinhaFloresta.Domain.Entity
{
    public class User: BaseEntity
    {
        [Required]
        public string Email { get; set; }
    }
}
