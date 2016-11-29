using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DrawingRevision(string id, string name, Status.StatusTypes status, int drawingId, int year, int month, int day, string notes = null )
        {
            ID = id;
            Name = name;
            Status = status;
            DrawingId = drawingId;
            CreateDate = new DateTime(year, month, day);
            Notes = notes;
        }
        [Display(Name = "Revision Name")]
        public string Name { get; set; }
        [Display(Name = "Revision Number")]
        public string ID { get; set; }
        public Status.StatusTypes Status { get; set; }
        [Display(Name = "Parent Drawing")]
        public int DrawingId { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreateDate { get; set; }
        [MaxLength(200, ErrorMessage = "The Notes field cannot be longer than 200 characters.")]
        public string Notes { get; set; }
        public string DisplayName
        {
            get
            {
                return ID + "-" + Name;
            }
        }
    }
}