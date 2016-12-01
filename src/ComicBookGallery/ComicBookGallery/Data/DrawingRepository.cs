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
        public List<DrawingRevision> GetRevisions()
        {
            return Data.DrawingRevisions;
        }
        public DrawingRevision GetDrwSpecificRevision(int id, int rid)
        {
            //List<DrawingRevision> revisions = Data.DrawingRevisions.Where(dr => dr.DrawingId == id).ToList();
            //var drawing = Data.Drawings.Where(d => d.Id == id).SingleOrDefault();
            //var revision = drawing.Revisions.Where(r => r.ID == rid).SingleOrDefault();
            var revision = Data.DrawingRevisions.Where(dr => dr.UID == rid).SingleOrDefault();
            return revision;
        }
        public void AddDrawing(Drawing drawing)
        {
            int nextAvailableEntryId = Data.Drawings.Max(d => d.Id) + 1;
            drawing.Id = nextAvailableEntryId;
            Data.Drawings.Add(drawing);
        }
        public void AddRevision(DrawingRevision revision)
        {
            int nextAvailableEntryId = Data.DrawingRevisions.Max(dr => dr.UID) + 1;
            Drawing drawing = Data.Drawings.Where(d => d.Id == revision.DrawingId).SingleOrDefault();
            revision.UID = nextAvailableEntryId;
            Data.DrawingRevisions.Add(revision);
            drawing.Revisions = Data.DrawingRevisions.Where(dr => dr.DrawingId == revision.DrawingId).ToList();
        }
        public void UpdateDrawing(Drawing drawing)
        {
            int drawingIndex = Data.Drawings.FindIndex(d => d.Id == drawing.Id);

            if (drawingIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find a drawing with an ID of {0}", drawing.Id));
            }
            Data.Drawings[drawingIndex].CreateDate = drawing.CreateDate;
            Data.Drawings[drawingIndex].DrawingNumber = drawing.DrawingNumber;
            Data.Drawings[drawingIndex].DrawingName = drawing.DrawingName;
        }
        public void UpdateRevision(DrawingRevision revision)
        {
            int revisionIndex = Data.DrawingRevisions.FindIndex(dr => dr.UID == revision.UID);
            Drawing drawing = Data.Drawings.Where(d => d.Id == revision.DrawingId).SingleOrDefault();
            if (revisionIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find a revision with an ID of {0}", revision.UID));
            }
            Data.DrawingRevisions[revisionIndex] = revision;
            drawing.Revisions = Data.DrawingRevisions.Where(dr => dr.DrawingId == revision.DrawingId).ToList();
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