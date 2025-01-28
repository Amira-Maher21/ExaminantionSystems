using ExaminantionSystem.DTOS;

namespace ExaminantionSystem.Services.user
{
    public interface ILoginUserServices
    {
        void AddUser(LoginUserDto loginUserDto);
    }
}
