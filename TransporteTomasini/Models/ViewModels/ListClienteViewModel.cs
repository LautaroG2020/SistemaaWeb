using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransporteTomasini.Models.ViewModels
{
    public class ListClienteViewModel
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
    }
}