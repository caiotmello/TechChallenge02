using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Request
{
    public class CreateCategoryRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
