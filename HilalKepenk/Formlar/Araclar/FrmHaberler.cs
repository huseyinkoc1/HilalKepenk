using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HilalKepenk.Formlar.Araclar
{
    public partial class FrmHaberler : Form
    {

   

        public FrmHaberler()
        {
            InitializeComponent();
        }
        
        private void FrmHaberler_Load(object sender, EventArgs e)
        {
            webBrowser2.Navigate("https://www.haber7.com/");
        }

   
    }
}
