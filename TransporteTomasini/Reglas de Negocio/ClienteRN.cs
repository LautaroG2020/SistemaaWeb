using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransporteTomasini.Models;

namespace TransporteTomasini.Reglas_de_Negocio
{
    public class ClienteRN
    {

        public bool ValidarNombre(string nombre)
        {
            using (TransporteEntities1 db = new TransporteEntities1())
            {
                var item = (from i in db.Cliente
                            where (i.NombreCliente == nombre)
                            select i.NombreCliente);

                if (item.Contains(nombre))
                {
                    return false;
                }
                return true;
            }
        }
    }
}