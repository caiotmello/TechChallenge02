using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Response
{
    public class UserLoginResponseDto
    {
        public string? Token { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public UserLoginResponseDto(string token, DateTime expiryDate)
        {
            this.Token = token;
            this.ExpiryDate = expiryDate;
        }
    }
}
