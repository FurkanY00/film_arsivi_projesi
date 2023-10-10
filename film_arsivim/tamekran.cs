using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace film_arsivim
{
    public partial class tamekran : Form
    {
        public tamekran()
        {
            InitializeComponent();
        }
        public string link;

        private void tamekran_Load(object sender, EventArgs e)
        {
            
            webBrowser1.Navigate(link);
           
        }
    }
}
