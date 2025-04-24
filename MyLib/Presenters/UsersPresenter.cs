using MyLib.Models;
using MyLib.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Presenters
{
    public class UsersPresenter
    {
        private IUsersModel model_;
        private IUsersView view_;
        private IUserCard card_;

        public UsersPresenter(IUsersModel model, IUsersView view, IUserCard card)
        {
            model_ = model;
            view_ = view;
            card_ = card;
            model_.SuccessLoadedInfoUsers += Model_SuccessLoadedInfoUsers;
            model_.LoadInfoUsers();
            card_.UserChange += Card_UserChange;
        }

        private void Card_UserChange(User obj)
        {
            Model_ChangedUser(obj);
        }

        public void View__FiltrEvent(string FiltrOrder, string input)
        {

            model_.FiltrUserData(FiltrOrder, input);
        }

        public void Model__RefreshLoadedInfoUsers()
        {
            view_.Show(model_.ReturnUsers());
        }

        private void Model_SuccessLoadedInfoUsers()
        {
            view_.Show(model_.GetUsers());
        }

        public void View__SelectedUser(int number)
        {
            if (number < 0 || number >= model_.GetUsers().Count)
            {
                return;
            }
            User u = model_.GetUsers()[number];
            card_.Show(u);
        }

        private void Model_ChangedUser(User u)
        {
            model_.ChangeUser(u);
        }

        public void Model__DeleteUser()
        {
            int delIndex = view_.GetSelectedUserIndex();
            if (delIndex < 0 || delIndex >= model_.GetUsers().Count)
            {
                return;
            }
            User u = model_.GetUsers()[delIndex];
            model_.DeleteUser(u.Id);
        }
    }
}
