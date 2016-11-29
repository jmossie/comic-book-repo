using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComicBookGallery.Models;
using ComicBookGallery.Data;

namespace ComicBookGallery.Controllers
{
    public class DrawingsController : Controller
    {
        private DrawingRepository _drawingRepository = null;

        public DrawingsController()
        {
            _drawingRepository = new DrawingRepository();
        }
        public ActionResult Index()
        {
            var drawings = _drawingRepository.GetDrawings();
            var numDrawings = drawings.Count();
            ViewBag.NumOfDrawings = numDrawings;
            return View(drawings);
        }
        public ActionResult Add()
        {
            var drawing = new Drawing()
            {
                CreateDate = DateTime.Today,
            };

            return View(drawing);
        }

        [HttpPost]
        public ActionResult Add(Drawing drawing)
        {
            ValidateEntry(drawing);
            if (ModelState.IsValid)
            {
                _drawingRepository.AddDrawing(drawing);
                TempData["Message"] = "Your entry was successfully added";

                return RedirectToAction("Index");
            }
            
            return View(drawing);
        }
            
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var drawing = _drawingRepository.GetDrawing((int)id);
         
            return View(drawing);
        }
        [HttpPost]
        public ActionResult Detail(Drawing drawing)
        {
            if (ModelState.IsValid)
            {
                _drawingRepository.UpdateDrawing(drawing);
                TempData["Message"] = "Your entry was successfully updated";
                return RedirectToAction("Index");
            }
            return View(drawing);
        }
        public ActionResult RevDetail(string rid)
        {
            if (rid == null)
            {
                return HttpNotFound();
            }
            string[] specificRev = rid.Split('x');
            var rev = specificRev[1];
            var drw = Convert.ToInt32(specificRev[0]);
            var revision = _drawingRepository.GetDrwSpecificRevision(drw,rev);
            //return View();
            SetupStatusSelectListItems();
            return View(revision);
        }
        [HttpPost]
        public ActionResult RevDetail(DrawingRevision revision)
        {
            if (ModelState.IsValid)
            {
                _drawingRepository.UpdateRevision(revision);
                TempData["Message"] = "Your entry was successfully updated";
                return RedirectToAction("Index");
            }
            SetupStatusSelectListItems();
            return View(revision);
        }
        public ActionResult RevCreate(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var drawing = _drawingRepository.GetDrawing((int)id);
            return View(drawing);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Drawing drawing = _drawingRepository.GetDrawing((int)id);
            if (drawing == null)
            {
                return HttpNotFound();
            }
            return View(drawing);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _drawingRepository.DeleteDrawing(id);
            TempData["Message"] = "Your entry was successfully deleted";
            return RedirectToAction("Index");

        }
        private void ValidateEntry(Drawing drawing)
        {
            var drawings = _drawingRepository.GetDrawings();
            var notValid = drawings.Exists(d => d.DrawingNumber == drawing.DrawingNumber);
            if (notValid)
            {
                ModelState.AddModelError("DrawingNumber", "The Drawing Number already exists.");
            }
            if (!ModelState.IsValidField("DrawingNumber") && !notValid)
            {
                ModelState.AddModelError("DrawingNumber",
                    "The Drawing Number field is required.");
            }
        }
        private void SetupStatusSelectListItems()
        {
            ViewBag.StatusSelectListItems = new SelectList(
               Data.Data.Statuses, "Id", "Name");
        }

    }
}
