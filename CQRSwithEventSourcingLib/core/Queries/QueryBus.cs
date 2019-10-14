using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyDI;

namespace CQRSwithEventSourcingLib
{
    public class QueryBus : IQueryBus
    {

        TinyDependencyInjection tinyDI;

        public QueryBus(TinyDependencyInjection tinyDI)
        {
            this.tinyDI = tinyDI;
        }

        public async Task<TResponse> GetAsync<TQuery, TResponse>(TQuery query) where TQuery : IQuery
        {
            return await  tinyDI.GetAsync<TQuery, TResponse>(query);
        }
    }
}
