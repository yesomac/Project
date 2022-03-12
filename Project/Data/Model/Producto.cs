using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data.Model
{
    public class Producto
    {
        public int id_pro { get; set; }
        public int prec_pro { get; set; }
        public string disp_pro { get; set; }
        public string prov_pro { get; set; }
        public int cant_pro { get; set; }
        public string nom_pro { get; set; }
        public string gar_pro { get; set; }
        public string desc_pro { get; set; }
    }
}
