using GestorProyectos.Extensions.Entity;

namespace GestorProyectos.Extensions.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data, Metadata metadata)
        {
            Data = data;

            if(metadata != null)
                Meta = metadata;
        }

        public T Data { get; set; }
        public Metadata Meta { get; set; }
    }
}
