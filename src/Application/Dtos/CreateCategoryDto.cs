using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Field Name is mandatory")]
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
