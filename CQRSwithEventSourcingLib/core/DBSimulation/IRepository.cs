using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQRSwithEventSourcingLib
{
    public interface IRepository<TEntity>
    {
        Task Set(TEntity entity);
        Task<TEntity> Get(string Id);
        Task SaveChanges();
    }
}
