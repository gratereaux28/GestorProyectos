using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProyectos.Base.Output
{
    public class ExportViewModel
    {
        public string[] columnsName { get; set; }
        public string[] columnsDescription { get; set; }
        public string json_filter { get; set; }
    }
}
