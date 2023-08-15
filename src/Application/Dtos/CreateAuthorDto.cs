using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class CreateAuthorDto
    {
        [Required(ErrorMessage = "Field Name is mandatory")]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
