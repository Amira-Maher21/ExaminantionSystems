using AutoMapper;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.Helpers;
using ExaminantionSystem.Services.user;
using ExaminationSystem.Exceptions;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExaminantionSystem.Services.user
{
    public class AuthorizeServices : IAuthorizeServices
    {
        
        IRepository<User> repository;
         private readonly IMapper _mapper;
        private readonly IRepository<AuthorizeRole> _roleRepository;


        private readonly IConfiguration _configuration;

        public AuthorizeServices(
            IRepository<User> repository,
             IRepository<AuthorizeRole> roleRepository,
            IMapper mapper,
            IConfiguration configuration)
        {
            this.repository = repository;
            this._roleRepository = roleRepository;
            this._mapper = mapper;
            this._configuration = configuration;
        }




        public ResultViewModel<string> AddUser(RegisterDto registerDto)
        {
            var existingUser = repository.GetAll().FirstOrDefault(u => u.UserName == registerDto.UserName);
            if (existingUser != null)
                return ResultViewModel<string>.Faliure(ErrorCode.Duplicated, "Username already exists");

            if (string.IsNullOrWhiteSpace(registerDto.Name) || string.IsNullOrWhiteSpace(registerDto.Password))
                return ResultViewModel<string>.Faliure(ErrorCode.ValidationError, "Username and password are required");

            var role = _roleRepository.GetAll().FirstOrDefault(r => r.Name.ToLower() == registerDto.Role.ToLower());
            if (role == null)
                return ResultViewModel<string>.Faliure(ErrorCode.NotFound, "Role not found");

            var user = new User
            {
                Name = registerDto.Name,
                UserName = registerDto.UserName,
                AuthorizeRoleID = role.ID
            };

            // ✅ استخدمي Identity PasswordHasher
            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, registerDto.Password);

            repository.Add(user);
            repository.SaveChanges();

            return ResultViewModel<string>.Sucess("User registered successfully");
        }

        public ResultViewModel<string> Login(LoginUserDto loginUserDto)
        {
            var user = repository.GetAll()
                                 .Include(u => u.AuthorizeRole)
                                 .FirstOrDefault(u => u.UserName == loginUserDto.UserName);

            if (user == null)
                return ResultViewModel<string>.Faliure(ErrorCode.NotFound, "User not found");

            var passwordHasher = new PasswordHasher<object>();
            var verificationResult = passwordHasher.VerifyHashedPassword(null, user.Password, loginUserDto.Password);

            if (verificationResult != PasswordVerificationResult.Success)
                return ResultViewModel<string>.Faliure(ErrorCode.ValidationError, "Invalid password");

            // تحويل الـ User إلى TokenDto باستخدام AutoMapper
            var tokenDto = MapperHelper.Mapper.Map<TokenDto>(user);

            // توليد JWT باستخدام TokenDto والاعدادات
            var jwt = TokenGenerator.GenerateToken(tokenDto, _configuration);

            return ResultViewModel<string>.Sucess(jwt, "Login successful");
        }






    }

}
