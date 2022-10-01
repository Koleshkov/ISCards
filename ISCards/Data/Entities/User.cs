using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCards.Data.Entities
{
    public class User : Base
    {
        public string UserName { get; set; }
        public string Position { get; set; }
        public string Organization { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
