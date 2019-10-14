using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyDI;

namespace CQRSwithEventSourcingLib 
{
    public class Declaration_QueryHandler :  IQueryHandler<Declaration_GetQuery, Declaration>
    {
        private IRepository<Declaration> repository;


        public Declaration_QueryHandler(IRepository<Declaration> repository)
        {
            this.repository = repository;
        }


        public async Task<Declaration> Handle(Declaration_GetQuery request)
        {
            return await repository.Get(request.Id);
        }




        public async Task GoHandle(ICommand command)
        {
           await  ((dynamic)this).Handle((dynamic)command);
        }
    }
}
