using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransporteTomasini.Models.ViewModels
{
    public class ListProductoViewModel
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioProducto { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
    }
}