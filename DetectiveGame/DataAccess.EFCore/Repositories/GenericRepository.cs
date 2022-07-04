using DetectiveGame.Domain.Interfaces;
using DetectiveGame.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace DataAccess.EFCore.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly ApplicationContext _context;
		public GenericRepository(ApplicationContext context)
		{
			_context = context;
		}

		public virtual void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public virtual void AddRange(IEnumerable<T> entities)
		{
			_context.Set<T>().AddRange(entities);
		}

		public virtual void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}

		public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
		{
			return _context.Set<T>().Where(expression);
		}

		public virtual IEnumerable<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}

		public virtual T GetById(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public virtual void Remove(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public virtual void RemoveRange(IEnumerable<T> entities)
		{
			_context.Set<T>().RemoveRange(entities);
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
