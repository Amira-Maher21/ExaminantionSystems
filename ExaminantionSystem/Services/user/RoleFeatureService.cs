using ExaminantionSystem.DTOS;
using ExaminantionSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminantionSystem.Services.user
{
   public class RoleFeatureService : IRoleFeatureService
   {
            private readonly IRepository<RoleFeature> _roleFeatureRepository;

            public RoleFeatureService(IRepository<RoleFeature> roleFeatureRepository)
            {
                _roleFeatureRepository = roleFeatureRepository;
            }

            public void AssignFeaturesToRole(AssignFeaturesToRoleDto dto)
            {
                // 1. حذف كل المميزات السابقة المرتبطة بالدور
                var existing = _roleFeatureRepository
                    .GetAll()
                    .Where(rf => rf.AuthorizeRoleID == dto.RoleId)
                    .ToList();

                foreach (var rf in existing)
                {
                    _roleFeatureRepository.Delete(rf);
                }

                // 2. إضافة الميزات الجديدة
                var roleFeatures = dto.FeatureIds.Select(f => new RoleFeature
                {
                    AuthorizeRoleID = dto.RoleId,
                    feature = f
                });

                foreach (var rf in roleFeatures)
                {
                    _roleFeatureRepository.Add(rf);
                }

                _roleFeatureRepository.SaveChanges();
            }

   }     
}

