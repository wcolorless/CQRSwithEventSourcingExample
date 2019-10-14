using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyDI;

namespace CQRSwithEventSourcingLib
{
    public class DeclarationRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private List<TEntity> enities = new List<TEntity>();
        
        
        public async Task<TEntity> Get(string Id)
        {
            return await Task.Run<TEntity>(() => {
                return enities.Find(x => x.Id == Id);
            });
        }

        public async Task SaveChanges()
        {
            await Task.CompletedTask;
        }

        public async Task Set(TEntity entity)
        {
            await Task.Run(() => {
                enities.Add(entity);
            });
        }

    }
}
