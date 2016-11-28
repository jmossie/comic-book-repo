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
        public void UpdateDrawing(Drawing drawing)
        {
            int drawingIndex = Data.Drawings.FindIndex(d => d.Id == drawing.Id);

            if (drawingIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find a drawing with an ID of {0}", drawing.Id));
            }
            Data.Drawings[drawingIndex] = drawing;
        }
        public void DeleteDrawing(int Id)
        {
            int drawingIndex = Data.Drawings.FindIndex(d => d.Id == Id);

            if (drawingIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find a drawing with an ID of {0}", Id));
            }
            Data.Drawings.RemoveAt(drawingIndex);
        }
    }
}