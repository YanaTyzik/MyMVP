using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Models
{
     public class MemoryUsersModel : IUsersModel
     {
        private List<User> _users = new List<User>();
        private List<User> FiltrUser = new List<User>();
        public event Action SuccessLoadedInfoUsers;

        public List<User> GetUsers()
        {
            return FiltrUser;
        }

        public void LoadInfoUsers()
        {
            _users.Add(new User { Password = "222", Name = "Гоша", Surname = "Тазиков", DateBirth = new DateTime(2006, 02, 19) });
            _users.Add(new User { Password = "111", Name = "Валера", Surname = "Тузик", DateBirth = new DateTime(2006, 02, 18) });

            FiltrUser = _users;

            SuccessLoadedInfoUsers.Invoke();
        }

        public void FiltrUserData(string NameFiltr, string input)
        {
            if (input == "Имя")
            {
                FiltrUser = _users.Where(p => p.Name.Contains(NameFiltr)).ToList();
                SuccessLoadedInfoUsers.Invoke();
            }
        }

        public List<User> ReturnUsers()
        {
            FiltrUser = _users;
            return FiltrUser;
        }

        public void ChangeUser(User u)
        {
            foreach (User current in _users)
            {
                if(current.Id == u.Id)
                {
                    current.Name = u.Name;
                    current.Surname = u.Surname;
                    SuccessLoadedInfoUsers.Invoke();
                }
            }

            foreach (User current in FiltrUser)
            {
                if (current.Id == u.Id)
                {
                    current.Name = u.Name;
                    current.Surname = u.Surname;
                    SuccessLoadedInfoUsers.Invoke();
                }
            }
        }

        public void DeleteUser(int del)
        {
            User delete = FiltrUser.FirstOrDefault(u => u.Id == del);
            if (delete != null)
            {
                _users.Remove(delete); 
                FiltrUser.Remove(delete);
                SuccessLoadedInfoUsers.Invoke();
            }
        }
     }
}
