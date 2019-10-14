using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSwithEventSourcingLib 
{
    public class Declaration_ChangeTitleEvent : Event
    {
        public string Id { get; set; }
        public string OldTitle { get; set; }
        public string NewTitle { get; set; }
    }
}
