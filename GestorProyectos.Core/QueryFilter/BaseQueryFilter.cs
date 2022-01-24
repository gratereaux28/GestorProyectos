using GestorProyectos.Base.Attributes;

namespace GestorProyectos.Core.QueryFilter
{
    public abstract class BaseQueryFilter
    {
        public int PageSize { get; set; }

        [IgnoreToQueryAttribute]
        public int PageNumber { get; set; }

        [IgnoreToQueryAttribute]
        public int Size { get { if (PageSize > 0) return PageSize; PageSize = 20;  return PageSize; } }

        [IgnoreToQueryAttribute]
        public int Number { get { if (PageNumber > 0) return PageNumber; PageNumber =  1;  return PageNumber; } }
    }
}