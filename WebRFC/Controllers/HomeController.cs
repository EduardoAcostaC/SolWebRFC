using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace WebRFC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("VistaPrincipal");
        }

        public ActionResult IrFormulario()
        {
            return View("VistaFormulario");
        }
 
        public ActionResult IrBaseDatos()
        {
            List<E_RFC> lista = new List<E_RFC>();
            try
            {
                N_RFC negocio = new N_RFC();
                lista = negocio.ObtenerTodos();

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View("VistaBD", lista);
        }

        public ActionResult FormularioPOST(E_RFC rfc)
        {
            try
            {
                E_RFC objRFC = new E_RFC();
                N_RFC negocio = new N_RFC();
                string rfcok = negocio.AgregarRFC(rfc);
                TempData["RFC"] = rfcok;

                return View("VistaRFC", objRFC);

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult ObtenerEditar(int id)
        {
            try
            {
                N_RFC negocio = new N_RFC();
                E_RFC obj = negocio.ObtenerPorId(id);
                return View("VistaEditar", obj);
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return RedirectToAction("IrBaseDatos");
            }
        }

        public ActionResult EditarPOST(E_RFC rfc)
        {
            try
            {
                N_RFC negocio = new N_RFC();
                negocio.GuardarEdicion(rfc);
                return RedirectToAction("IrBaseDatos");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return RedirectToAction("IrBaseDatos");
            }
        }

        public ActionResult ObtenerEliminar(int id)
        {
            try
            { 
                N_RFC negocio = new N_RFC();
                E_RFC obj = negocio.ObtenerPorId(id);
                return View("VistaEliminar", obj);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("IrBaseDatos");
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                N_RFC negocio = new N_RFC();
                negocio.EliminarRFC(id);

                return RedirectToAction("IrBaseDatos");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("IrBaseDatos");
            }
        }

        public ActionResult Busqueda(string busqueda)
        {
            try
            {
                N_RFC negocio = new N_RFC();
                List<E_RFC> lista = negocio.BuscarRFC(busqueda);
                return View("VistaBD",lista);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("IrBaseDatos");
                
            }
        }
    }
}