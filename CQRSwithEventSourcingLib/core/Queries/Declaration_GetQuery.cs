using System;
using System.Collections.Generic;
using System.Text;
using TinyDI;

namespace CQRSwithEventSourcingLib
{
    public class Declaration_GetQuery : IQuery
    {
        public string Id { get; set; }
    }
}
