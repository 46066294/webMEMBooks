using Dominio;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ClientController : ApiController
    {
        /*Inyección de dependencias*/
        readonly IOperacion _operacion;

        public ClientController(IOperacion operacion)
        {
            this._operacion = operacion;
        }

        // GET api/values
        public IEnumerable<Cliente> Get()
        {
            return _operacion.GetAll().ToList();
        }

        // GET api/values/5
        public Cliente Get(int id)
        {
            var clienteId = _operacion.Get(id);
            return clienteId;
        }

        // POST api/values
        public void Post([FromBody]Cliente cliente)
        {
            if(cliente.Nombre == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _operacion.Add(cliente);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Cliente cliente)
        {
            cliente.Id = id;
            _operacion.Update(cliente);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Cliente ClienteId = _operacion.Get(id);
            _operacion.Delete(ClienteId);
        }
    }
}


//HTTPRESPONSE web api -> para conseguir devovler un 404 