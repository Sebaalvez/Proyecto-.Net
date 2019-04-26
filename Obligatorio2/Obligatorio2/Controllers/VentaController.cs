using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Obligatorio2Clases;

namespace Obligatorio2.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        public ActionResult Ventas()
        {
            if (ViewBag.apartamentos == null) {
            ViewBag.apartamentos = new List<Apartamento>();
            }
            if (Session["Vendedor"] == null) {
                ViewBag.Estado = "Debe iniciar sesion,antes de realizar una compra";
                return Redirect("~/Login/Login");
                

            }
            return View();
        }


        public ActionResult MostrarApartamentos(string edificio)
        {

            ViewBag.apartamentos = Sistema.Instancia.DevolverAptos(edificio);
            ViewBag.edificio = edificio;
            return View("Ventas");
        
    }

        public ActionResult ComprarApto(string cliente, string edificio,string apartamentos, DateTime ? fecha)
        {
            ViewBag.Cliente = cliente;
            string NombreUsuario = Session["Vendedor"].ToString();

            if (cliente != "" && edificio != "" && apartamentos != "" && fecha != null) {
                Sistema.Instancia.ComprarAptos(NombreUsuario, Convert.ToDateTime(fecha), cliente, edificio, apartamentos);
                ViewBag.apartamentos = new List<Apartamento>();
                ViewBag.Estado = "Se compro un Apartamento con exito!";
            }
            else {
                ViewBag.apartamentos = new List<Apartamento>();
                ViewBag.Estado = "Hay campos vacios,por favor seleccione una opcion!";

            }
            return View("Ventas");
        }
    }
}