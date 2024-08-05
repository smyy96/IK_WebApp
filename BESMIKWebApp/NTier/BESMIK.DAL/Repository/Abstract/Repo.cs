using BESMIK.DAL.Context;
using BESMIK.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Repository.Abstract
{
    public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : BaseEntity
    {
        protected BesmikDbContext _dbContext;
        protected Repo(BesmikDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution; //sc
        }

        public int Add(TEntity entity)
        {
            entity.Created = DateTime.Now;

            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public virtual TEntity? Get(int id)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().SingleOrDefault(e => e.Id == id); //sc
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public int Update(TEntity entity)
        {
            entity.Updated = DateTime.Now;

            _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
