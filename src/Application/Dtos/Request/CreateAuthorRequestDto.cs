using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Request
{
    public class CreateAuthorRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
