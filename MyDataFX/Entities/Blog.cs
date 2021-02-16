using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataFX.Entities
{
    public class Blog : MyEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int FirstLevelID { get; set; }
        public int SecondLevelID { get; set; }

    }
}
