using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Obligatorio2Clases;

namespace Obligatorio2.Controllers
{
    public class ABMController : Controller
    {
        // GET: ABM


        public ActionResult Index() {

             if (Session["Vendedor"] != null)
            {

                ViewBag.Estado = "Hay un vendedor logueado,por favor cierre sesion para poder acceder a las opciones";
                return Redirect("~/Login/Cerrarsesion");
            }

            return View();
        }
        public ActionResult ModificarClientes(string cliente, string apellido, string direccion, string telefono)
        {

            if (Session["Vendedor"] != null)
            {

                ViewBag.Estado = "Hay un vendedor logueado,por favor cierre sesion para poder acceder a las opciones";
                return Redirect("~/Login/Cerrarsesion");
            }
            else
            {

                if (direccion != "" && apellido != "" && telefono != "")
                {

                    Sistema.Instancia.CambiarDatos(cliente, apellido, direccion, telefono);
                    ViewBag.Estado = "Cambio los datos correctamente";
                }
                else
                {
                    ViewBag.Estado = "Hay campos vacios,Verifique!!";
                }

                return View("ModificarClientes");

            }
        }

        public ActionResult AltaClientes(string nombre, string apellido, string documento, string direccion, string telefono)
        {
            if (Session["Vendedor"] != null)
            {

                ViewBag.Estado = "Hay un vendedor logueado,por favor cierre sesion para poder acceder a las opciones";
                return Redirect("~/Login/Cerrarsesion");
            }
            else
            {

                if (nombre != "" && apellido != "" && documento != "" && direccion != "" && telefono != "" && nombre != null && apellido != null && documento != null && direccion != null && telefono != null)
                {

                    ViewBag.Estado= Sistema.Instancia.AltaClientes(nombre, apellido, documento, direccion, telefono);

                }

                else
                {
                    ViewBag.Estado = "Hay campos vacios,Verifique!!";

                }
            }
            return View("AltaClientes");
        }

        public ActionResult BajaClientes(string cliente) {
            if (Session["Vendedor"] != null)
            {
                ViewBag.Estado = "Hay un vendedor logueado,por favor cierre sesion para poder acceder a las opciones";
                return Redirect("~/Login/Cerrarsesion");
            }
            ViewBag.Estado= Sistema.Instancia.EliminarClientes(cliente);

            return View("BajaClientes");

        }

    }
}