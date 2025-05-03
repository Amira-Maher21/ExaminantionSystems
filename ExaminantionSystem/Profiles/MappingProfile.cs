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
            CreateMap<LoginUserDto, User>()
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.UsersID))
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.AuthorizeRolesID));
            // .ForAllOtherMembers(opts => opts.Ignore());


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
