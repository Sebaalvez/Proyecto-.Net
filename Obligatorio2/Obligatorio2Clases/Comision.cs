using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2Clases
{
   public  class Comision
    {
        decimal Pocentajecomision;
        private  Edificio edificio;

        public Comision(decimal comision, Edificio e)
        {
            this.Pocentajecomision = comision;
            this.edificio = e;
        }

        public decimal Pocentajecomision1
        {
            get
            {
                return Pocentajecomision;
            }

            set
            {
                Pocentajecomision = value;
            }
        }

        public Edificio Edificio
        {
            get
            {
                return edificio;
            }

            set
            {
                edificio = value;
            }
        }
    }
}
