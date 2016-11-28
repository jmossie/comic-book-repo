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
        public ActionResult Index(string searchString)
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
            //ValidateEntry(drawing);
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
        public ActionResult RevCreate(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var drawing = _drawingRepository.GetDrawing((int)id);
            return View(drawing);
        }
        //private void ValidateEntry(Drawing drawing)
        //{
   
        //    if (ModelState.IsValidField("DrawingNumber"))
        //    {
        //        ModelState.AddModelError("DrawingNumber",
        //            "The Drawing Number field is required.");
        //    }
        //}

    }
}
