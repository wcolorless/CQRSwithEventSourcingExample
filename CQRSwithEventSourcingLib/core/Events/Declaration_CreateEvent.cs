﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSwithEventSourcingLib 
{
    public class Declaration_CreateEvent : Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
