using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Insfrastructura
{
    public interface IRepository : IUnitOfWork
    {
        IDbSet<Cliente> Cliente { get; set; }
    }
}
