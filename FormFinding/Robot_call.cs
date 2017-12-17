using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotOM;
namespace FormFinding
{
    static class Robot_call
    {
        static IRobotApplication robApp;

        static IRobotNodeDisplacementServer displacement_results;

        static Robot_call()
        {
            
            if (robApp == null)
            {
                robApp = new RobotApplication();

                robApp.Project.New(IRobotProjectType.I_PT_SHELL);
                if (robApp.Visible == 0) { robApp.Interactive = 1; robApp.Visible = 1; }
               
            }

        }
        public static void Start()
        {
            // define section Db
            robApp.Project.Preferences.SetCurrentDatabase(IRobotDatabaseType.I_DT_SECTIONS, "DIN");
            //define materials Db
            robApp.Project.Preferences.Materials.Load("Eurocode");
            //set default material S355
            robApp.Project.Preferences.Materials.SetDefault(IRobotMaterialType.I_MT_STEEL, "S 355");

        }
        public static void Robot_interactive(bool a)
        {
            if (a)
            {
                robApp.Interactive = 1;
            }
            else
            {
                robApp.Interactive = 0;
            }
        }

        public static void Get_nodes(Model mdl)
        {
            int w = 0;
            for (int i = mdl.init_node; i <= mdl.last_node; i++)
            {
                IRobotNode temp = (IRobotNode)robApp.Project.Structure.Nodes.Get(i);
                Console.Write(temp.Z);
                mdl.z[w] = (float)temp.Z;
                w++;
            }
        }

        public static void Refresh()
        {
            robApp.Project.ViewMngr.Refresh();
        }

        public static void Run_Analysis(bool First_calc, Model mdl)
        {
            int w = 0;
            if (First_calc)
            {
                double temp;
                robApp.Project.CalcEngine.Calculate();
                displacement_results = robApp.Project.Structure.Results.Nodes.Displacements;

                for (int i = mdl.init_node; i <= mdl.last_node; i++) {
                    mdl.disp_z_cloth[w] = (float)displacement_results.Value(i, 1).UZ;
                    mdl.disp_x_cloth[w] = (float)displacement_results.Value(i, 1).UX;
                    mdl.disp_y_cloth[w] = (float)displacement_results.Value(i, 1).UY;
                    temp = displacement_results.Value(i, 1).UZ; //em metros 
                    w++;
                    }
            }
            else
            {


            }
            
        }

        public static void Update_nodes(float[] x, float[] y,float[] z,Model mdl)
        {
            for(int i = 0; i < mdl.z.Length; i++)
            {
                IRobotNode node = (IRobotNode)robApp.Project.Structure.Nodes.Get(mdl.init_node + i);
                node.X += mdl.disp_x_cloth[i]*-1; //update z coordinate after first cloth run
                node.Y += mdl.disp_y_cloth[i] * -1; //update z coordinate after first cloth run
                node.Z += mdl.disp_z_cloth[i] * -1; //update z coordinate after first cloth run
            }
            Robot_call.Refresh();
        }

    }
}
