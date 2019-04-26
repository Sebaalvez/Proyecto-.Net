using Obligatorio2Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Obligatorio2Clases

{
    public class Sistema
    {
        private List<Edificio> Edificios = new List<Edificio>();
        private List<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
        public List<Cliente> Clientes = new List<Cliente>();
        public List<Compra> Compras = new List<Compra>();




        private static Sistema instancia;

        public static Sistema Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sistema();
                }
                return instancia;
            }
        }

        private Sistema()
        {
            CargarDatosPrueba();
        }


        //Region Edificios


        #region
        //Agrega un edificio con un primer aparatamento.
        public string AgregarEdificioconOficina(string Nombre, string Direccion, int Piso, int Numero, decimal MetrajeTotal, decimal PrecioBase, string Orientacion, string PuestosTrabajo, string Equipamiento)
        {
            string Mensaje = "";
            if (Nombre != "" && Direccion != "")
            {
                if (this.BuscarEdificio(Nombre) == null)
                {
                    Edificio e = new Edificio(Nombre, Direccion);
                    Edificios.Add(e);
                    e.ListaApartamentos1.Add(AgregarOficina(Piso, Numero, MetrajeTotal, PrecioBase, Orientacion, PuestosTrabajo, Equipamiento));

                    Mensaje = "Se agrego Correctamente el Edificio.";
                }
                else
                {

                    Mensaje = "El edificio ingresado ya existe.";
                }
            }
            else
            {

                Mensaje = "Hay campos vacios,Verifique!";

            }

            return Mensaje;
        }

        public string AgregarEdificioconCasa(string Nombre, string Direccion, int Piso, int Numero, decimal MetrajeTotal, decimal PrecioBase, string Orientacion, int Dormitorios, int Banos, bool Garaje)
        {
            string Mensaje = "";
            if (Nombre != "" && Direccion != "")
            {
                if (this.BuscarEdificio(Nombre) == null)
                {
                    Edificio e = new Edificio(Nombre, Direccion);
                    Edificios.Add(e);

                    e.ListaApartamentos1.Add(AgregarCasaHabitacion(Piso, Numero, MetrajeTotal, PrecioBase, Orientacion, Dormitorios, Banos, Garaje));

                    Mensaje = "Se agrego Correctamente el Edificio.";
                }
                else
                {

                    Mensaje = "El edificio ingresado ya existe.";
                }
            }
            else
            {

                Mensaje = "Hay campos vacios,Verifique!";

            }

            return Mensaje;
        }

        //En estos metodos creo un Apartamentos con el tipo  Casa o una Oficina.
        private Apartamento AgregarOficina(int Piso, int Numero, decimal MetrajeTotal, decimal PrecioBase, string Orientacion, string PuestosTrabajo, string Equipamiento)
        {
            Apartamento a = new Oficina(Piso, Numero, MetrajeTotal, PrecioBase, Orientacion, PuestosTrabajo, Equipamiento);

            return a;
        }

        private Apartamento AgregarCasaHabitacion(int Piso, int Numero, decimal MetrajeTotal, decimal PrecioBase, string Orientacion, int Dormitorios, int Banos, bool Garaje)
        {
            Apartamento a = new Casa(Piso, Numero, MetrajeTotal, PrecioBase, Orientacion, Dormitorios, Banos, Garaje);

            return a;
        }


        //Metodo que busca si el edificio ingresado  ya existe.
        public Edificio BuscarEdificio(string Nombre)
        {

            bool Existe = false;
            Edificio e = null;
            int i = 0;

            while (i < Edificios.Count && !Existe)
            {

                if (Edificios[i].Nombre.ToUpper() == Nombre.ToUpper())
                {

                    Existe = true;
                    e = Edificios[i];

                }

                i++;
            }
            return e;

        }




        //Retorna la lista de Edificios
        public List<Edificio> DevolverEdificios
        {
            get
            {
                return Edificios;
            }

        }
        #endregion



        //Region Aparatamentos
        #region

        //En este metodos creo un Apartamentos con el tipo  Casa o una Oficina,contando con ciertas validaciones.
        public string AgregarApartamentos(string Nombre, int Piso, int Numero, decimal MetrajeTotal, decimal PrecioBase, string Orientacion, string OpcionesApto, string PuestosTrabajo, string Equipamiento, int Dormitorios, int Banos, bool Garaje)
        {
            string Mensaje = "";
            Edificio edi = BuscarEdificio(Nombre);
            List<Apartamento> Retorno = null;

            if (edi != null)
            {
                if (edi.BuscarAptos(Piso, Numero) == null)
                {
                    if (OpcionesApto == "Oficina")
                    {
                        if (Piso != 0 && Numero != 0 && MetrajeTotal != 0 && PrecioBase != 0 && PuestosTrabajo != "")
                        {
                            Apartamento a = new Oficina(Piso, Numero, MetrajeTotal, PrecioBase, Orientacion, PuestosTrabajo, Equipamiento);
                            edi.ListaApartamentos1.Add(a);
                            Retorno = edi.ListaApartamentos1;
                            Mensaje = "Se agrego un apartamento con destino a oficina con exito";
                        }
                        else
                        {
                            Mensaje = "Se ingresaron campos vacios o nulos,VERIFIQUE!";
                        }
                    }

                    if (OpcionesApto == "CasaHabitacion")
                    {
                        if (Piso != 0 && Numero != 0 && MetrajeTotal != 0 && PrecioBase != 0)
                        {
                            Apartamento a = new Casa(Piso, Numero, MetrajeTotal, PrecioBase, Orientacion, Dormitorios, Banos, Garaje);
                            edi.ListaApartamentos1.Add(a);
                            Retorno = edi.ListaApartamentos1;
                            Mensaje = "Se agrego un apartamento con destino a casa con exito";
                        }
                        else
                        {
                            Mensaje = "Se ingresaron campos vacios o nulos,VERIFIQUE!";
                        }
                    }
                }
                else
                {
                    Mensaje = "No se agrego el apartamento,ya que existe uno con el mismo piso y numero.";

                }

            }


            return Mensaje;
        }


        //Deuelvo una lista de Aparatamentos.

        public List<Apartamento> DevolverAptos(string Nombre)
        {

            Edificio edi = BuscarEdificio(Nombre);
            List<Apartamento> Retorno = null;

            if (edi != null)
            {

                Retorno = edi.ListaApartamentos1;
            }

            return Retorno;
        }


        #endregion


        //Region Filtrar edificios por metraje.
        #region

        //Metodo que vuelve una lista de edificios que cumplan con los requisitos del metraje.
        public List<Edificio> DevolverEdificiosMetraje(decimal MetrajeMinimo, decimal MetrajeMaximo, string Orientacion, string Nombre)
        {
            List<Edificio> FiltroMetraje = new List<Edificio>();
            bool esta = false;
            if (MetrajeMinimo != 0 && MetrajeMaximo != 0)
            {

                foreach (Edificio e in Edificios)
                {

                    for (int i = 0; i < e.ListaApartamentos1.Count; i++)
                    {
                        if (e.ListaApartamentos1[i].MetrajeTotal >= MetrajeMinimo && e.ListaApartamentos1[i].MetrajeTotal <= MetrajeMaximo
                            && e.ListaApartamentos1[i].Orientacion == Orientacion && !esta)
                        {
                            {
                                FiltroMetraje.Add(e);
                                esta = true;
                            }


                        }

                    }
                }

            }

            return FiltroMetraje;
        }


        #endregion


        //Region Filtrar Apartamentos por metraje.
        #region

        //Metodo que vuelve una lista de apartamentos de todos los edificios que cumplan con los requisitos del metraje.
        public List<Apartamento> DevolverAptosMetraje(decimal MetrajeMinimo, decimal MetrajeMaximo)
        {
            List<Apartamento> FiltroApartamentosMetraje = new List<Apartamento>();
            if (MetrajeMinimo != 0 && MetrajeMaximo != 0)
            {

                foreach (Edificio e in Edificios)
                {

                    for (int i = 0; i < e.ListaApartamentos1.Count; i++)
                    {
                        if (e.ListaApartamentos1[i].MetrajeTotal >= MetrajeMinimo && e.ListaApartamentos1[i].MetrajeTotal <= MetrajeMaximo)
                        {

                            FiltroApartamentosMetraje.Add(e.ListaApartamentos1[i]);

                        }
                    }
                }
            }
            return FiltroApartamentosMetraje;
        }


        #endregion


        //Region Filtrar Apartamentos por precio.
        #region

        //Metodo que vuelve una lista de apartamentos de todos los edificios que cumplan con los requisitos del precio.
        public List<Apartamento> DevolverAptosPrecio(decimal PrecioMinimo, decimal PrecioMaximo)
        {
            Apartamento a = null;
            List<Apartamento> FiltroApartamentosPrecio = new List<Apartamento>();

            if (PrecioMinimo != 0 && PrecioMaximo != 0)
            {

                foreach (Edificio e in Edificios)
                {

                    for (int i = 0; i < e.ListaApartamentos1.Count; i++)
                    {
                        if (e.ListaApartamentos1[i].PrecioTotal() >= PrecioMinimo && e.ListaApartamentos1[i].PrecioTotal() <= PrecioMaximo)
                        {


                            FiltroApartamentosPrecio.Add(e.ListaApartamentos1[i]);

                            a = FiltroApartamentosPrecio[i];


                        }
                    }
                }
            }
            return FiltroApartamentosPrecio;
        }
        #endregion

        public void CargarDatosPrueba()
        {
            this.AltaVendedor("vend1", "vend1111");
            this.AltaVendedor("vend2", "vend2222");
            this.AltaClientes("Juan", "Perez", "12345678", "Mexico 1668", "091234567");
            this.AltaClientes("Maria", "Lopez", "23456789", "Grecia 1223", "092345678");
            this.AgregarEdificioconCasa("Hilton", "Mexico 1668", 1, 1, 5000, 4000, "S", 3, 2, true);
            this.AgregarEdificioconOficina("Radisson", "Grecia 1223", 1, 1, 5500, 3200, "N", "350", "Si");
            this.AgregarApartamentos("Hilton", 1, 2, 5000, 4000, "SE", "CasaHabitacion", "0", "No", 3, 1, false);
            this.AgregarApartamentos("Hilton", 2, 2, 3000, 2500, "NE", "CasaHabitacion", "0", "No", 1, 1, true);
            this.AgregarApartamentos("Hilton", 2, 3, 6000, 5000, "O", "CasaHabitacion", "0", "No", 3, 2, true);
            this.AgregarApartamentos("Hilton", 4, 2, 4500, 4000, "E", "CasaHabitacion", "0", "No", 2, 1, true);
            this.AgregarApartamentos("Hilton", 3, 1, 4000, 3500, "NO", "CasaHabitacion", "0", "No", 2, 2, false);
            this.AgregarApartamentos("Hilton", 2, 5, 4000, 3500, "SE", "Oficina", "200", "No", 0, 0, false);
            this.AgregarApartamentos("Hilton", 3, 7, 5500, 5000, "NE", "Oficina", "350", "Si", 0, 0, false);
            this.AgregarApartamentos("Hilton", 4, 1, 4500, 4000, "SO", "Oficina", "250", "Si", 0, 0, false);

            this.AgregarApartamentos("Radisson", 1, 2, 5000, 4000, "SE", "CasaHabitacion", "0", "No", 3, 1, false);
            this.AgregarApartamentos("Radisson", 2, 2, 3000, 2500, "NE", "CasaHabitacion", "0", "No", 1, 1, true);
            this.AgregarApartamentos("Radisson", 2, 3, 6000, 5000, "O", "CasaHabitacion", "0", "No", 3, 2, true);
            this.AgregarApartamentos("Radisson", 4, 2, 4500, 4000, "E", "CasaHabitacion", "0", "No", 2, 1, true);
            this.AgregarApartamentos("Radisson", 3, 1, 4000, 3500, "NO", "CasaHabitacion", "0", "No", 2, 2, false);
            this.AgregarApartamentos("Radisson", 2, 5, 4000, 3500, "SE", "Oficina", "200", "No", 0, 0, false);
            this.AgregarApartamentos("Radisson", 3, 7, 5500, 5000, "NE", "Oficina", "350", "Si", 0, 0, false);
            this.AgregarApartamentos("Radisson", 4, 1, 4500, 4000, "SO", "Oficina", "250", "Si", 0, 0, false);

            this.AltaComision(5, "Radisson", "vend1");
            this.AltaComision(2, "Hilton", "vend1");
            this.AltaComision(3, "Radisson", "vend2");
            this.AltaComision(1, "Hilton", "vend2");
            this.ComprarAptos("vend1", DateTime.Now, "12345678", "Radisson", "Piso : " + 1 + " , " + "Numero :" + 2 + " , " + "Orientacion :" + "SE");
            this.ComprarAptos("vend1", DateTime.Now, "12345678", "Radisson", "Piso : " + 4 + " , " + "Numero :" + 1 + " , " + "Orientacion :" + "SO");
            this.ComprarAptos("vend1", DateTime.Now, "23456789", "Hilton", "Piso : " + 4 + " , " + "Numero :" + 1 + " , " + "Orientacion :" + "SO");
            this.ComprarAptos("vend2", DateTime.Now, "23456789", "Hilton", "Piso : " + 1 + " , " + "Numero :" + 2 + " , " + "Orientacion :" + "SE");
            this.ComprarAptos("vend2", DateTime.Now, "23456789", "Hilton", "Piso : " + 3 + " , " + "Numero :" + 7 + " , " + "Orientacion :" + "NE");

            
        }

        public bool VerificarVendedor(Vendedor v)
        {
            bool usuarioCorrecto = false;
            if (this.Vendedores.Contains(v))
            {
                usuarioCorrecto = true;
            }
            return usuarioCorrecto;
        }

        public void AltaVendedor(string Nombre, string Clave)
        {
            Vendedor v = BuscarVendedor(Nombre);
            if (v == null)
            {
                v = new Vendedor(Nombre, Clave);
                this.Vendedores.Add(v);
            }
        }

        public Vendedor BuscarVendedor(string Nombre)
        {
            Vendedor v = null;
            int i = 0;
            while (i < this.Vendedores.Count && v == null)
            {
                if (Vendedores[i].Nombre == Nombre)
                {
                    v = Vendedores[i];

                }
                i++;
            }
            return v;
        }



        public string AltaClientes(string Nombre, string Apellido, string Documento, string Direccion, string Telefono)
        {
            string Mensaje = "";
            Cliente c = BuscarClientes(Documento);
            if (c == null)
            {
                c = new Cliente(Nombre, Apellido, Documento, Direccion, Telefono);
                this.Clientes.Add(c);
                Mensaje = "Se agrego un nuevo cliente!";
            }
            else {
                Mensaje = "El cliente ya existe!";

            }
            return Mensaje;
        }


        public Cliente BuscarClientes(string Documento)
        {
            Cliente c = null;
            int i = 0;
            while (i < this.Clientes.Count && c == null)
            {
                if (Clientes[i].Documento == Documento)
                {
                    c = Clientes[i];

                }
                i++;
            }
            return c;
        }
        public void CambiarDatos(string Documento, string ApellidoNuevo, string DireccionNueva, string TelefonoNuevo)
        {

            Cliente c = BuscarClientes(Documento);

            if (c != null)
            {

                c.CambiarDatos(ApellidoNuevo, DireccionNueva, TelefonoNuevo);

            }
        }


        public string EliminarClientes(string Documento)
        {

            Cliente c = BuscarClientes(Documento);
            string Mensaje = "";

            if (c != null)
            {

                if (tieneCompras(Documento) == false)
                {
                    Clientes.Remove(c);
                    Mensaje = "El cliente se removio con exito";
                }
                else
                {
                    Mensaje = "No se puede eliminar el cliente,porque tiene compras realizadas!";
                }
            }
            return Mensaje;
        }


        public void ComprarAptos(string Vendedor, DateTime Fecha, string Documento, string Nombre, string apartamento)
        {

            Cliente c = BuscarClientes(Documento);
            Edificio e = BuscarEdificio(Nombre);
            Vendedor v = BuscarVendedor(Vendedor);
            Apartamento a = BuscarApartamentos(Nombre, apartamento);

            if (c != null && e != null)
            {

                Compra co = new Compra(v, Fecha, a, c,a.PrecioBase);
                Compras.Add(co);
                co.CalculoComision(e);

                e.ListaApartamentos1.Remove(a);
            }

        }

        public Apartamento BuscarApartamentos(string Nombre, string Aptos)
        {

            bool Existe = false;
            Edificio e = BuscarEdificio(Nombre);
            Apartamento a = null;
            int i = 0;

            while (i < e.ListaApartamentos1.Count && !Existe)
            {

                if (e.ListaApartamentos1[i].toStringDatosApto.Trim() == Aptos.Trim())
                {

                    Existe = true;

                    a = e.ListaApartamentos1[i];

                }

                i++;
            }
            return a;

        }


        public List<Compra> DevolverVentas(string Usuario, string Venta)
        {
            Compra com = BuscarVentas(Usuario, Venta);
            Comision c = null;
            
            List<Compra> Retorno = new List<Compra>();

            if (com != null)
            {
     
                Retorno.Add(com);
                
                
                
            }

            return Retorno;
        }

        public Compra BuscarVentas(string Usuario, string Venta)
        {

            bool Existe = false;
            Compra com = null;
            int i = 0;

            while (i < Compras.Count && !Existe)
            {

                if (Compras[i].Vendedor.Nombre == Usuario)
                {
                    if (Compras[i].toStringDatosVenta == Venta)
                    {

                        Existe = true;
                        com = Compras[i];
                    }

                }
                i++;
            }
            return com;

        }
        public bool tieneCompras(string Cliente)
        {

            bool tiene = false;
            int i = 0;
            while (i < Compras.Count && !tiene)
            {
                if (Compras[i].Cliente.Documento == Cliente)
                {

                    tiene = true;

                }
                i++;
            }

            return tiene;

        }
        public string RetornoVaSessio(string Nombre)
        {

            string VariableSession = Nombre;

            return VariableSession;

        }

        public List<Cliente> DevolverComprasPorFecha(DateTime FechaI, DateTime FechaF)
        {

            Cliente c = null;
            List<Cliente> RetornoClientes = new List<Cliente>();


            int i = 0;

            while (i < Compras.Count)
            {

                if (Compras[i].FechaVenta1 >= FechaI && Compras[i].FechaVenta1 <= FechaF)
                {
                    if (!RetornoClientes.Contains(Compras[i].Cliente))
                    {
                        c = Compras[i].Cliente;
                        RetornoClientes.Add(c);
                        RetornoClientes = RetornoClientes.OrderBy(o => o.Nombre).ToList();

                    }

                }
                i++;

            }
            return RetornoClientes;
        }
        public void AltaComision(decimal Comision, string Edificio, string Vendedor)
        {
            int i = 0;
            bool bandera = false;
            Edificio e = BuscarEdificio(Edificio);
            

            while (i < Vendedores.Count && !bandera) {

                if (Vendedores[i].Nombre == Vendedor) {
                    
                    Vendedores[i].AgregarComisiones(Comision, e);
                    
                    bandera = true;


                }
                i++;

            }

        }
    }
    } 




