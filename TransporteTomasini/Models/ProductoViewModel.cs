using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransporteTomasini.Models.ViewModels
{
    public class ProductoViewModel
    {

        public int IdProducto { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Descripcion del producto")]
        public string NombreProducto { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public decimal PrecioProducto { get; set; }
        [Required]
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }

    }


}