using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Obligatorio2Clases;

namespace Obligatorio2.Controllers
{
    public class FiltroController : Controller
    {
        // GET: Filtro
        public ActionResult Index()
       {
            if (ViewBag.cliente == null)
            {
                ViewBag.cliente = new List<Cliente>();
            }
            if (ViewBag.fechaI == null || ViewBag.fechaF == null)
            {
                return View("MostrarDatos");
            }
            return View("MostrarDatos");
        }

        public ActionResult MostrarDatos(DateTime ? FechaI,DateTime ?FechaF) {

            if (ViewBag.cliente == null) {
                ViewBag.cliente = new List<Cliente>();
            }
            if (FechaI != null && FechaF != null)
            {
                if (FechaI <= FechaF)
                {
                  
                    ViewBag.cliente = Sistema.Instancia.DevolverComprasPorFecha((DateTime)FechaI,(DateTime) FechaF);
                    ViewBag.Estado = "La busqueda a finalizado con los siguientes resultados:";

                }
                else {
                    ViewBag.Estado = "La fecha inicial debe ser menor a la fecha final!";
                   
                }


            }
            else {
                ViewBag.Estado = "Ingreso Fechas vacias";

            }
           
           
            return View("MostrarDatos");
        }
    }
}