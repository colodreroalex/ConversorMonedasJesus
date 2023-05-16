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

        public static double ControlConvertir()
        {
            TipoConversor convertir = TipoConversor.DolarEuro;
            double cantidad = 0;
            double cantidadAConvertir = 0;
            double cantidadConvertida = 0; 

            convertir = (TipoConversor)Interfaz.OpcionDeConversion((byte)TipoConversor.DolarEuro);

            switch (convertir)
            {
                case TipoConversor.EuroDolar:
                    cantidad = GficheroT.ObtenerConversor((byte)TipoConversor.EuroDolar);
                    cantidadAConvertir = Interfaz.pedirCantidad();
                    
                    cantidadConvertida = cantidad * cantidadAConvertir;
                    Interfaz.MostrarConversion(cantidadConvertida);

                    break;


                case TipoConversor.DolarEuro:

                    break; 
            }



            return cantidadConvertida; 

        }

        public static void ControlConfiguracion()
        {
            throw new NotImplementedException();
        }
    }
}
