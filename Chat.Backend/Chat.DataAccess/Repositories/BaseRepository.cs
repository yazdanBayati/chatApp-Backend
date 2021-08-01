using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Chat.Core.Domains;
using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        public BaseRepository(ChatDbContext dbbContext)
        {
            Context = dbbContext;
            DbSet = Context.Set<T>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public virtual int Add(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }

            return Context.SaveChanges();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                await DbSet.AddAsync(entity);
            }

            return await Context.SaveChangesAsync();
        }

        public virtual int Delete(T entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);

            return Context.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            DbSet.Remove(entity);

            return await Context.SaveChangesAsync();
        }

        public virtual void Detach(T entity)
        {
            var entry = Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public virtual T Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}