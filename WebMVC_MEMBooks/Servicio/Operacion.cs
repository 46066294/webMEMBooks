using Dominio;
using Insfrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{
    public class Operacion:ServiceBase,IOperacion
    {
        readonly IRepository _repositorioCliente;
        public Operacion(IRepository repositorioCliente):base (repositorioCliente)
        {
            this._repositorioCliente = repositorioCliente;
        }

        public Cliente Add(Cliente cliente)
        {      
            var customerNew = _repositorioCliente.Cliente.Add(cliente);
            SaveChanges();
            return customerNew;
        }


        public int Delete(Cliente cliente) 
        {
            
            _repositorioCliente.Cliente.Remove(cliente);
            return _repositorioCliente.SaveChanges();         

        }

        public int Update(Cliente cliente)
        {
            var customerBD = Get(cliente.Id);
            
            customerBD.Nombre = cliente.Nombre;
            customerBD.Phone = cliente.Phone;

            return _repositorioCliente.SaveChanges();
        }

        public Cliente Get(int id) 
        {
            var ClienteId = _repositorioCliente.Cliente.Where(c => c.Id == id).FirstOrDefault();
            return ClienteId;


        }

        public IEnumerable<Cliente> GetAll() {
             return _repositorioCliente.Cliente;
        
        }
       
    }
}
