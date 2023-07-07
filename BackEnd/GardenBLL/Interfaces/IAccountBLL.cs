using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden.BLL.Interfaces
{
    public interface IAccountBLL
    {
        public string Login(int id, string password);

    }
}
