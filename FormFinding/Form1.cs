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
        public Model mdl;
        public Form1()
        {
            InitializeComponent();
            Robot_call.Start();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            mdl = new Model((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            mdl.get_geom();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Robot_call.Run_Analysis(true, mdl);
                Robot_call.Update_nodes(mdl.disp_z_cloth,mdl.disp_y_cloth,mdl.disp_z_cloth, mdl);
                Console.WriteLine(i);
            }
        }
    }
}
