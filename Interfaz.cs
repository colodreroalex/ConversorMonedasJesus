using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMonedasJesus
{
    public static class Interfaz
    {

        public static void MenuPrincipal()
        {
            Console.Clear(); 
            Console.WriteLine();
            Console.WriteLine("0. Salir de la aplicacion");
            Console.WriteLine("1. Modificar las tasas de conversión actuales");
            Console.WriteLine("2. Realizar conversion de monedas");
            Console.WriteLine("Seleccione una opción:");


        }


        public static void MenuConfiguracion()
        {

        }

        public static void MenuConversor()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("0. Salir");
            Console.WriteLine("1. Cambio de Euros --> Dollars");
            Console.WriteLine("2. Cambio de Dollars --> Euros");
        }

        internal static int OpcionDeConversion(byte opMax)
        {
            int op = 0;
            bool opCorrecta = false;

            do
            {

                MenuConversor();

                try
                {
                    op = LeerOpcion(opMax);
                    opCorrecta = true;
                }
                catch (FormatException fe)
                {
                    MostrarError("Opcion incorrecta - Valor no numerico");
                }
                catch (OverflowException oe)
                {
                    MostrarError("Opcion incorrecta - Valor fuera de rango");
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                }

            } while (!opCorrecta);


            return op;
        }

        public static int OpcionMPrincipal(byte opMax)
        {
            int op = 0;
            bool opCorrecta = false;

            do
            {

                MenuPrincipal();

                try
                {
                    op = LeerOpcion(opMax);
                    opCorrecta  = true; 
                }
                catch(FormatException fe)
                {
                    MostrarError("Opcion incorrecta - Valor no numerico"); 
                }
                catch(OverflowException oe)
                {
                    MostrarError("Opcion incorrecta - Valor fuera de rango");
                }
                catch(Exception ex)
                {
                    MostrarError(ex.Message);
                }

            } while (!opCorrecta);

            return op; 

        }

       

        private static void MostrarError(string v)
        {
            Console.WriteLine(v);
        }

        private static int LeerOpcion(byte opMax)
        {
            int op;
            op = Convert.ToInt32(Console.ReadLine());

            if (op < 0 || op > opMax) throw new Exception("Opcion incorrecta");

            return op; 
        }

        public static double pedirCantidad()
        {
            double cantidad = 0;

            Console.WriteLine("Ingrese la cantidad a convertir --> ");
            cantidad = Convert.ToDouble(Console.ReadLine());

            return cantidad; 
        }

        public static void MostrarConversion(double cantidad)
        {
            Console.WriteLine("Cantidad modificada --> " + cantidad);
            Console.ReadLine(); 
        }
        
    }
}
