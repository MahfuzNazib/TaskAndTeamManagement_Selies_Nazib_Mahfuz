using TaskAndTeamManagement.Application.Dtos.Auth.Login;
using TaskAndTeamManagement.Application.Dtos.Auth.Registration;
using TaskAndTeamManagement.Application.Helpers;

namespace TaskAndTeamManagement.Application.IService.Authentication
{
    public interface IAuthenticationService
    {
        Task<ApiResponse<bool>> UserRegistrationAsync(UserRegistrationDto userRegistrationDto);
        Task<ApiResponse<LoginResponse?>> UserLoginAsync(LoginRequestDto loginRequestDto);
    }
}
