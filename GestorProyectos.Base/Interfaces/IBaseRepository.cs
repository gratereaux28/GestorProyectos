using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestorProyectos.Base.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        DbSet<T> DbSet();
        IQueryable<T> GetFromJsonQuery(string json, Expression<Func<T, bool>> query);
        IEnumerable<T> GetData(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderBy = null, int maximumRows = 0, int startRowIndex = 0);
        IEnumerable<T> Get(Expression<Func<T, bool>> query, string orderByString = null, Expression<Func<T, object>> orderBy = null, int maximumRows = 0, int startRowIndex = 0, string json_filter = "");
        IEnumerable<T> Get(Expression<Func<T, bool>> query, Expression<Func<T, object>> groupBy, string orderByString = null, Expression<Func<T, object>> orderBy = null, int maximumRows = 0, int startRowIndex = 0, string json_filter = "");
        IEnumerable<T> GetByFilter(string text);
        IEnumerable<T> GetFromJson(string json);
        IQueryable<T> GetFromJsonQuery(string json);
        T GetFirst(Expression<Func<T, bool>> query);
        IEnumerable<T> ListAll();
        int Count();
        int Count(Expression<Func<T, bool>> query, string json_filter = "");
        int Count(Expression<Func<T, bool>> query, Expression<Func<T, object>> GroupBy, string json_filter = "");
        IBaseRepository<T> AddInclude(string includeString);
        IBaseRepository<T> AddInclude(Expression<Func<T, object>> includeExpression);
        T Add(T entity);
        T AddNoSave(T entity);
        void Create(T entity);
        void Update(T entity);
        void UpdateNoSave(T entity);
        void Delete(T entity);
        void DeleteNoSave(T entity);
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void SaveChanges();
        bool IsActiveTransaction();

        //Async

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderBy = null, bool isDesc = false, int maximumRows = 0, int startRowIndex = 0);
        IQueryable<T> GetQAsync(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderBy = null, bool isDesc = false, int maximumRows = 0, int startRowIndex = 0);
        IQueryable<T> GetQAsync(List<Expression> query = null, Expression<Func<T, object>> orderBy = null, bool isDesc = false, int maximumRows = 0, int startRowIndex = 0);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> query);
    }
}