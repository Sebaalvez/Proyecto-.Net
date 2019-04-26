using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2Clases
{
    public class Compra {


        private Vendedor vendedor;
        private Cliente cliente;
        private DateTime FechaVenta;
        private decimal precioApto;
        private Apartamento apartamento;
        private int IDCompra;
        private static int ultimoID;
        private decimal ComisionFinal;

        public Vendedor Vendedor
        {
            get
            {
                return vendedor;
            }

            set
            {
                vendedor = value;
            }
        }

        public DateTime FechaVenta1
        {
            get
            {
                return FechaVenta;
            }

            set
            {
                FechaVenta = value;
            }
        }

        public decimal PrecioApto
        {
            get
            {
                return precioApto;
            }

            set
            {
                precioApto = value;
            }
        }

        public Apartamento Apartamento
        {
            get
            {
                return apartamento;
            }

            set
            {
                apartamento = value;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public Compra(Vendedor vendedor, DateTime fechaVenta, Apartamento apartamento,Cliente cliente,decimal PrecioApto)
        {
            this.Vendedor = vendedor;
            FechaVenta1 = fechaVenta;
            this.precioApto = PrecioApto;
            this.Apartamento = apartamento;
            this.Cliente = cliente;
            this.UltimoID = UltimoID + 1;
            this.IDCompra = UltimoID;
            this.ComisionFinal = vendedor.PorcentajeComision1;
            
            
        }



        public override string ToString()
        {
           
            return "venta  " + this.IDCompra;

        }


        //Devuelvo el ToString con lo que deseo mostrar.
        public string toStringDatosVenta
        {
            get
            {
                return this.ToString();
            }
        }

        public int IDCompra1
        {
            get
            {
                return IDCompra;
            }

            set
            {
                IDCompra = value;
            }
        }

        public int UltimoID
        {
            get
            {
                return ultimoID;
            }

            set
            {
                ultimoID = value;
            }
        }



        public decimal ComisionFinal1
        {
            get
            {
                return ComisionFinal;
            }

            set
            {
                ComisionFinal = value;
            }
        }

        public void CalculoComision(Edificio edificio) {


            decimal PorcentajeComision = vendedor.ComisionPorEdificio(edificio);
            ComisionFinal = ((Apartamento.PrecioTotal() * PorcentajeComision) / 100);


        }

    }

}
    

