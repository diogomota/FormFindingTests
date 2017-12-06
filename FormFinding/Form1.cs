using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RobotOM;

namespace FormFinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Robot_call.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
