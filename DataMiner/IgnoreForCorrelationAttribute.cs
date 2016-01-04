using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiner
{
    public class IgnoreForCorrelationAttribute:Attribute
    {
        public bool Ignore;
        public IgnoreForCorrelationAttribute(bool ignore)
        {
            Ignore = ignore;
        }
    }
}
