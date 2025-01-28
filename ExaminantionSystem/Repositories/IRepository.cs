using ExaminantionSystem.DTOS;
using ExaminationSystem.Models;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        T Add(T entity);

        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T GetByID(int id);
        T GetWithTrackinByID(int id);
        void Update(T entity);
        void UpdateIncluded(T entity, params string[] updatedProperties);
        void Delete(T entity);
        void Delete(int id);
        T First(Expression<Func<T, bool>> predicate);

        void SaveChanges();
    }
}
