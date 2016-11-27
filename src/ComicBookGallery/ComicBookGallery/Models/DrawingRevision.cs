using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBookGallery.Models
{
    public class DrawingRevision
    {

        public enum ReleaseStatus
        {
            Released,
            Review,
            IFC,
            IFI,
            IFA
                
        }

        public DrawingRevision()
        {

        }
        public DrawingRevision(string id, string name, ReleaseStatus status, int drawingId )
        {
            ID = id;
            Name = name;
            Status = status;
            DrawingId = drawingId;
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public ReleaseStatus Status { get; set; }

        public int DrawingId { get; set; }
        public string DisplayName
        {
            get
            {
                return ID + "-" + Name;
            }
        }
    }
}