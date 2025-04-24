using MyLib.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserCard
{
    public partial class Form1: UserControl, MyLib.Views.IUserCard
    {
        public Form1()
        {
           InitializeComponent();
        }
    }
}
