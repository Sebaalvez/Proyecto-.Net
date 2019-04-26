using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2Clases
{
    public class Vendedor
    {
        private string nombre;
        private string clave;
        private decimal PorcentajeComision;
        private List<Comision> Comision;



        public Vendedor(string Nombre,string  Clave) {

            this.nombre = Nombre;
            this.clave = Clave;
            this.PorcentajeComision = PorcentajeComision1;




        }

        public Vendedor()
        {
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Clave
        {
            get
            {
                return clave;
            }

            set
            {
                clave = value;
            }
        }

        public List<Comision> Comision1
        {
            get
            {
                return Comision;
            }

            set
            {
                Comision = value;
            }
        }

        public decimal PorcentajeComision1
        {
            get
            {
                return PorcentajeComision;
            }

            set
            {
                PorcentajeComision = value;
            }
        }

        public void AgregarComisiones(decimal comision, Edificio edificio) {

            Comision c = new Comision(comision, edificio);
            
            if (Comision1 == null)
            {
                Comision1 = new List<Comision>();
                Comision1.Add(c);
            }
            else {
                Comision1.Add(c);
            }


        }

        public decimal ComisionPorEdificio(Edificio edificio) {


            int i = 0;
            decimal comisionEdificio = 0;
            bool Bandera = false;

            while (i< Comision1.Count  && !Bandera) {

                if (Comision1[i].Edificio.Nombre == edificio.Nombre) {

                    comisionEdificio = Comision1[i].Pocentajecomision1;
                    Bandera = true;


                }
                i++;


            }
            return comisionEdificio;




        }


        public override bool Equals(object obj)
        {
            bool esIgual = false;
            if (obj != null)
            {
                if (obj is Vendedor)
                {
                    esIgual = ((Vendedor)obj).nombre == this.Nombre  &&((Vendedor)obj).clave == this.Clave;
                }
            }
            return esIgual;
        }

        
    }
}
