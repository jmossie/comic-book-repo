using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComicBookGallery.Models;

namespace ComicBookGallery.Data
{
    public class DrawingRepository
    {
        private static Drawing[] _drawings = new Drawing[]
{
    new Drawing()
    {
        Id = 1,
        DrawingNumber = "1298787-009",
        DrawingName = "First Drawing",
        DrawingRevisions = new DrawingRevision[]
        {
            new DrawingRevision() { Name = "1st Revision", ID = "A", Status = DrawingRevision.ReleaseStatus.Released },
            new DrawingRevision() { Name = "2nd Revision", ID = "B", Status = DrawingRevision.ReleaseStatus.Review }
        }
    },
    new Drawing()
    {
        Id = 2,
        DrawingNumber = "3243243-009",
        DrawingName = "Second Drawing",
        DrawingRevisions = new DrawingRevision[]
        {
            new DrawingRevision() { Name = "1st Revision", ID = "A", Status = DrawingRevision.ReleaseStatus.Released },
            new DrawingRevision() { Name = "2nd Revision", ID = "B", Status = DrawingRevision.ReleaseStatus.Review }
        }
    },
        new Drawing()
    {
        Id = 3,
        DrawingNumber = "4343425-012",
        DrawingName = "Third Drawing",
        DrawingRevisions = new DrawingRevision[]
        {
            new DrawingRevision() { Name = "1st Revision", ID = "A", Status = DrawingRevision.ReleaseStatus.Released },
            new DrawingRevision() { Name = "2nd Revision", ID = "B", Status = DrawingRevision.ReleaseStatus.Review }
        }
    },
};
        public Drawing[] GetDrawings()
        {
            return _drawings;
        }

        public Drawing[] GetDrawings(string searchString)
        {
            return _drawings.Where(d => d.DisplayName.Contains(searchString)).ToArray();
        }
        public Drawing GetDrawing(int id)
        {
            Drawing drawingToReturn = null;
            foreach (var drawing in _drawings)
            {
                if (drawing.Id == id)
                {
                    drawingToReturn = drawing;
                    break;
                }
            }
            return drawingToReturn;
        }
    }
}