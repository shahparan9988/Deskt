using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racssoft_Dokan.Pages
{
    public partial class Sales : Form
    {
        double sizeLabel;
        double areaTest;
        public Sales()
        {
            InitializeComponent();
            double widthTest = tableLayoutPanel1.Width;
            double heightTest = tableLayoutPanel1.Height;
            areaTest = widthTest * heightTest;

            sizeLabel = labelNewSupplier.Font.Size;
            //materialTextBoxName.Font = new Mate();
            //ratio = areaTest / sizeLabel;
        }

        private void tableLayoutPanelTest_Resize(object sender, EventArgs e)
        {
            responsive();
        }

        public void responsive()
        {
            double widthTest = tableLayoutPanel1.Width;
            double heightTest = tableLayoutPanel1.Height;
            double newAreaTest = widthTest * heightTest;
            double newSizeFont = sizeLabel * newAreaTest / areaTest;
            double ratio = newSizeFont / sizeLabel;
            float newSize = (float)(labelNewSupplier.Font.Size * ratio* 01);
            double a = 2;

            

            labelNewSupplier.Font = new Font(labelNewSupplier.Font.FontFamily, (float)(newSizeFont));
            



        }

        private void Sales_Resize(object sender, EventArgs e)
        {
            responsive();
        }

        private void labelNewSupplier_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }
    }
}
