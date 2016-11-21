﻿using System;
using System.Collections.Generic;
using System.Linq;
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

            return View(drawings);
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
    }
}
