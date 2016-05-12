using Dominio;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaControladorVista.Controllers
{
    public class MantenimentoClientesController : Controller
    {
        //
        // GET: /MantenimentoClientes/
        readonly IOperacion _operacion;
        //IContexto contexto = new Contexto();
        public MantenimentoClientesController(IOperacion operacion)
        {

            this._operacion = operacion;
        }

        public ActionResult Index()
        {
            return View(_operacion.GetAll().ToList());
        }

        public ActionResult Create(Cliente cliente)
        {
            if (null != cliente.Nombre)
            {
                var cl = _operacion.Add(cliente);
                return RedirectToAction("Index");               
            }           
            return View(cliente);

        }

        public ActionResult Delete(Cliente cliente)
        {
            if(null != cliente)
            {
                Cliente ClienteId = _operacion.Get(cliente.Id);
                _operacion.Delete(ClienteId);

                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        //GET
        public ActionResult Edit(int id) 
        {
            
            Cliente ClienteId = _operacion.Get(id);
            if (null != ClienteId)
            {
                return View(ClienteId);
            }
            return HttpNotFound();
            
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            // Cliente ClienteId = _operacion.Get(cliente.Id);
            if (null != cliente)
            {
                _operacion.Update(cliente);
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public ActionResult Details(int id)
        {
            if (null == id)
            {
                return HttpNotFound();
            }
            Cliente clienteId = _operacion.Get(id);
            return View(clienteId);

        }

        //public ActionResult GetClientes()
        //{
        //    var listClientes = _operacion;
        //}
    }
}
