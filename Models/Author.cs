using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome inválido")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "E-mail obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}