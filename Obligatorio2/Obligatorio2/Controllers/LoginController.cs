using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Obligatorio2Clases;

namespace Obligatorio2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            
            return View("Login", new Vendedor());
        }

        public ActionResult VerificarVendedor(Vendedor v)
        {
            if (v.Nombre != "" && v.Clave != "")
            {
                if (Sistema.Instancia.VerificarVendedor(v))
                {
                    Session["Vendedor"] = v.Nombre;
                    return Redirect("~/Vendedor/Index");
                }
                else
                {
                    
                    ViewBag.Estado = "Los datos ingresados no son correctos";

                }
            }

            else {
                ViewBag.Estado = "Hay campos vacios,Verifique!!";
            }
            return View("Login",v);
        }
        public ActionResult Cerrarsesion()
        {
            if (Session["Vendedor"] != null)
            {
                Session["Vendedor"] = null;
                ViewBag.Estado = "se ha cerrado sesion correctamente";
            }
            else {

                ViewBag.Estado = "no hay un usuario Logueado";
            }
           
        
            return View("Cerrarsesion");
        }
    }
}