using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2Clases
{
    public class Edificio
    {
        private string nombre;
        private string direccion;
        private List<Apartamento> ListaApartamentos;

    

        //Constructor
        public Edificio (string Nombre, string Direccion)
        {

            this.nombre = Nombre;
            this.direccion = Direccion;
            this.ListaApartamentos = new List<Apartamento>();

        }

        public List<Apartamento> ListaApartamentos1
        {
            get
            {
                return ListaApartamentos;
            }
        }

        public string Nombre
        {
            get{
                return this.nombre;
            }
            set
            {
                nombre = value;
            }


        }
        public string toStringDatos
        {
            get
            {
                return this.ToString();
            }
        }

        //Metodo que busca si el aparatemtno ingresado ya existe.
        public Apartamento BuscarAptos( int Piso, int Numero)
        {

            bool Existe = false;
            Apartamento a = null;
            int i = 0;

            while (i < ListaApartamentos1.Count && !Existe)
            {

                if (ListaApartamentos1[i].Piso == Piso && ListaApartamentos1[i].Numero == Numero)
                {

                    Existe = true;
                    a = ListaApartamentos1[i];

                }

                i++;
            }
            return a;

        }


        public override string ToString()
        {
            return this.nombre + " : " + this.direccion;
        }


        

    }
}
