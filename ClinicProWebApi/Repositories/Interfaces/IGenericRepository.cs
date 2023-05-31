using System.Linq.Expressions;

namespace ClinicProWebApi.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        IEnumerable<T> All(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = ""
            );

        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
