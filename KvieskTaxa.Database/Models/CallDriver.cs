using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvieskTaxa.Database.Models
{
    public class CallDriver
    {
        public IEnumerable<KvieskTaxa.Database.Models.Call> Calls { get; set; }
        public IEnumerable<KvieskTaxa.Database.Models.Driver> Drivers { get; set; }
    }
}
