using AutoMapper;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.Helpers;
using ExaminantionSystem.ViewModels;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExaminantionSystem.Services.instructor
{
    public class InstructorService : IinstructorService
    {
        private readonly IRepository<Instructor> _repository;
        private readonly IMapper _mapper;

        public InstructorService(
            IRepository<Instructor> repository
             , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
 
        }
        public IEnumerable<InstructorDto> GetAllInstructors()
        {
            var instructors = _repository.GetAll();

            //Method Group
            return instructors.Select(_mapper.Map<InstructorDto>);

            // Lambda
            //return instructors.Select(i => _mapper.Map<InstructorDto>(i));
        }



        public void AddInstructor(InstructorDto instructorDto)
        {
            var instructor = _mapper.Map<Instructor>(instructorDto);

            // تأكد من تعيين UserId
           // if (!_repositoryy.GetAll().Any(u => u.ID == instructor.ID))

            _repository.Add(instructor);
            _repository.SaveChanges();
        }



        public void UpdateInstructor(InstructorDto updatedInstructorDto)
        {
             var existingInstructor = _repository.GetByID(updatedInstructorDto.InstructorId);
            if (existingInstructor == null)
            {
                throw new ArgumentException($"Instructor with ID {updatedInstructorDto.InstructorId} does not exist.");
            }

             _mapper.Map(updatedInstructorDto, existingInstructor);

             _repository.Update(existingInstructor);
            _repository.SaveChanges();
        }









        public void DeleteInstructor(int instructorId)
        {
            var instructor = _repository.GetByID(instructorId);
            if (instructor == null)
            {
                throw new ArgumentException($"Instructor with ID {instructorId} does not exist.");
            }

            _repository.Delete(instructor);
            _repository.SaveChanges();
        }



    }
}
