using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2Clases
{
    public abstract class Apartamento
    {
        private int piso;
        private int numero;
        private decimal metrajeTotal;
        private decimal precioBase;
        private string orientacion;


        //Constructor
        public Apartamento(int Piso, int Numero, decimal MetrajeTotal, decimal PrecioBase, string Orientacion)
        {
            this.piso = Piso;
            this.numero = Numero;
            this.metrajeTotal = MetrajeTotal;
            this.precioBase = PrecioBase;
            this.orientacion = Orientacion;
        }

        public int Piso
        {
            get
            {
                return piso;
            }

            set
            {
                piso = value;
            }
        }

        public int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public decimal MetrajeTotal
        {
            get
            {
                return metrajeTotal;
            }

            set
            {
                metrajeTotal = value;
            }
        }

        public decimal PrecioBase
        {
            get
            {
                return precioBase;
            }

            set
            {
                precioBase = value;
            }
        }

        public string Orientacion
        {
            get
            {
                return orientacion;
            }

            set
            {
                orientacion = value;
            }
        }

        
       
        public override string ToString()
        {
            return "Piso : " + this.piso + " , " + "Numero :"+this.numero + " , " + "Orientacion :" + this.orientacion ;
        }


        //Devuelvo el ToString con lo que deseo mostrar.
        public string toStringDatosApto
        {
            get
            {
                return this.ToString();
            }
        }

        //Metodo para calcular el precio de los apartamentos,este es heredado a las clases hijas.
        public abstract decimal PrecioTotal();


    }
}