using ExaminantionSystem.DTOS;
using ExaminationSystem.ViewModels;

namespace ExaminantionSystem.Services.user
{
    public interface IAuthorizeServices
    {
        ResultViewModel<string> Login(LoginUserDto loginUserDto);
        ResultViewModel<string> AddUser(RegisterDto registerDto);
    }
}
