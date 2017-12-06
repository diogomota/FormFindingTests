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
            //set default material S235
            robApp.Project.Preferences.Materials.SetDefault(IRobotMaterialType.I_MT_STEEL, "S 275");

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
    }
}
