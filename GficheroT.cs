using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMonedasJesus
{
    public class GficheroT
    {
        private const string FICHERO = "config.cvs";
        const double EURO_DOLLAR = 1.3635;
        const double DOLLAR_EURO = 0.7374;

        public static void ComprobarFichero()
        {
            //RECURSOS

            //COMPROBACION
            if (!File.Exists(FICHERO))
                GuardarDatos(EURO_DOLLAR, DOLLAR_EURO);

        }

        public static void GuardarDatos(double euroDolar, double dolarEuro)
        {
            StreamWriter sw = null;

            if (File.Exists(FICHERO))
            {
                File.Delete(FICHERO);
            }

            sw = File.CreateText(FICHERO);


            sw.WriteLine(euroDolar); 
            sw.WriteLine(dolarEuro);

            sw.Close(); 
        }


        

       

        public static double ObtenerConversor(byte linea)
        {
            double cantidad = 0; 
            StreamReader lector = null;

            if (!File.Exists(FICHERO)) throw new Exception("Fichero no existe"); 
            lector = File.OpenText(FICHERO);

            try
            {
                //Posicionar el puntero del fichero para leer el dato y convertir la cantidad
                for (int i = 0; i < linea; i++) 
                    
                    cantidad = Convert.ToDouble(lector.ReadLine());

                //Lee el fichero y convierte la cantidad


            }
            catch (Exception ex)
            {
                lector.Close();
                throw new Exception(ex.Message);
            }

            lector.Close(); 

            return cantidad; 
        }

        //public static double EuroDolar()
        //{
        //    double cantidad = 0;
        //    StreamReader lector = null;

        //    //Abrir Fichero
        //    if (!File.Exists(FICHERO))
        //        throw new FileNotFoundException
        //            ($"No existe el fichero -->{FICHERO} ");

        //    //Leer Fichero
        //    lector = File.OpenText(FICHERO);

        //    //Convertir cantidad
        //    try
        //    {
        //        cantidad = Convert.ToDouble(lector.ReadLine());
        //    }
        //    catch (Exception ex)
        //    {
        //        lector.Close();
        //        throw new Exception(ex.Message);
        //    }

        //    //Cerrar Fichero
        //    lector.Close();


        //    return cantidad;
        //}

        //public static double DolarEuro()
        //{
        //    double cantidad = 0;
        //    StreamReader lector = null;

        //    //Abrir Fichero
        //    if (!File.Exists(FICHERO))
        //        throw new FileNotFoundException
        //            ($"No existe el fichero -->{FICHERO} ");

        //    //Leer Fichero
        //    lector = File.OpenText(FICHERO);

        //    //Convertir cantidad
        //    try
        //    {
        //        lector.ReadLine(); //La primera linea la lee y no la escribe,
        //                           //ya q me interesa leer la siguiente
        //                           //linea para convertirla
        //        cantidad = Convert.ToDouble(lector.ReadLine());
        //    }
        //    catch (Exception ex)
        //    {
        //        lector.Close();
        //        throw new Exception(ex.Message);
        //    }

        //    //Cerrar Fichero
        //    lector.Close();


        //    return cantidad;
        //}

    }

    
}
