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

        private void Model__RefreshLoadedInfoUsers()
        {
            view_.Show(model_.ReturnUsers());
        }

        private void Model_SuccessLoadedInfoUsers()
        {
            view_.Show(model_.GetUsers());
        }

        private void Model_ChangedUser(User u)
        {

        }
    }
}
