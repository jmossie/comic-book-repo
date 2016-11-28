using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComicBookGallery.Models;

namespace ComicBookGallery.Data
{
    public class DrawingRepository
    {

  
        public List<Drawing> GetDrawings()
        {
        return Data.Drawings;
        }


        public Drawing GetDrawing(int id)
        {
            Drawing drawing = Data.Drawings.Where(d => d.Id == id).SingleOrDefault();

            return drawing;
        }
        public void AddDrawing(Drawing drawing)
        {
            int nextAvailableEntryId = Data.Drawings.Max(d => d.Id) + 1;
            drawing.Id = nextAvailableEntryId;
            Data.Drawings.Add(drawing);
        }
    }
}