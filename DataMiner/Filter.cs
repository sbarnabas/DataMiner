using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataMiner
{
    public class Filter
    {
        [DisplayName("Filtered Field")]
        public string FieldName { get; set; }
        [Browsable(false)]
        public string ReflectionName { get; set; }
        [Browsable(false)]
        public Func<object, bool> Apply
        {
            get; set;
        }
        [DisplayName("Filter Description")]
        public string Description { get; set; }
    }
}
