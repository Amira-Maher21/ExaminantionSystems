using AutoMapper;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.Helpers;
using ExaminantionSystem.Services.user;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
 
namespace ExaminationSystem.Services.user
{
    public class RoleService : IRoleeServices
    {
        private readonly IRepository<AuthorizeRole> _roleRepository;
        private readonly ILogger<RoleService> _logger;
        private readonly IMapper _mapper;

        

        public RoleService(IRepository<AuthorizeRole> roleRepository, ILogger<RoleService> logger, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _logger = logger;
        }





        public ResultViewModel<bool> CreateRolee(AddauthorizeRoleDto addauthorizeRoleDto)
        {
            try
            {
                // تحقق إن الاسم مش مكرر
                if (_roleRepository.GetAll().Any(r => r.Name == addauthorizeRoleDto.RoleName))
                {
                    return new ResultViewModel<bool>
                    {
                        IsSuccess = false,
                        Message = "Role name already exists.",
                        Data = false
                    };
                }

                var roleEntity = _mapper.Map<AuthorizeRole>(addauthorizeRoleDto);
                _roleRepository.Add(roleEntity);
                _roleRepository.SaveChanges();

                return new ResultViewModel<bool>
                {
                    IsSuccess = true,
                    Message = "Role created successfully.",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                // ممكن تسجلي الخطأ هنا
                _logger.LogError(ex, "Error while creating role");

                return new ResultViewModel<bool>
                {
                    IsSuccess = false,
                    Message = "An error occurred while creating the role.",
                    Data = false
                };
            }
        }

    }

}



 





