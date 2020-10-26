using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransporteTomasini.Models.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int IdCliente { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Nombre")]
        public string NombreCliente { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Localidad")]
        public string Localidad { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Mail")]
        public string Mail { get; set; }
    }
}