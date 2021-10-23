using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HilalKepenk.Formlar
{
    public partial class FrmPrint : Form
    {
        public FrmPrint()
        {
            InitializeComponent();
        }

        private void FrmPrint_Load(object sender, EventArgs e)
        {
            
            
        }

        public void initPdf(Raporlar.XtraReport1 xtra, string name)
        {
            documentViewer1.DocumentSource = xtra;
            xtra.Name = name;
            xtra.CreateDocument();
        }
        public void initPdf2(Raporlar.XtraReport2 xtra, string name)
        {
            documentViewer1.DocumentSource = xtra;
            xtra.Name = name;
            xtra.CreateDocument();
        }

    }
}
