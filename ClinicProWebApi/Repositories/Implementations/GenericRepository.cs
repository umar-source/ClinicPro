using ClinicProWebApi.DAL;
using ClinicProWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicProWebApi.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ClinicProContext _dbContext;
        private readonly DbSet<T> _entitiySet;

        public GenericRepository(ClinicProContext dbContext)
        {
            _dbContext = dbContext;
            _entitiySet = _dbContext.Set<T>();
        }

        public void Add(T item)
        {
            _entitiySet.Add(item);
        }

        public IEnumerable<T> All(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _entitiySet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void Delete(T item)
        {
            _entitiySet.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _entitiySet.AsNoTracking().AsEnumerable();
        }

        public T GetById(int id)
        {
            T item = _entitiySet.Find(id);

            if (item == null)
            {

                throw new InvalidOperationException($"Entity of type {typeof(T).Name} with ID {id} not found in database.");

            }

            return item;
        }


        public T GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            _entitiySet.Update(item);
            // We are not doing save changes at repo level becaus ewe do single save transaction
            //at unitofwork if we do save changes here there unit of work savechanges have no meaning to use 
            //and if we want to implement rollback it will not
            //_dbContext.SaveChanges();
        }
    }
}
