using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProyectos.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEstadosRepository EstadosRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
