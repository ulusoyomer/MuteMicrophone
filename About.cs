using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuteMicrophone
{
    public partial class About : Form
    {
        Mainform _mainForm;
        public About(Mainform mainform)
        {
            InitializeComponent();
            _mainForm = mainform;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Hide();
            _mainForm.OpenAll();
        }
    }
}
