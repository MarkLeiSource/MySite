using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataFX.Entities
{
    public class BlogContent : MyEntity
    {
        public int ID { get; set; }
        public string Content { get; set; }
    }
}
