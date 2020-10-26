using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TransporteTomasini.Models;
using TransporteTomasini.Models.ViewModels;
using TransporteTomasini.Reglas_de_Negocio;

namespace TransporteTomasini.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ListClienteViewModel> lst;
            using (TransporteEntities1 db = new TransporteEntities1())
            {
                lst = (from d in db.Cliente
                       select new ListClienteViewModel
                       {
                           IdCliente = (int)d.IdCliente,
                           NombreCliente = d.NombreCliente,
                           Provincia = d.Provincia,
                           Localidad = d.Localidad,
                           Direccion = d.Direccion,
                           Telefono = d.Telefono,
                           Mail = d.Mail


                       }).ToList();
            }
            return View(lst);
        }
        [HttpPost]
        public ActionResult Index(string Nombre)
        {
            List<ListClienteViewModel> lst;
            using (TransporteEntities1 db = new TransporteEntities1())
            {
                lst = (from c in db.Cliente
                       where c.NombreCliente == Nombre
                       select new ListClienteViewModel
                       {
                           IdCliente = (int)c.IdCliente,
                           NombreCliente = c.NombreCliente,
                           Provincia = c.Provincia,
                           Localidad = c.Localidad,
                           Direccion = c.Direccion,
                           Telefono = c.Telefono,
                           Mail = c.Mail


                       }).ToList();
            }
            return View(lst);
        }



        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ClienteRN c = new ClienteRN();
                    using (TransporteEntities1 db = new TransporteEntities1())
                    {
                        var oCliente = new Cliente();
                        oCliente.IdCliente = model.IdCliente;
                        oCliente.NombreCliente = model.NombreCliente;
                        oCliente.Provincia = model.Provincia;
                        oCliente.Localidad = model.Localidad;
                        oCliente.Direccion = model.Direccion;
                        oCliente.Telefono = model.Telefono;
                        oCliente.Mail = model.Mail;

                        bool validar = c.ValidarNombre(oCliente.NombreCliente);
                        if (validar == true)
                        {
                            db.Cliente.Add(oCliente);
                            db.SaveChanges();
                        }
                        else
                        {
                            //return Content("<script language='javascript' type='text/javascript'>alert('Ya existe un cliente con ese nombre');</script>");
                            ViewBag.sms = true;
                            return View(model);
                        }


                    }

                    return Redirect("~/Cliente/");
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
            ClienteViewModel model = new ClienteViewModel();
            using (TransporteEntities1 db = new TransporteEntities1())
            {
                var oCliente = db.Cliente.Find(id);
                model.NombreCliente = oCliente.NombreCliente;
                model.Provincia = oCliente.Provincia;
                model.Localidad = oCliente.Localidad;
                model.Direccion = oCliente.Direccion;
                model.Telefono = oCliente.Telefono;
                model.Mail = oCliente.Mail;
                model.IdCliente = (int)oCliente.IdCliente;
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cliente oCliente;
                    using (TransporteEntities1 db = new TransporteEntities1())
                    {
                        oCliente = db.Cliente.Find(model.IdCliente);
                        oCliente.IdCliente = model.IdCliente;
                        oCliente.NombreCliente = model.NombreCliente;
                        oCliente.Provincia = model.Provincia;
                        oCliente.Localidad = model.Localidad;
                        oCliente.Direccion = model.Direccion;
                        oCliente.Telefono = model.Telefono;
                        oCliente.Mail = model.Mail;

                        db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Cliente/");
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
            
            using (TransporteEntities1 db = new TransporteEntities1())
            {
                var oCliente = db.Cliente.Find(id);
                db.Cliente.Remove(oCliente);
                db.SaveChanges();
            };
            return Redirect("~/Cliente/");
        }
    }
}