using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMonedasJesus
{

    public enum TipoConversor : byte { Salir, EuroDolar, DolarEuro }

    public static class Controlador
    {

        private enum MenuPrincipal : byte { Salir, Configurar, Convertir }

        public static void ControlPrincipal()
        {

            MenuPrincipal menu = MenuPrincipal.Salir;

            //Comprobar si el Fichero Existe

            GficheroT.ComprobarFichero(); 

            do
            {

                menu = (MenuPrincipal)Interfaz.OpcionMPrincipal((byte)MenuPrincipal.Convertir);

                switch (menu)
                {
                    case MenuPrincipal.Configurar:
                        ControlConfiguracion(); 
                        break;
                        case MenuPrincipal.Convertir:
                        ControlConvertir(); 
                        break;
                }

            } while (menu != MenuPrincipal.Salir); 

            //DESPEDIDA

        }

        public static void ControlConvertir()
        {
            TipoConversor convertir = TipoConversor.DolarEuro;
            double cantidad = 0;
            double cantidadAConvertir = 0;
            double cantidadConvertida = 0; 

            //Que opcion de conversion queremos
            convertir = (TipoConversor)Interfaz.OpcionDeConversion((byte)TipoConversor.DolarEuro);

            switch (convertir)
            {
                case TipoConversor.EuroDolar:
                    //Obtenemmos la linea del fichero 
                    cantidad = GficheroT.ObtenerConversor((byte)TipoConversor.EuroDolar);

                    //Pedios la cantidad al Usuario
                    cantidadAConvertir = Interfaz.pedirCantidad();
                    
                    //Realizamos la operacion
                    cantidadConvertida = cantidad * cantidadAConvertir;

                    //Mostraos por pantalla
                    Interfaz.MostrarConversion(cantidadConvertida);

                    break;


                case TipoConversor.DolarEuro:
                    //Obtenemos la linea del fichero (2)
                    cantidad = GficheroT.ObtenerConversor((byte)TipoConversor.DolarEuro);

                    //Pedios la cantidad al Usuario
                    cantidadAConvertir = Interfaz.pedirCantidad();

                    //Realizamos la operacion 
                    cantidadConvertida = cantidad * cantidadAConvertir;

                    //Mostrar esta por pantalla
                    Interfaz.MostrarConversion(cantidadConvertida); 

                    break; 
            }



            

        }

        public static void ControlConfiguracion()
        {
            StreamWriter sw = null;
            string confirmacion;
            double euro;
            double dollar; 

            do
            {
                euro = Interfaz.IntroducirTasasEuro();
                dollar = Interfaz.IntroducirTasasDolar();

                GficheroT.GuardarDatos(euro, dollar);

                confirmacion = Interfaz.ConfirmarSalida(); 

            } while (confirmacion.ToLower() == "N"); 
            
        }
    }
}
