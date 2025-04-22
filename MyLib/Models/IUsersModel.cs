using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Models
{
    class IUsersModel
    {
        void LoadInfoUsers();
        List<User> ReturnUsers();
        List<User> GetUsers();


        event Action SuccessLoadedInfoUsers;
    }
}
