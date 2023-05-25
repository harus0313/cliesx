using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;

namespace cliesx
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            ShowWindow();
        }


        void ShowWindow()
        {
            cliesx form1 = new cliesx();
            /*
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = form1.Width;
            int formHeight = form1.Height;

            form1.Location = new System.Drawing.Point(screenWidth - formWidth, screenHeight - formHeight);
            */
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
        }

    }
}
