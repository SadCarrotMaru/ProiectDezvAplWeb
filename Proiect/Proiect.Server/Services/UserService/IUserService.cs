
using Proiect.Data.DTOs;
using Proiect.Models;
using Proiect.Models.Enums;

namespace Proiect.Services.UserService
{
    public interface IUserService
    {
        Task<UserLoginResponse> Login(UserLoginDto user);
        User GetById(Guid id);

        Task<bool> Register(UserRegisterDto userRegisterDto, Role userRole);
    }
}
