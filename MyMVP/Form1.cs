using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMVP
{
    public partial class Form1 : Form, IUsersView
    {
        private UsersPresenter presenter_;

        public Form1()
        {
            InitializeComponent();
            presenter_ = new UsersPresenter(new MemoryUsersModel(), this);
        }

        public void Show(List<User> users)
        {
            UsersList.DataSource = null;
            UsersList.DataSource = users;
        }

        void NameFiltr_Click(object sender, EventArgs e)
        {
            presenter_.View__FiltrEvent(NameTextBox.Text, ComboBoxFiltr.Text);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            presenter_.Model__RefreshLoadedInfoUsers();
        }
    }
}
