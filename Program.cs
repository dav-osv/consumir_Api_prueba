
using System.Net;
using System;
using System.Runtime.InteropServices;
using ProyectoReloj;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

public class Program
{
   
    public static void Main(string[] args)
    {
              ApiRest apiRest = new ApiRest();
         
              var registrosEmpleados = apiRest.obtenerRegistrosEmpleados().Result;


                /*  El proyecto se tiene que compilar en NET. 6 u 7 */
                /*  En el paquete nugets se tiene que instalar la siguiente libreria  Newtonsoft.Json.Linq; para que pueda funcionar */


                /* Una vez teniendo la variable registroEmpleados, simplemente verificamos que venga algo , en caso contrario es un error*/
                /* si viene algo siemplemente recorremos los atributos con un foreach y los obtenemos las propiedades de los items */

                /* if (registrosEmpleados != null )
                    foreach (var item in registrosEmpleados["AcsEvent"]["InfoList"]){
                      Console.WriteLine(item["time"]);
                } */



    }
}