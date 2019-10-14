using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyDI;

namespace CQRSwithEventSourcingLib
{
    public interface IQueryBus
    {
        Task<TResponse> GetAsync<TQuery, TResponse>(TQuery query) where TQuery : IQuery;
    }
}
