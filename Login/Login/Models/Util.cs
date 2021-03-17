using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class Util
    {
        public static string NumeroNombreIndustria(INDUSTRIA iNDUSTRIA)
        {
            string salida = "00";
            if( iNDUSTRIA.id >= 10)
            {
                salida = "0";
            }
            return salida + iNDUSTRIA.id.ToString() + iNDUSTRIA.nombre;
        }

        public static string NumeroATexto(int number)
        {
            return number.ToString("D3"); ;
        }
    }
}