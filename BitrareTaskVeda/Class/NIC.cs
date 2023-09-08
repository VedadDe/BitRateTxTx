using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrareTaskVeda.Class
{
    public class NIC
    {
        public string Description { get; set; }
        public string MAC { get; set; }
        public DateTime Timestamp { get; set; }
        public string Rx { get; set; }
        public string Tx { get; set; }
    }
}