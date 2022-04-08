using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using GestorProyectos.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GestorProyectos.Infrastructure.Repositories
{
    public class OlvidoClaveRepository : BaseRepository<Usuarios>, IOlvidoClaveRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        ProyectosDbContext _context;

        public OlvidoClaveRepository(ProyectosDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task EnviarClave(string Usuario, string Clave)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@Usuario", SqlDbType.NVarChar);
            parms[0].Value = Usuario;
            parms[1] = new SqlParameter("@Clave", SqlDbType.NVarChar);
            parms[1].Value = Clave;
            _unitOfWork.GetDataFromProcedure("[Proceso].[usp_Enviar_Clave]", parms);
        }
    }
}
