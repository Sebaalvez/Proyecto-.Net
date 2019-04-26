using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2Clases
{
    public class Oficina : Apartamento

    {
        private string puestosTrabajo;
        private string equipamiento;
        private int MontoFijo=100;
      

        //Construtor
        public Oficina(int Piso, int Numero, decimal MetrajeTotal, decimal PrecioBase, string Orientacion, string puestosTrabajo, string equipamiento) : base(Piso, Numero, MetrajeTotal, PrecioBase, Orientacion)
        {
            this.puestosTrabajo = puestosTrabajo;
            this.equipamiento = equipamiento;
        }

       

        public string Equipamiento
        {
            get
            {
                return equipamiento;
            }

            set
            {
                equipamiento = value;
            }
        }

        public string PuestosTrabajo
        {
            get
            {
                return puestosTrabajo;
            }

            set
            {
                puestosTrabajo = value;
            }
        }

        //Metodo que calcula el precio de las ordicinas
        public override  decimal PrecioTotal()
        {
            decimal PrecioTotal = (PrecioBase * MetrajeTotal)+ ( Convert.ToInt32(PuestosTrabajo)* MontoFijo) ;
            if (Equipamiento == "Si") {

                PrecioTotal = (PrecioTotal * 10) / 100;
            }
            return PrecioTotal;
        }
    }
}
