using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProyectos.Base.Attributes
{
    public class GetAttribute : Attribute
    {
    }

    public class CreateAttribute : Attribute
    {
    }

    public class ReadAttribute : Attribute
    {
    }

    public class UpdateAttribute : Attribute
    {
    }

    public class ReportAttribute : Attribute
    {
    }

    public class DeleteAttribute : Attribute
    {
    }

    public class EditAttribute : Attribute
    {
    }

    public class AddAttribute : Attribute
    {
    }

    public class NotComparableAttribute : Attribute
    {
    }

    public class ComparableAttribute : Attribute
    {
        public string Field;
        public ComparableAttribute(string _field)
        {
            Field = _field;
        }
    }
}