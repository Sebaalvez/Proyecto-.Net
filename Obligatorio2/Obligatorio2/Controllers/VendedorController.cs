using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Obligatorio2Clases;

namespace Obligatorio2.Controllers
{
    public class VendedorController : Controller
    {
        // GET: Vendedor
        public ActionResult Index()
        {
            if (ViewBag.cliente == null)
            {
                ViewBag.cliente = new List<Cliente>();
            }
            if (ViewBag.apartamento == null)
            {
                ViewBag.apartamento = new List<Apartamento>();
            }

            return View("MostrarDatos");
        }


        public ActionResult MostrarDatos(string ventas)

        {
            if (ViewBag.cliente == null)
            {
                ViewBag.cliente = new List<Cliente>();
            }
            if (Session["Vendedor"] == null) {
                return Redirect("~/Login/Login");

            }
            else { 
            string NombreUsuario = Session["Vendedor"].ToString();
            ViewBag.cliente = Sistema.Instancia.DevolverVentas(NombreUsuario,ventas);
            ViewBag.apartamento = Sistema.Instancia.DevolverVentas(NombreUsuario,ventas);
            ViewBag.comision = Sistema.Instancia.DevolverVentas(NombreUsuario, ventas);
            ViewBag.ventas = ventas;
            Sistema.Instancia.RetornoVaSessio(NombreUsuario);
            return View("MostrarDatos");

        }
        }




    }
}