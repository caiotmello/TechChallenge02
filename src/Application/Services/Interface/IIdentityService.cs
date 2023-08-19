using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Services.Interface
{
    public interface IIdentityService
    {
        Task<ResultService> SignUpAsync(UserSignUpRequestDto userSignUpDto);
        Task<ResultService<UserLoginResponseDto>> LoginAsync(UserLoginRequestDto userLoginDto);
    }
}
