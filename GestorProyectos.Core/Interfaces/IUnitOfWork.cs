using GestorProyectos.Base.Interfaces;
using GestorProyectos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProyectos.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Estados> EstadosRepository { get; }
        IBaseRepository<Barrios> BarriosRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
