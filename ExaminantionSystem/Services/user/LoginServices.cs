using AutoMapper;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.Helpers;
using ExaminantionSystem.Services.user;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminantionSystem.Services.user
{
    public class LoginServices : ILoginUserServices
    {
        
        IRepository<User> repository;
        ILoginUserServices loginUserServices;
        private readonly IMapper _mapper;


        public LoginServices(IRepository<User> repository,
           ILoginUserServices loginUserServices, IMapper mapper)
        {
            this.repository = repository;
            this.loginUserServices = loginUserServices;
            this._mapper = mapper;

        }


        public void AddUser(LoginUserDto loginUserDto)
        {
            var LoginUsers = _mapper.MapOne<User>();
            var LoginUser = repository.Add(LoginUsers);
            repository.SaveChanges();


        }

    }
}
