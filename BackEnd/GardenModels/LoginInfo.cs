using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden.Models
{
    public class LoginInfo
    {
        public int LoginInfoId { get; set; }    
        public int Account_id { get; set; }
        public DateTime LoginTime { get; set; }
        public string LoginLocation { get; set; }   
    }
}
