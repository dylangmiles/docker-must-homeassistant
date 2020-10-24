using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Models
{
    public class Pv1800
    {
        public Pc1800Module Charger {get; set;}
        public Ph1800Module Inverter {get; set;}
    }
}
