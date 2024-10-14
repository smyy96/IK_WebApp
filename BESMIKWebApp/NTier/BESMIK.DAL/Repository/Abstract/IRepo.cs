using BESMIK.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Repository.Abstract
{
    public interface IRepo<TEntity> where TEntity : BaseEntity
    { 
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        //List<TEntity> GetAll();
        TEntity? Get(int id);
    }
}
