using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2Clases
{
    public class Casa : Apartamento
    {
        private int dormitorios;
        private int banos;
        private bool garaje;
        private int PrecioFijo = 200;


        //Constructor
        public Casa(int Piso, int Numero, decimal MetrajeTotal, decimal PrecioBase, string Orientacion, int Dormitorios, int banos, bool Garaje) : base(Piso, Numero, MetrajeTotal, PrecioBase, Orientacion)
        {
            this.dormitorios = Dormitorios;
            this.banos = banos;
            this.garaje = Garaje;
        }

        public int Dormitorios
        {
            get
            {
                return dormitorios;
            }

            set
            {
                dormitorios = value;
            }
        }

        public int Banos
        {
            get
            {
                return banos;
            }

            set
            {
                banos = value;
            }
        }

        public bool Garaje
        {
            get
            {
                return garaje;
            }

            set
            {
                garaje = value;
            }
        }


        //Metodo que realiza el calculo para el precio del apartamento con destino a casa.
        public override decimal PrecioTotal()
        {
            decimal PrecioTotal = (PrecioBase * MetrajeTotal);

            switch (Dormitorios)
            {

                case 1:
                    PrecioTotal = PrecioTotal +((PrecioTotal * 5) / 100);
                    break;

                case 2:
                    PrecioTotal = PrecioTotal +((PrecioTotal * 5) / 100);
                    break;

                case 3:
                    PrecioTotal = PrecioTotal + ((PrecioTotal * 10) / 100);
                    break;

                case 4:
                    PrecioTotal = PrecioTotal + ((PrecioTotal * 10) / 100);
                    break;

                default:
                    PrecioTotal = PrecioTotal + ((PrecioTotal * 20) / 100);

                    break;
            }
            

            if (Garaje)
            {

                PrecioTotal = PrecioTotal + PrecioFijo;
            }
            if (Orientacion == "N" && Orientacion == "NE" && Orientacion == "NO")
            {

                PrecioTotal = PrecioTotal = (PrecioTotal * 15) / 100;
            }

            return PrecioTotal;
        }
    }
}

