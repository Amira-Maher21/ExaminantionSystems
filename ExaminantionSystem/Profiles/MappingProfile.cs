using AutoMapper;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.ViewModels;
using ExaminationSystem.Models;

namespace ExaminantionSystem.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
 
                // خريطة من User إلى TokenDto
                CreateMap<User, TokenDto>()
                    .ForMember(dest => dest.UsersID, opt => opt.MapFrom(src => src.ID))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.AuthorizeRoleName, opt => opt.MapFrom(src => src.AuthorizeRole.Name));

                // خريطة LoginUserDto إلى User (إذا تحتاجها في مكان آخر)
                CreateMap<LoginUserDto, User>()
                    .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.UsersID))
                    .ForMember(dest => dest.AuthorizeRoleID, opt => opt.MapFrom(src => src.AuthorizeRolesID))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<AddauthorizeRoleDto, AuthorizeRole>()
                              .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.AuthorizeRoleID))
                             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RoleName));


            CreateMap<AssignFeaturesToRoleDto, RoleFeature>()
           .ForMember(dest => dest.AuthorizeRoleID, opt => opt.MapFrom(src => src.RoleId))
           .ForMember(dest => dest.feature, opt => opt.MapFrom(src => src.FeatureIds))
           .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.RoleId));
 

            //CreateMap<LoginUserDto, User>()
            //           .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.UsersID))
            //           .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.AuthorizeRolesID));
            //        // .ForAllOtherMembers(opts => opts.Ignore());


            CreateMap<InstructorDto,Instructor>().ReverseMap()
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.ID));

            CreateMap<InstructorViewModel, InstructorDto>().ReverseMap();
                
            CreateMap<CourseDto, Course>()
               //.ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.CourseId))
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.InstructorId));

            CreateMap<ExamDto, Exam>().ReverseMap()
               .ForMember(dest => dest.ExamId, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.ID));
             CreateMap<ExamDto, ExamViewModel>().ReverseMap()
               .ForMember(dest => dest.ExamId, opt => opt.MapFrom(src => src.ExamId))
             .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.InstructorId))
               .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId));
            CreateMap<QuestionDto, Question>()
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.QuestionId));
             
            CreateMap<ChoiceDto, Choice>()
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ChoiceId))
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.QuestionID));
            
            
        }
    }
}
