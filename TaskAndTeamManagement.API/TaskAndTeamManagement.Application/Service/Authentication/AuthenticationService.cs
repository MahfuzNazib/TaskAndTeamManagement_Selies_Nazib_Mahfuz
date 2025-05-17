
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TaskAndTeamManagement.Application.Dtos.Auth.Login;
using TaskAndTeamManagement.Application.Dtos.Auth.Registration;
using TaskAndTeamManagement.Application.Helpers;
using TaskAndTeamManagement.Application.IService.Authentication;
using TaskAndTeamManagement.Domain.Entities;
using TaskAndTeamManagement.Domain.IRepository.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace TaskAndTeamManagement.Application.Service.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        public async Task<ApiResponse<bool>> UserRegistrationAsync(UserRegistrationDto userRegistrationDto)
        {
            var (hashedPassword, salt) = await PasswordHashing(userRegistrationDto.Password);

            var user = new User
            {
                FullName = userRegistrationDto.FullName,
                Email = userRegistrationDto.Email,
                Password = hashedPassword,
                Salt = salt,
                Role = userRegistrationDto.Role
            };

            var existingUser = await _authRepository.UserRegistrationAsync(user);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with this email already exists.");
            }
            return new ApiResponse<bool>
            {
                Status = true,
                Message = "User Registered Successfully",
                Values = true,
                PaginationSummary = null
            };
        }


        private async Task<(string hashedPassword, string salt)> PasswordHashing(string plainPassword)
        {
            string salt = await CreateSalt(16);

            string hashedPassword = await Task.Run(() =>
            {
                using (SHA256 sHA256 = SHA256.Create())
                {
                    string saltedInput = plainPassword + salt;
                    byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(saltedInput));
                    return Convert.ToBase64String(bytes);
                }
            });

            return (hashedPassword, salt);
        }

        private async Task<string> CreateSalt(int size)
        {
            return await Task.Run(() =>
            {
                byte[] saltBytes = new byte[size];
                RandomNumberGenerator.Fill(saltBytes);
                return Convert.ToBase64String(saltBytes);
            });
        }


        private LoginResponse MapUserToLoginResponse(User user, string token = "")
        {
            return new LoginResponse
            {
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString(),
                Token = token
            };
        }

        public async Task<ApiResponse<LoginResponse?>> UserLoginAsync(LoginRequestDto loginRequestDto)
        {
            var user = await _authRepository.UserLoginAsync(loginRequestDto.Email);

            if (user == null)
            {
                return new ApiResponse<LoginResponse?>
                {
                    Status = false,
                    Message = "Invalid email or password.",
                    Values = null,
                    PaginationSummary = null
                };
            }

            bool isPasswordValid = await VerifyHashedPassword(loginRequestDto.Password, user.Password, user.Salt);
            if (!isPasswordValid)
            {
                return new ApiResponse<LoginResponse?>
                {
                    Status = false,
                    Message = "Invalid email or password.",
                    Values = null,
                    PaginationSummary = null
                };
            }
            string token = GenerateJwtToken(user);
            user.Token = token;
            await _authRepository.UpdateUserTokenAsync(user.Id, token);
            var loginResponse = MapUserToLoginResponse(user, token);
            return new ApiResponse<LoginResponse?>
            {
                Status = true,
                Message = "Login successful.",
                Values = loginResponse,
                PaginationSummary = null
            };
        }

        public async Task<bool> VerifyHashedPassword(string inputPassword, string storedHashedPassword, string storeSaltValue)
        {
            return await Task.Run(() =>
            {
                using (SHA256 sHA256 = SHA256.Create())
                {
                    string saltedInput = inputPassword + storeSaltValue;
                    byte[] inputHashBytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(saltedInput));
                    string inputHashedPassword = Convert.ToBase64String(inputHashBytes);

                    return inputHashedPassword == storedHashedPassword;
                }
            });
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expires = DateTime.UtcNow.AddHours(1);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
