using AutoMapper;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.Helpers;
using ExaminantionSystem.Services.user;
using ExaminationSystem.Exceptions;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels;
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
            // 1. التحقق من تكرار اسم المستخدم
            var existingUser = repository.GetAll().FirstOrDefault(u => u.UserName == registerDto.UserName);
            if (existingUser != null)
                return ResultViewModel<string>.Faliure(ErrorCode.Duplicated, "Username already exists");

            if (string.IsNullOrWhiteSpace(registerDto.Name) || string.IsNullOrWhiteSpace(registerDto.Password))
                return ResultViewModel<string>.Faliure(ErrorCode.ValidationError, "Username and password are required");

            // 2. التحقق من صحة البيانات
            if (string.IsNullOrWhiteSpace(registerDto.UserName) || string.IsNullOrWhiteSpace(registerDto.Password))
                return ResultViewModel<string>.Faliure(ErrorCode.ValidationError, "Username and password are required");

            
            // 3. تشفير كلمة المرور
            string hashedPassword = PasswordHasher.Hash(registerDto.Password);

            // 4. جلب الدور
            var role = _roleRepository.GetAll().FirstOrDefault(r => r.Name.ToLower() == registerDto.Role.ToLower());
            if (role == null)
                return ResultViewModel<string>.Faliure(ErrorCode.NotFound, "Role not found");

            // 5. إنشاء المستخدم
            // 5. إنشاء المستخدم
            var user = new User
            {
                Name = registerDto.Name, // ← صحّحي هذا السطر
                UserName = registerDto.UserName,
                Password = hashedPassword,
                AuthorizeRoleID = role.ID
            };


            // 6. حفظ في قاعدة البيانات
            repository.Add(user);
            repository.SaveChanges();

            return ResultViewModel<string>.Sucess("User registered successfully");
        }



        public ResultViewModel<string> Login(LoginUserDto loginUserDto)
        {
            // 1. البحث عن المستخدم بالاسم
            var user = repository.GetAll().FirstOrDefault(u => u.UserName == loginUserDto.UserName );

            if (user == null)
                return ResultViewModel<string>.Faliure(ExaminationSystem.Exceptions.ErrorCode.NotFound, "User not found");

            // 2. مقارنة كلمة السر (يفضل تشفيرها في الخطوات الجاية)
            if (!PasswordHasher.Verify(loginUserDto.Password, user.Password))
                return ResultViewModel<string>.Faliure(ErrorCode.ValidationError, "Invalid password");

            // 3. تجهيز claims
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, user.AuthorizeRole?.Name ?? "User")
    };

            // 4. إنشاء المفتاح السري (يفضل تيجي من appsettings)
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );


            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return ResultViewModel<string>.Sucess(tokenString, "Login successful");
        }

    }
    //  "password": "1999amiraa2@maher",


    //public ResultViewModel<string> Login(LoginUserDto loginUserDto)
    //{
    //    //Validate LoginUserDto


    //    // generate token

    //    var tokenHandler= new JwtSecurityTokenHandler();
    //    throw new NotImplementedException();
    //}
}
