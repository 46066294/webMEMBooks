using System;
namespace Insfrastructura
{
    public interface IUnitOfWork:IDisposable
    {
        int SaveChanges();
    }
}
