using ResgisterMultiple.Helpers.ClassMultiple;
using ResgisterMultiple.Helpers.DTO;
using ResgisterMultiple.Models;
using ResgisterMultiple.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResgisterMultiple.Controllers
{
    public class MaintenanceController : Controller
    {
        BankContext context = new BankContext();

        public ActionResult Index()
        {
            var result = context.SucuDepars
                 .Include("departaments")
                 .Include("sucursals")
                 .Select(c => new SucuDepa
                 {
                     Id = c.id,
                     Departament = c.departament.nameDepartaments,
                     Sucursal = c.sucursal.nameSucursals
                 }).ToList();

            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = context.SucuDepars
                            .Include("departaments")
                            .Include("sucursals")
                            .Where(x => x.id == id)
                            .Select(c => new SucuDepa
                            {
                                Id = c.id,
                                Departament = c.departament.nameDepartaments,
                                Sucursal = c.sucursal.nameSucursals
                            }).FirstOrDefault();

            return View(result);
        }

        public ActionResult Create()
        {
            var sucursals = context.sucursals.ToList();
            var departaments = context.departaments.ToList();

            var result = new SucuDepa()
            {
                Sucursals = sucursals,
                Departamets = departaments
            };

            return View(result);
        }

        [HttpPost]
        public ActionResult Create(List<SucursalDepartament> itemList)
        {
            var SucuDepa = new List<SucuDepar>();

            try
            {
                foreach (var item in itemList)
                {
                    var result = new SucuDepar()
                    {
                        idDepartaments = item.IdDepartament,
                        idSucursals = item.IdSucursal
                    };
                    SucuDepa.Add(result);
                }

                context.SucuDepars.AddRange(SucuDepa);
                context.SaveChanges();


                return Json(new { Message = "success" });
            }
            catch
            {
                return Json(new { });
            }
        }

        // GET: Maintenance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Maintenance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Maintenance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Maintenance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult SendDataUpdateList(List<SucursalDepartament> itemList)
        {
            int index = 0;
            var listSucuDepe = new List<SucuDepaDTO>();
            if (itemList != null)
            {
                foreach (var item in itemList)
                {
                    var sucursal = context.sucursals.Where(x => x.id == item.IdSucursal).FirstOrDefault().nameSucursals;
                    var departament = context.departaments.Where(x => x.id == item.IdDepartament).FirstOrDefault().nameDepartaments;
                    var result = new SucuDepaDTO()
                    {
                        Id = index++,
                        Sucursal = sucursal,
                        Departament = departament
                    };

                    if (!ExistsSucuDepa(item.IdDepartament, item.IdSucursal)) 
                    {
                        result.Exists = false;
                        listSucuDepe.Add(result);
                    }
                    else 
                    {
                        result.Exists = true;
                        listSucuDepe.Add(result);
                    }
                }
            }
            return Json(new { listSucuDepe });
        }

        private bool ExistsSucuDepa(int idDepartament, int idSucursal) => context.SucuDepars.Any(x => x.idSucursals == idSucursal && x.idDepartaments == idDepartament);
    }
}
