using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFinding
{
    public class Model
    {
        public int init_node;
        public int last_node;
        public float[] z;
        public float[] disp_z_cloth;
        public float[] disp_x_cloth;
        public float[] disp_y_cloth;

        public Model(int init, int last){
            init_node = init;
            last_node = last;
            z = new float[last - init + 1];
            disp_z_cloth= new float[last-init+1];
            disp_x_cloth = new float[last - init + 1];
            disp_y_cloth = new float[last - init + 1];
        }
        public void get_geom() {
            Robot_call.Get_nodes(this);
        }

    }
}
