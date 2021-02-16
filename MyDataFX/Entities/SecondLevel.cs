using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataFX.Entities
{
    public class SecondLevel
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
    }
}
