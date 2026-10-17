using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Domain
{
    public abstract class Record
    {

        public int Id {  get; set; }

        protected Record(int id) {
            Id = id;
        }

        protected Record()
        {
        }
    }
}
