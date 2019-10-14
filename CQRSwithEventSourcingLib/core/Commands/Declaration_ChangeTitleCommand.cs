using System;
using System.Collections.Generic;
using System.Text;
using TinyDI;

namespace CQRSwithEventSourcingLib
{
    public class Declaration_ChangeTitleCommand : ICommand
    {
        public string Id { get; set; }
        public string OldTitle { get; set; }
        public string NewTitle { get; set; }
    }
}
