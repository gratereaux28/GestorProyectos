using System.Collections.Generic;

namespace GestorProyectos.Base.Output
{
    public class DataTables<T>
    {
        public IEnumerable<T> data { get; set; }
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public string Error { get; set; }
    }
}