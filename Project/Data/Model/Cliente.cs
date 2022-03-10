using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Project.Data.Model;

namespace Project.Data.Model
{
    public class Cliente
    {
        public int id_cli { get; set; }
        public string nom_cli { get; set; }
        public string apell_cli { get; set; }
        public string tel_cli { get; set; }
        public string email_cli { get; set; }
        public string dir_cli { get; set; }
    }
}
