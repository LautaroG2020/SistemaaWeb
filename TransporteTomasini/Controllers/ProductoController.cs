using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using TransporteTomasini.Models;
using TransporteTomasini.Models.ViewModels;
using System.Data;
using System.Web.UI.WebControls;

namespace TransporteTomasini.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto

        //public ActionResult Index()
        //{

        //    List<ListProductoViewModel> lst;
        //    using (TransporteEntities1 db = new TransporteEntities1())
        //    {
        //        lst = (from d in db.Producto
        //               select new ListProductoViewModel
        //               {
        //                   IdProducto = (int)d.IdProducto,
        //                   NombreProducto = d.NombreProducto,
        //                   PrecioProducto = d.PrecioProducto,
        //                   IdCliente = (int)d.IdCliente


        //               }).ToList();
        //    }
        //    return View(lst);
        //}

        [HttpGet]
        public ActionResult VerProductos(int id)
        {

            List<ListProductoViewModel> lts;
            using (TransporteEntities1 db = new TransporteEntities1())
            {
                lts = (from p in db.Producto
                       where p.IdCliente == id
                       select new ListProductoViewModel
                       {
                           IdProducto = (int)p.IdProducto,
                           NombreProducto = p.NombreProducto,
                           PrecioProducto = p.PrecioProducto,
                           IdCliente = (int)p.IdCliente

                       }).ToList();
            }
            return View(lts);
        }

        public ActionResult Nuevo()

        {
            List<ListClienteViewModel> lts;
            using (TransporteEntities1 db = new TransporteEntities1())
            {
                lts = (from c in db.Cliente
                       select new ListClienteViewModel
                       {
                           IdCliente = (int)c.IdCliente,
                           NombreCliente = c.NombreCliente


                       }).ToList();
            }
            List<SelectListItem> items = lts.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.NombreCliente.ToString(),
                    Value = d.IdCliente.ToString(),
                    Selected = false
                };
            });
            ViewBag.items = items;
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ProductoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Producto oProducto;
                    using (TransporteEntities1 db = new TransporteEntities1())
                    {
                        oProducto = new Producto();
                        oProducto.IdProducto = model.IdProducto;
                        oProducto.NombreProducto = model.NombreProducto;
                        oProducto.PrecioProducto = model.PrecioProducto;
                        oProducto.IdCliente = model.IdCliente;


                        db.Producto.Add(oProducto);
                        db.SaveChanges();
                    }

                    return Redirect("~/Producto/VerProductos/"+ oProducto.IdCliente);
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            ProductoViewModel model = new ProductoViewModel();
            using (TransporteEntities1 db = new TransporteEntities1())
            {
                var oProducto = db.Producto.Find(id);
                model.NombreProducto = oProducto.NombreProducto;
                model.PrecioProducto = oProducto.PrecioProducto;   
                model.IdCliente = oProducto.IdCliente;
                model.IdProducto = oProducto.IdProducto;
            };
            ViewBag.idClien = model.IdCliente;            
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(ProductoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Producto oProducto;
                    using (TransporteEntities1 db = new TransporteEntities1())
                    {
                        oProducto = db.Producto.Find(model.IdProducto);
                        oProducto.IdProducto = model.IdProducto;
                        oProducto.NombreProducto = model.NombreProducto;
                        oProducto.PrecioProducto = model.PrecioProducto;

                        db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Producto/VerProductos/"+ oProducto.IdCliente);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult ELiminar(int id)
        {
            Producto oProducto;
            using (TransporteEntities1 db = new TransporteEntities1())
            {
                oProducto = db.Producto.Find(id);
                db.Producto.Remove(oProducto);
                db.SaveChanges();
            };
            return Redirect("~/Producto/VerProductos/" + oProducto.IdCliente);
        }


    }
}