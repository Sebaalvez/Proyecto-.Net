using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2Clases
{
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private string documento;
        private string direccion;
        private string telefono;
        private List<Compra> Compras;


        public Cliente(string nombre, string apellido, string documento, string direccion, string telefono)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.direccion = direccion;
            this.telefono = telefono;
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

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public string Documento
        {
            get
            {
                return documento;
            }

            set
            {
                documento = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public List<Compra> Compras1
        {
            get
            {
                return Compras;
            }

            set
            {
                Compras = value;
            }
        }

        public void CambiarDatos(string DireccionNueva,string TelefonoNuevo,string ApellidoNuevo)
        {
            this.direccion = DireccionNueva;
            this.apellido = ApellidoNuevo;
            this.telefono = TelefonoNuevo;
        }
    }
}
